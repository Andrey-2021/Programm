namespace Entities;

/// <summary>
/// Медицинские услуги
/// </summary>
[Comment("Медицинские услуги")]
[Index(nameof(MedicalService.ServiceName), IsUnique = false)] // Индексируем по наименованию услуги
public class MedicalService : BaseINotifyDataErrorInfo, IHaveId
{
    /// <summary>
    /// Id услуги (ключевое поле)
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Наименование услуги
    /// </summary>
    [Required(ErrorMessage = "Введите наименование услуги")]
    [StringLength(LengthConstants.serviceNameMaxLength, MinimumLength = LengthConstants.serviceNameMinLength, ErrorMessage = "Длина наименования должна быть не менее {2} и не более {1} символов")]
    [Comment("Наименование услуги")]
    [DisplayName("Наименование услуги")]
    public string ServiceName
    {
        get => serviceName;
        set
        {
            serviceName = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private string serviceName = default!;

    /// <summary>
    /// Код услуги
    /// </summary>
    [Required(ErrorMessage = "Введите код услуги")]
    [StringLength(LengthConstants.serviceCodeMaxLength, MinimumLength = LengthConstants.serviceCodeMinLength, ErrorMessage = "Длина кода услуги должна быть не менее {2} и не более {1} символов")]
    [Comment("Код услуги")]
    [DisplayName("Код услуги")]
    public string ServiceCode
    {
        get => serviceCode;
        set
        {
            serviceCode = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private string serviceCode = default!;

    /// <summary>
    /// Id вид медицинской услуги
    /// </summary>
    /// <remarks>
	/// Внешний ключ. Связь Один-Ко-Многим
	///</remarks>
    [Required(ErrorMessage = "Для сотрудника обязательно должна быть указана должность")]
    [Range(1, int.MaxValue, ErrorMessage = "Не выбрана должность")]
    [Comment("Id вид медицинской услуги")]
    [DisplayName("Id вид медицинской услуги")]
    public int MedicalServiceTypeId
    {
        get => medicalServiceTypeId;
        set
        {
            medicalServiceTypeId = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private int medicalServiceTypeId;

    /// <summary>
    /// Вид медицинской услуги
    /// </summary>
	/// <remarks>
	/// Навигационное свойство. Связь один-ко-многим
	///</remarks>
    [Comment("Вид медицинской услуги")]
    [DisplayName("Вид медицинской услуги")]
    public MedicalServiceType? MedicalServiceType
    {
        get => medicalServiceType;
        set
        {
            medicalServiceType = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private MedicalServiceType? medicalServiceType;

    /// <summary>
    /// Стоимость услуги
    /// </summary>
    [Required(ErrorMessage = "Введите стоимость услуги")]
    [Range(0, (double)LengthConstants.servicePriceMaxLength, ErrorMessage = "Недопустимое значение. Должно быть от {1} до {2}")]
    [DataType(DataType.Currency)]
    //[Column(TypeName = "decimal(18, 2)")]
    [Comment("Стоимость услуги")]
    [DisplayName("Стоимость услуги")]
    public decimal ServicePrice
    {
        get => servicePrice;
        set
        {
            servicePrice = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private decimal servicePrice = default!;

    public MedicalService()
    { }

    /// <summary>
    /// Конструктор для инициализации свойств (без ServiceId).
    /// </summary>
    public MedicalService(string serviceName, MedicalServiceType serviceType, string serviceCode, decimal servicePrice)
    {
        ServiceName = serviceName;
        MedicalServiceType = serviceType;
        ServiceCode = serviceCode;
        ServicePrice = servicePrice;
    }
}
