using Entities.Interfaces;
using System.Linq.Expressions;
namespace DbLibrary;

/// <summary>
/// Репозитория БД
/// </summary>
public class DbRepository
{
    private readonly IDbContextFactory<SqlDbContext> contextFactory;

    public DbRepository(IDbContextFactory<SqlDbContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }

    /// <summary>
    /// Проверка доступности БД
    /// </summary>
    /// <returns></returns>
    public async Task<(bool checkResult, Exception? ex)> DbAvailableAsync()
    {
        try
        {
            using (var db = contextFactory.CreateDbContext())
            {
                var dbAvailableResult = await db.Database.CanConnectAsync(); //Провеяем доступен ли сервер MSSQL
                if (!dbAvailableResult)
                    throw new Exception("Сервер БД недоступен");//return (false, null) ;

                var result = db.Set<RegisteredUser>().Count();//проверяем что есть таблица в БД. Считаем, что если есть таблица, то есть и другие таблицы.
                if (result >= 0)
                    return (true,null);

                throw new Exception("Не удалось подключиться к БД");//return (false, null) ;
                //return (false, null);
            }
        }
        catch (Exception ex)
        {
            return (false, ex);
        }
    }

    /// <summary>
	/// Создать новую БД
	/// </summary>
	public async Task<(bool operationResult, Exception? ex)> CreateNewDbAsync()
    {
        try
        {
            using (var db = contextFactory.CreateDbContext())
            {
                await db.Database.EnsureDeletedAsync();
                var rezult = await db.Database.EnsureCreatedAsync();

                if (!rezult)
                    return (false, null);
                return (true, null);
            }
        }
        catch (Exception ex)
        {
            return (false, ex);
        }
    }

    /// <summary>
    /// Загрузить начальные данные в БД
    /// </summary>
    public async Task<(bool operationResult, Exception? ex)> SaveInitDataInDbAsync()
    {
        try
        {
            using (var db = contextFactory.CreateDbContext())
            {
                // todo заменить на вызов метода
                var rezult= await db.Database.CanConnectAsync(); //Провеяем доступен ли сервер MSSQL

                if (rezult)
                {
                    var moscow = OrganizationDetailSeeder.GetMoscowMedicalOrganization();
                    await db.OrganizationInfos.AddRangeAsync(moscow);

                    var users = UserSeeder.GetSampleUsers();
                    await db.RegisteredUsers.AddRangeAsync(users);

                    var patients = PatientSeeder.GetSamplePatients();
                    await db.Patients.AddRangeAsync(patients);

                    var positions = PositionSeeder.GetSamplePositions();
                    await db.Positions.AddRangeAsync(positions);

                    var employees = EmployeeSeeder.GetSampleEmployees(positions);
                    await db.Employees.AddRangeAsync(employees);

                    var medicalServiceTypes = MedicalServiceTypeSeeder.GetSampleMedicalServiceTypes();
                    await db.MedicalServiceTypes.AddRangeAsync(medicalServiceTypes);

                    var medServices = MedicalServiceSeeder.GetSampleServices(medicalServiceTypes);
                    await db.MedicalServices.AddRangeAsync(medServices);

                    var contracts = ContractSeeder.GetSampleContracts(patients, employees);
                    await db.Contracts.AddRangeAsync(contracts);

                    var contractItems = ContractItemSeeder.GetSampleContractItems(contracts, medServices);
                    await db.ContractItems.AddRangeAsync(contractItems);

                    var payments = PaymentSeeder.GetSamplePayments(contracts);
                    await db.Payments.AddRangeAsync(payments);

                    await db.SaveChangesAsync();
                }
            }
            return (true, null);

        }
        catch (Exception ex)
        {
            return (false, ex);
        }
    }

