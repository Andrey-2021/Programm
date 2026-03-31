using Entities.Enums;

namespace Entities;

/// <summary>
/// Сервис выдаёт информацию о вошедшем пользователе.
/// Используется чтобы в программе можно было везде получить информацию о вошедшем пользователе
/// </summary>
public class LiginUserService
{
	public const string DefaultAdminLogin = "admin";
    public const string DefaultAdminPassword = "1234";
    public RegisteredUser? RegisteredUser { get; private set; }

	public void CreateAdmin(string login= DefaultAdminLogin, string password= DefaultAdminPassword)
	{
		RegisteredUser = new() { Login = login, Password = password, Role = RoleEnum.Админ};
	}

	public void SetUser(RegisteredUser registeredUser)
	{
		RegisteredUser= registeredUser;
	}

}
