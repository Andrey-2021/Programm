namespace Entities;

/// <summary>
/// Сервис выдаёт информацию о вошедшем пользователе.
/// Используется чтобы в программе можно было везде получить информацию о вошедшем пользователе
/// </summary>
public class LoginUserService
{
	/// <summary>
	/// Логин администратора по умолчанию
	/// </summary>
	public const string DefaultAdminLogin = "admin";
    
	/// <summary>
	/// Пароль администратора по умолчанию
	/// </summary>
	public const string DefaultAdminPassword = "1234";
    
	/// <summary>
	/// Пользователь
	/// </summary>
	public RegisteredUser? RegisteredUser { get; private set; }

	/// <summary>
	/// СОздать администратора
	/// </summary>
	/// <param name="login"></param>
	/// <param name="password"></param>
	public void CreateAdmin(string login= DefaultAdminLogin, string password= DefaultAdminPassword)
	{
		RegisteredUser = new() { Login = login, Password = password, Role = RoleEnum.Админ};
	}

	/// <summary>
	/// Установить пользователя
	/// </summary>
	/// <param name="registeredUser"></param>
	public void SetUser(RegisteredUser registeredUser)
	{
		RegisteredUser= registeredUser;
	}
}
