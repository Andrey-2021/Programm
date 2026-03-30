namespace Entities.Enums;

/// <summary>
/// Роли
/// </summary>
public enum RoleEnum
{
    /// <summary>
    /// Администратор
    /// </summary>
    [Description("Администратор")]
    Админ =1,

    /// <summary>
    /// Менеджер
    /// </summary>
    [Description("Менеджер")]
    Пользователь =2
}


public class TranslateRoleEnum
{
	public static Dictionary<RoleEnum, string> Roles
	{
		get
		{
			return new Dictionary<RoleEnum, string>()
			{
				[RoleEnum.Админ] = "Администратор",
				[RoleEnum.Пользователь] = "Оператор"
			};
		}
	}
}