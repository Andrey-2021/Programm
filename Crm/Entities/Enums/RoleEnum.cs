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
    admin =1,

    /// <summary>
    /// Менеджер
    /// </summary>
    [Description("Менеджер")]
    manager =2
}


public class TranslateRoleEnum
{
	public static Dictionary<RoleEnum, string> Roles
	{
		get
		{
			return new Dictionary<RoleEnum, string>()
			{
				[RoleEnum.admin] = "Администратор",
				[RoleEnum.manager] = "Оператор"
			};
		}
	}
}