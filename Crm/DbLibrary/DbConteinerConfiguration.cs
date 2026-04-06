namespace DbLibrary;

/// <summary>
/// Добавляем БД в контейнер
/// </summary>
public class DbConteinerConfiguration
{
	/// <summary>
	/// Добавляем контекст MsSQL или MySQL в качестве сервиса в приложение
	/// </summary>
	public static void AddToServiceCollection(IServiceCollection services)
	{
		var connectionConfig = JSonConnectionString.GetConnectionSetting();

        // Для БД MSSQL и MySQL настраиваем работу с БД
        switch (connectionConfig.server.ToUpper())
		{
			case "MSSQL": // Если это БД MSSQL
				services.AddDbContextFactory<SqlDbContext>(options => options.UseSqlServer(connectionConfig.connectionString, options => { options.EnableRetryOnFailure(); }));
				break;
			case "MYSQL": // Если это БД MySQL
                services.AddDbContextFactory<SqlDbContext>(options => options.UseMySQL(connectionConfig.connectionString));
				break;
			default:
				throw new Exception("Нет настроенной БД");
		}
	}
}