    /// <summary>
    /// Прочитать сущности
    /// </summary>
    /// <typeparam name="TEntity">Тип</typeparam>
    /// <param name="predicate">Условие поиска</param>
    /// <param name="orderBy">Сортировка</param>
    /// <param name="include">Включить зависимые сущности</param>
    /// <param name="trackingType">Отслеживание прочитанных сужностей</param>
    /// <returns></returns>
    public async Task<(IEnumerable<TEntity> data, Exception? ex)> GetEntitiesAsync<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>>? predicate = null,
                                                                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                                                            TrackingType trackingType = TrackingType.NoTracking)
        where TEntity : class
    {
        try
        {
            using (var db = contextFactory.CreateDbContext())
            {
                var query = db.Set<TEntity>().AsQueryable(); //.AsSplitQuery();
                query = TrackingPart(trackingType, query);
                query = Common_Predicat_OrderBy_Include(query, predicate, orderBy, include);
                var result = await query.ToListAsync();
                return (result, null);
            }
        }
        catch (Exception ex)
        {
            return (new List<TEntity>(), ex);
        }
    }

    /// <summary>
    /// Настройка отслеживания
    /// </summary>
    protected IQueryable<T> TrackingPart<T>(TrackingType trackingType, IQueryable<T> entities)
        where T : class
    {
        var query = trackingType switch
        {
            TrackingType.NoTracking => entities.AsNoTracking(),
            TrackingType.NoTrackingWithIdentityResolution => entities.AsNoTrackingWithIdentityResolution(),
            TrackingType.Tracking => entities,
            _ => throw new ArgumentOutOfRangeException(nameof(trackingType), trackingType, null)
        };
        return query;
    }

    /// <summary>
    /// Настройка параметров
    /// </summary>
    private IQueryable<T> Common_Predicat_OrderBy_Include<T>(IQueryable<T> query,
                                                                System.Linq.Expressions.Expression<Func<T, bool>>? predicate = null,
                                                                Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                                                Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        where T : class
    {
        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);

        if (orderBy is not null)
            query = orderBy(query);
        return query;
    }

    /// <summary>
	/// Обновить сущность в БД
	/// </summary>
	public async Task<(TEntity? entety,Exception? ex)> UpdateEntityAsync<TEntity>(TEntity entity)
    where TEntity : class
    {
        try
        {
            using var db = contextFactory.CreateDbContext();
            var result = db.Update<TEntity>(entity);
            var n = await db.SaveChangesAsync();
            return (result.Entity, null);
        }
        catch (Exception ex)
        {
            return (null, ex);
        }
    }

    /// <summary>
	/// Удалить сущность в БД
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <param name="entity"></param>
	/// <returns></returns>
	public async Task<(TEntity entity, Exception? ex)> DelEntityAsync<TEntity>(TEntity entity)
    where TEntity : class, IHaveId
    {
        try
        {
            using var db = contextFactory.CreateDbContext();
            var find = await db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (find != null)
            {
                var deletedEntity= db.Remove(find);
                await db.SaveChangesAsync();
                return (deletedEntity.Entity, null);
            }
            return (entity, null);
        }
        catch (Exception ex)
        {
            return (entity, ex);
        }
    }

    /// <summary>
    /// Найти сущность
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="predicate"></param>
    /// <param name="orderBy"></param>
    /// <param name="include"></param>
    /// <param name="trackingType"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public async Task<(TEntity? entity, Exception? ex)> GetFirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>>? predicate = null,
                                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                            TrackingType trackingType = TrackingType.NoTracking)
    where TEntity : class
    {
        try
        {
            using var db = contextFactory.CreateDbContext();

            var _dbSet = db.Set<TEntity>();

            var query = trackingType switch
            {
                TrackingType.NoTracking => _dbSet.AsNoTracking(),
                TrackingType.NoTrackingWithIdentityResolution => _dbSet.AsNoTrackingWithIdentityResolution(),
                TrackingType.Tracking => _dbSet,
                _ => throw new ArgumentOutOfRangeException(nameof(trackingType), trackingType, null)
            };

            if (include is not null)
            {
                query = include(query);
            }

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            var rezult = orderBy is not null
                ? await orderBy(query).FirstOrDefaultAsync()
                : await query.FirstOrDefaultAsync();

            return (rezult, null);
        }
        catch (Exception ex)
        {
            return (null, ex);
        }
    }

    /// <summary>
    /// Информация о договоре
    /// </summary>
    public async Task<(IEnumerable<Contract> data, Exception? ex)> GetAllInfoAboutContractsAsync(System.Linq.Expressions.Expression<Func<Contract, bool>>? predicate = null)
    {
        var result = await GetEntitiesAsync<Contract>(include: x => x.Include(cont => cont.Patient) //Подгружаем данные о пациенте
                                                                    .Include(cont=>cont.Payments)
                                                                    .Include(cont=>cont.ContractItems)
                                                                        .ThenInclude(ci=>ci.MedicalService)
                                                                            .ThenInclude(ms=>ms.MedicalServiceType)
                                                                    .Include(cont => cont.Employee), //Подгружаем данные о сотруднике
                                                      orderBy: x => x.OrderByDescending(contr => contr.ContractDate),// Сортируем по дате заключения договора
                                                      predicate:predicate // Фильтр
                                                      ); 
        return result;
    }
}

