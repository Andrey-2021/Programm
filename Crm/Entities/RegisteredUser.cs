using Entities.Enums;
namespace Entities;

/// <summary>
/// Данные вводимые при регистрации пользователя
/// </summary>
public class RegisteredUser : BaseINotifyDataErrorInfo, IHaveId
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

	/// <summary>
	/// Login
	/// </summary>
	[Required(ErrorMessage = "Обязательно должна быть введен логин")]
    [StringLength(LengthConstants.loginMaxLength, MinimumLength = LengthConstants.loginMinLength, ErrorMessage = "Длина логина должна быть не менее {2} и не более {1} символов")]
    [Comment("Логин")]
    [DisplayName("Логин")]
    public string Login
	{
		get => login;
		set
		{
			login = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private string login=string.Empty;

	/// <summary>
	/// Пароль
	/// </summary>
	[Required(ErrorMessage = "Обязательно должна быть введен пароль")]
    [StringLength(LengthConstants.passwordMaxLength, MinimumLength = LengthConstants.passwordMinLength, ErrorMessage = "Длина пароля должна быть не менее {2} и не более {1} символов")]
    [Comment("Пароль")]
    [DisplayName("Пароль")]
    public string Password
	{
		get => password;
		set
		{
			password = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private string password = string.Empty;

	/// <summary>
	/// Повторный пароль
	/// </summary>
	[NotMapped]
	[Compare("Password", ErrorMessage ="Пароли не совпадают ")]
    [Comment("Повторный пароль")]
    [DisplayName("Повторный пароль")]
    public string? ConfirmedPassword
	{
		get => confirmedPassword;
		set
		{
			confirmedPassword = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private string? confirmedPassword;

	/// <summary>
	/// Роль
	/// </summary>
	[Required(ErrorMessage = "Обязательно должна быть указана роль")]
	[Comment("Роль")]
    [DisplayName("Роль")]
    public RoleEnum? Role
	{
		get => role;
		set
		{
			role = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private RoleEnum? role;

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public RegisteredUser() 
	{ 
	}

    /// <summary>
    /// Конструктор с инициализацией.
    /// </summary>
    public RegisteredUser(string login, string password, RoleEnum role)
    {
        Login = login;
		Password = password;
		Role = role;
    }
}
