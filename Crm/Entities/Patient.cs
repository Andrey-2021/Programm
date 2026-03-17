namespace Entities;

/// <summary>
/// Пациенты
/// </summary>
public class Patient
{
    /// <summary>
    /// ID пациента (ключевое поле)
    /// </summary>
    [Key]
    public int PatientId { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required(ErrorMessage = "Введите фамилию")]
    [StringLength(LengthConstants.lastNameMaxLength, MinimumLength = LengthConstants.lastNameMinLength, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
    [Comment("Фамилия")]
    [DisplayName("Фамилия")]
    public string LastName { get; set; } = default!;

    /// <summary>
    /// Имя
    /// </summary>
    [Required(ErrorMessage = "Введите имя")]
    [StringLength(LengthConstants.firstNameMaxLength, MinimumLength = LengthConstants.firstNameMinLength, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
    [Comment("Имя")]
    [DisplayName("Имя")]
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Отчество
    /// </summary>
    [Required(ErrorMessage = "Введите отчество")]
    [StringLength(LengthConstants.middleNameMaxLength, MinimumLength = LengthConstants.middleNameMinLength, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
    [Comment("Отчество")]
    [DisplayName("Отчество")]
    public string MiddleName { get; set; } = default!;

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public string Gender { get; set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Электронная почта
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Адрес проживания
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Серия паспорта
    /// </summary>
    public string PassportSeries { get; set; }

    /// <summary>
    /// Номер паспорта
    /// </summary>
    public string PassportNumber { get; set; }

    /// <summary>
    /// Дата выдачи паспорта
    /// </summary>
    public DateTime PassportIssueDate { get; set; }

    /// <summary>
    /// Орган, выдавший паспорт
    /// </summary>
    public string PassportIssuingAuthority { get; set; }

    /// <summary>
    /// Конструктор по умолчанию
    /// </summary>
    public Patient() 
    { }

    /// <summary>
    /// Конструктор для инициализации всех свойств
    /// </summary>
    public Patient( string lastName, string firstName, string middleName, DateTime birthDate,
        string gender, string phoneNumber, string email, string address, string passportSeries,
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
