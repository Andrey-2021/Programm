using System.ComponentModel.DataAnnotations.Schema;
namespace Entities;

/// <summary>
/// Договоры
/// </summary>
[Comment("Договоры")]
[Index(nameof(ContractNumber), IsUnique = true)]           // Номер договора уникален
[Index(nameof(PatientId), IsUnique = false)]               // Индекс по пациенту
[Index(nameof(EmployeeId), IsUnique = false)]              // Индекс по сотруднику
[Index(nameof(ContractDate), IsUnique = false)]            // Индекс по дате заключения
public class Contract : BaseINotifyDataErrorInfo, IHaveId
{
    /// <summary>
    /// ID договора (ключевое поле)
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// ID пациента
    /// </summary>
    [Required(ErrorMessage = "Не указан пациент")]
    [ForeignKey(nameof(Patient))]
    [Comment("Идентификатор пациента")]
    [DisplayName("ID пациента")]
    public int PatientId
    {
        get => patientId;
        set
        {
            patientId = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private int patientId;

    /// <summary>
    /// Пациент
    /// </summary>
    [Required(ErrorMessage = "Не указан пациент")]
    [Comment("Пациент")]
    [DisplayName("Пациент")]
    public Patient? Patient
    {
        get => patient;
        set
        {
            patient = value;
            OnPropertyChanged();
            if (value != null)
            {
                PatientId = value.Id; // синхронизация внешнего ключа
            }
        }
    }
    private Patient? patient;


    /// <summary>
    /// Дата заключения договора
    /// </summary>
    [Required(ErrorMessage = "Введите дату заключения договора")]
    [DataType(DataType.Date)]
    [Comment("Дата заключения договора")]
    [DisplayName("Дата заключения")]
    [Range(typeof(DateTime), "1/1/2000", "1/1/2035", ErrorMessage = "Дата заключения вне допустимого диапазона")]
    public DateTime ContractDate
    {
        get => contractDate;
        set
        {
            contractDate = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private DateTime contractDate;

    /// <summary>
    /// Номер договора
    /// </summary>
    [Required(ErrorMessage = "Введите номер договора")]
    [StringLength(LengthConstants.contractNumberMaxLength, MinimumLength = LengthConstants.contractNumberMinLength, ErrorMessage = "Длина номера договора должна быть не менее {2} и не более {1} символов")]
    [Comment("Номер договора")]
    [DisplayName("Номер договора")]
    public string ContractNumber
    {
        get => contractNumber;
        set
        {
            contractNumber = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private string contractNumber = string.Empty;

    /// <summary>
    /// Дата начала действия договора
    /// </summary>
    [Required(ErrorMessage = "Введите дату начала действия")]
    [DataType(DataType.Date)]
    [Comment("Дата начала")]
    [DisplayName("Дата начала")]
    [Range(typeof(DateTime), "1/1/2000", "1/1/2035", ErrorMessage = "Дата начала вне допустимого диапазона")]
    public DateTime StartDate
    {
        get => startDate;
        set
        {
            startDate = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private DateTime startDate;

    /// <summary>
    /// Дата окончания действия договора
    /// </summary>
    [Required(ErrorMessage = "Введите дату окончания действия")]
    [DataType(DataType.Date)]
    [Comment("Дата окончания")]
    [DisplayName("Дата окончания")]
    [Range(typeof(DateTime), "1/1/2000", "1/1/2035", ErrorMessage = "Дата окончания вне допустимого диапазона")]
    //todo - переделать валидацию - [CustomValidation(typeof(Contract), ValidateData.ValidateEndDate)]
    public DateTime EndDate
    {
        get => endDate;
        set
        {
            endDate = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private DateTime endDate;

    /// <summary>
    /// Общая сумма договора
    /// </summary>
    [Required(ErrorMessage = "Введите общую сумму договора")]
    [Range(0.01, 9999999999.99, ErrorMessage = "Сумма должна быть от 0.01 до 9 999 999 999.99")]
    [DataType(DataType.Currency)]
    [Comment("Общая сумма")]
    [DisplayName("Общая сумма")]
    public decimal TotalAmount
    {
        get => totalAmount;
        set
        {
            totalAmount = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private decimal totalAmount;

    /// <summary>
    /// Общая сумма договора прописью
    /// </summary>
    [Required(ErrorMessage = "Введите сумму прописью")]
    [StringLength(LengthConstants.totalAmountTextMaxLength, MinimumLength = LengthConstants.totalAmountTextMinLength, ErrorMessage = "Длина текста суммы должна быть не менее {2} и не более {1} символов")]
    [Comment("Сумма прописью")]
    [DisplayName("Сумма прописью")]
    public string TotalAmountText
    {
        get => totalAmountText;
        set
        {
            totalAmountText = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private string totalAmountText = string.Empty;

    /// <summary>
    /// Статус оплаты
    /// </summary>
    [Required(ErrorMessage = "Введите статус оплаты")]
    [StringLength(LengthConstants.paymentStatusMaxLength, MinimumLength = LengthConstants.paymentStatusMinLength, ErrorMessage = "Длина статуса оплаты должна быть не менее {2} и не более {1} символов")]
    [Comment("Статус оплаты")]
    [DisplayName("Статус оплаты")]
    public string PaymentStatus
    {
        get => paymentStatus;
        set
        {
            paymentStatus = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private string paymentStatus = string.Empty;

    /// <summary>
    /// Статус договора
    /// </summary>
    [Required(ErrorMessage = "Введите статус договора")]
    [StringLength(LengthConstants.contractStatusMaxLength, MinimumLength = LengthConstants.contractStatusMinLength, ErrorMessage = "Длина статуса договора должна быть не менее {2} и не более {1} символов")]
    [Comment("Статус договора")]
    [DisplayName("Статус договора")]
    public string ContractStatus
    {
        get => contractStatus;
        set
        {
            contractStatus = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private string contractStatus = string.Empty;

    /// <summary>
    /// Дополнительные примечания к договору
    /// </summary>
    [StringLength(LengthConstants.notesMaxLength, ErrorMessage = "Длина примечаний не должна превышать {1} символов")]
    [Comment("Примечания")]
    [DisplayName("Примечания")]
    public string Notes
    {
        get => notes;
        set
        {
            notes = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private string notes = string.Empty;


    /// <summary>
    /// ID ответственного сотрудника
    /// </summary>
    [Required(ErrorMessage = "Не указан ответственный сотрудник")]
    [ForeignKey(nameof(Employee))]
    [Comment("Идентификатор ответственного")]
    [DisplayName("ID ответственного")]
    public int EmployeeId
    {
        get => employeeId;
        set
        {
            employeeId = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private int employeeId;



    /// <summary>
    /// Ответственный сотрудник
    /// </summary>
    [Required(ErrorMessage = "Не указан ответственный сотрудник")]
    [Comment("Ответственный")]
    [DisplayName("Ответственный")]
    public Employee? Employee
    {
        get => employee;
        set
        {
            employee = value;
            OnPropertyChanged();
            if (value != null)
            {
                EmployeeId = value.Id;
            }
        }
    }
    private Employee? employee;

    public Contract()
    { }

    /// <summary>
    /// Конструктор для инициализации всех свойств, кроме ContractId.
    /// </summary>
    public Contract(Patient patient, DateTime contractDate, string contractNumber, DateTime startDate,
                    DateTime endDate, decimal totalAmount, string totalAmountText, string paymentStatus,
                    string contractStatus, string notes, Employee responsibleEmployee)
    {
        Patient = patient;
        ContractDate = contractDate;
        ContractNumber = contractNumber;
        StartDate = startDate;
        EndDate = endDate;
        TotalAmount = totalAmount;
        TotalAmountText = totalAmountText;
        PaymentStatus = paymentStatus;
        ContractStatus = contractStatus;
        Notes = notes;
        Employee = responsibleEmployee;
    }
}