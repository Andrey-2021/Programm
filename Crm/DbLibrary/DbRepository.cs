using Entities.Interfaces;

namespace DbLibrary;

public class DbRepository
{
    private readonly IDbContextFactory<SqlDbContext> contextFactory;

    public DbRepository(IDbContextFactory<SqlDbContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }

    /// <summary>
	/// Создать новую БД
	/// </summary>
	/// <returns></returns>
	public async Task<(bool operationResult, Exception? ex)> CreateNewDbAsync()
    {
        try
        {
            //using var db = contextFactory.CreateDbContext();
            //await db.CreateClearDbAsync();
            //await InitDb(db);
            //return (true, null);

            //using (var db = new SqlDbContext())
            using (var db = contextFactory.CreateDbContext())
            {
                await db.Database.EnsureDeletedAsync();
                var rezult = await db.Database.EnsureCreatedAsync();

                if (rezult)
                {
                    var patients = PatientSeeder.GetSamplePatients();
                    await db.Patients.AddRangeAsync(patients);

                    var employees = EmployeeSeeder.GetSampleEmployees();
                    await db.Employees.AddRangeAsync(employees);

                    var medServices= MedicalServiceSeeder.GetSampleServices();
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

    public async Task<(IEnumerable<TEntity> data, Exception? ex)> GetEntitiesAsync<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>>? predicate = null,
                                                                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                                                            TrackingType trackingType = TrackingType.NoTracking)
        where TEntity : class
    {
        try
        {
            //using var db = contextFactory.CreateDbContext();
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
	/// <typeparam name="TEntity"></typeparam>
	/// <param name="entity"></param>
	/// <returns></returns>
	public async Task<Exception?> UpdateEntityAsync<TEntity>(TEntity entity)
    where TEntity : class
    {
        try
        {
            using var db = contextFactory.CreateDbContext();
            var result = db.Update<TEntity>(entity);
            var n = await db.SaveChangesAsync();
            return null;
        }
        catch (Exception ex)
        {
            return ex;
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
}

