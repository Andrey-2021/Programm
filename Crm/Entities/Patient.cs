using Entities.Enums;

namespace Entities;

/// <summary>
/// Пациенты
/// </summary>
[Comment("Пациенты")]
[Index(nameof(Patient.LastName), IsUnique = false)] //Индексируем по Фамилии
public class Patient: BaseINotifyDataErrorInfo, IHaveId
{
    /// <summary>
    /// ID пациента (ключевое поле)
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
	/// Фамилия И.О.
	/// </summary>
	[NotMapped]
    public string? FIO => LastName + " " + FirstName?[0] + "." + MiddleName?[0] + ".";

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
    /// Дата рождения
    /// </summary>
    [Required(ErrorMessage = "Введите дату рождения")]
    [Comment("Дата рождения")]
    [DisplayName("Дата рождения")]
    [Range(typeof(DateTime), "1/1/1900", "1/1/2035", ErrorMessage = "Дата рождения вне диапазона")]
    public DateTime BirthDate
    {
        get => birthDate;
        set
        {
            birthDate = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    public DateTime birthDate;

    /// <summary>
    /// Пол
    /// </summary>
    [Required(ErrorMessage = "Введите пол")]
    [Comment("Пол")]
    [DisplayName("Пол")]
    public GenderEnum? Gender
    {
        get => gender;
        set
        {
            gender = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    public GenderEnum? gender;

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

    /// <summary>
    /// Адрес проживания
    /// </summary>
    [Required(ErrorMessage = "Введите адрес проживания")]
    [StringLength(LengthConstants.addressMaxLength, MinimumLength = LengthConstants.addressMinLength, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
    [Comment("Адрес проживания")]
    [DisplayName("Адрес проживания")]
    public string Address
    {
        get => address;
        set
        {
            address = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    public string address;

    /// <summary>
    /// Серия паспорта
    /// </summary>
    [Required(ErrorMessage = "Введите Серия паспорта")]
    [StringLength(LengthConstants.passportSeriesMaxLength, MinimumLength = LengthConstants.passportSeriesMinLength, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
    [Comment("Серия паспорта")]
    [DisplayName("Серия паспорта")]
    public string PassportSeries
    {
        get => passportSeries;
        set
        {
            passportSeries = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    public string passportSeries;

    /// <summary>
    /// Номер паспорта
    /// </summary>
    [Required(ErrorMessage = "Введите Номер паспорта")]
    [StringLength(LengthConstants.passportNumberMaxLength, MinimumLength = LengthConstants.passportNumberMinLength, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
    [Comment("Номер паспорта")]
    [DisplayName("Номер паспорта")]
    public string PassportNumber
    {
        get => passportNumber;
        set
        {
            passportNumber = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    public string passportNumber;

    /// <summary>
    /// Дата выдачи паспорта
    /// </summary>
    [Required(ErrorMessage = "Введите дату выдачи паспорта")]
    [Comment("Дата выдачи паспорта")]
    [DisplayName("Дата выдачи паспорта")]
    [Range(typeof(DateTime), "1/1/1900", "1/1/2035", ErrorMessage = "Дата выдачи паспорта вне диапазона")]
    public DateTime PassportIssueDate
    {
        get => passportIssueDate;
        set
        {
            passportIssueDate = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    public DateTime passportIssueDate;

    /// <summary>
    /// Орган, выдавший паспорт
    /// </summary>
    [Required(ErrorMessage = "Введите Орган, выдавший паспорт")]
    [StringLength(LengthConstants.passportIssuingAuthorityMaxLength, MinimumLength = LengthConstants.passportIssuingAuthorityMinLength, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
    [Comment("Орган, выдавший паспорт")]
    [DisplayName("Орган, выдавший паспорт")]
    public string PassportIssuingAuthority
    {
        get => passportIssuingAuthority;
        set
        {
            passportIssuingAuthority = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    public string passportIssuingAuthority;

    /// <summary>
    /// Конструктор по умолчанию
    /// </summary>
    public Patient() 
    { }

    /// <summary>
    /// Конструктор для инициализации всех свойств
    /// </summary>
    public Patient( string lastName, string firstName, string middleName, DateTime birthDate,
        GenderEnum gender, string phoneNumber, string email, string address, string passportSeries,
        string passportNumber, DateTime passportIssueDate, string passportIssuingAuthority)
    {
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        BirthDate = birthDate;
        Gender = gender;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
        PassportSeries = passportSeries;
        PassportNumber = passportNumber;
        PassportIssueDate = passportIssueDate;
        PassportIssuingAuthority = passportIssuingAuthority;
    }
}
