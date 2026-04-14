using Microsoft.Extensions.Configuration;
namespace DbLibrary;

/// <summary>
/// Получить строку с настройками подключения к БД из Json-файла
/// </summary>
public class JSonConnectionString
{
	/// <summary>
	/// Имя Json-файла с конфигурацией подключения к БД
	/// </summary>
	const string settingsFileName = "SQLConnectionSettings.json";

	/// <summary>
	/// Возвращает имя провайдера и строку подключения
	/// </summary>
	/// <returns></returns>
	public static (string? server, string? connectionString) GetConnectionSetting()
	{
		var builder = new ConfigurationBuilder();
		var path = AppDomain.CurrentDomain.BaseDirectory;
		builder.SetBasePath(path);// установка пути к текущему каталогу

		builder.AddJsonFile(settingsFileName);// получаем конфигурацию из файла appsettings.json
		var config = builder.Build();// создаем конфигурацию

		var SQLServer = config.GetSection("UseDb").Value;
		var connectionString = config.GetConnectionString(SQLServer!);
		return (SQLServer, connectionString);
	}
}
