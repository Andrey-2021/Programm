using Entities.Enums;
namespace InitDb;

public static class UserSeeder
{
    /// <summary>
    /// Возвращает список с заранее определёнными данными
    /// </summary>
    public static List<RegisteredUser> GetSampleUsers()
    {
        var users = new List<RegisteredUser>();
        users.Add(new RegisteredUser("admin","1234", RoleEnum.Админ));
        users.Add(new RegisteredUser("manager", "1234", RoleEnum.Пользователь));
        return users;
    }
}
