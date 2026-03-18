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
    public string lastName;

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
    public string firstName;

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
    public string middleName;

    /// <summary>
    /// Должность
    /// </summary>
    [Required(ErrorMessage = "Введите должность")]
    [StringLength(LengthConstants.positionMaxLength, MinimumLength = LengthConstants.positionMinLength, ErrorMessage = "Длина названия должности должна быть не менее {2} и не более {1} символов")]
    [Comment("Должность")]
    [DisplayName("Должность")]
    public string Position
    {
        get => position;
        set
        {
            position = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private string position;

    /// <summary>
    /// Номер телефона
    /// </summary>
    [Phone(ErrorMessage = "Неверный формат телефона")]
    [Required(ErrorMessage = "Введите телефон")]
    [StringLength(LengthConstants.phonetMaxLength, MinimumLength = LengthConstants.phonetMinLength, ErrorMessage = "Длина номера телефона должна быть не менее {2} и не более {1} символов")]
    //[MaxLength(LengthConstants.phonetMaxLength, ErrorMessage = "Длина № телефона должна быть не более {1} символов")]
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
    public string phoneNumber;

    /// <summary>
    /// Электронная почта
    /// </summary>
    [EmailAddress(ErrorMessage = "Неверный формат e-mail")]
    [Required(ErrorMessage = "Обязательно должен быть введен e-mail")]
    [MaxLength(LengthConstants.emailMaxLength, ErrorMessage = "Длина e-mail должна быть не более {1} символов")]
    [Comment("e-mail")]
    public string Email
    {
        get => email;
        set
        {
            email = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    public string email;

    public Employee()
    { 
    }

    /// <summary>
    /// Конструктор для инициализации всех свойств, кроме EmployeeId.
    /// </summary>
    public Employee(string lastName, string firstName, string middleName,
                    string position, string phoneNumber, string email)
    {
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        Position = position;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}