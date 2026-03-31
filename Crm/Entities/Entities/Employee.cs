namespace Entities;

/// <summary>
/// Простой класс, представляющий запись таблицы "Сотрудники"
/// </summary>
[Comment("Сотрудники")]
[Index(nameof(Employee.LastName), IsUnique = false)] // Индексируем по фамилии
public class Employee : BaseINotifyDataErrorInfo, IHaveId
{
    /// <summary>
    /// Id сотрудника (ключевое поле)
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
	/// Фамилия И.О.
	/// </summary>
	[NotMapped]
    public string? FIO => LastName + " " 
        + (String.IsNullOrEmpty(FirstName)?null: FirstName[0] + ".")
        + (String.IsNullOrEmpty(MiddleName) ? null : MiddleName[0] + ".");

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required(ErrorMessage = "Введите фамилию")]
    [StringLength(LengthConstants.lastNameMaxLength, MinimumLength = LengthConstants.lastNameMinLength, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
    [Comment("Фамилия")]
    [DisplayName("Фамилия")]
    public string LastName
    {
        get => lastName;
        set
        {
            lastName = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    public string lastName = string.Empty;

    /// <summary>
    /// Имя
    /// </summary>
    [Required(ErrorMessage = "Введите имя")]
    [StringLength(LengthConstants.firstNameMaxLength, MinimumLength = LengthConstants.firstNameMinLength, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
    [Comment("Имя")]
    [DisplayName("Имя")]
    public string FirstName
    {
        get => firstName;
        set
        {
            firstName = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    public string firstName = string.Empty;

    /// <summary>
    /// Отчество
    /// </summary>
    [Required(ErrorMessage = "Введите отчество")]
    [StringLength(LengthConstants.middleNameMaxLength, MinimumLength = LengthConstants.middleNameMinLength, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
    [Comment("Отчество")]
    [DisplayName("Отчество")]
    public string MiddleName
    {
        get => middleName;
        set
        {
            middleName = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    public string middleName=string.Empty;

    /// <summary>
    /// ID Должности
    /// </summary>
    /// <remarks>
	/// Внешний ключ. Связь Один-Ко-Многим
	///</remarks>
    [Required(ErrorMessage = "Для сотрудника обязательно должна быть указана должность")]
    [Range(1, int.MaxValue, ErrorMessage = "Не выбрана должность")]
    [Comment("ID должности")]
    [DisplayName("ID должности")]
    public int PositionId
    {
        get => positionId;
        set
        {
            positionId = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private int positionId;

    /// <summary>
    /// Должность
    /// </summary>
	/// <remarks>
	/// Навигационное свойство. Связь один-ко-многим
	///</remarks>
    [Comment("Должность")]
    [DisplayName("Должность")]
    public Position? Position
    {
        get => position;
        set
        {
            position = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private Position? position;

    /// <summary>
    /// Номер телефона
    /// </summary>
    [Phone(ErrorMessage = "Неверный формат телефона")]
    [Required(ErrorMessage = "Введите телефон")]
    [StringLength(LengthConstants.phonetMaxLength, MinimumLength = LengthConstants.phonetMinLength, ErrorMessage = "Длина номера телефона должна быть не менее {2} и не более {1} символов")]
    [Comment("Телефон")]
    [DisplayName("Телефон")]
    public string PhoneNumber
    {
        get => phoneNumber;
        set
        {
            phoneNumber = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    public string phoneNumber=String.Empty;

    /// <summary>
    /// Электронная почта
    /// </summary>
    [EmailAddress(ErrorMessage = "Неверный формат e-mail")]
    [MaxLength(LengthConstants.emailMaxLength, ErrorMessage = "Длина e-mail должна быть не более {1} символов")]
    [Comment("e-mail")]
    public string? Email
    {
        get => email;
        set
        {
            email = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    public string? email;

    public Employee()
    { 
    }

    /// <summary>
    /// Конструктор для инициализации
    /// </summary>
    public Employee(string lastName, string firstName, string middleName,
                    Position position, string phoneNumber, string email)
    {
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        Position = position;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}