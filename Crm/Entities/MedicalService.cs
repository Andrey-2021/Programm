using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Entities;

/// <summary>
/// Медицинские услуги
/// </summary>
[Comment("Медицинские услуги")]
[Index(nameof(MedicalService.ServiceName), IsUnique = false)] // Индексируем по наименованию услуги
public class MedicalService : BaseINotifyDataErrorInfo, IHaveId
{
    /// <summary>
    /// ID услуги (ключевое поле)
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
    /// Вид услуги
    /// </summary>
    [Required(ErrorMessage = "Введите вид услуги")]
    [StringLength(LengthConstants.serviceTypeMaxLength, MinimumLength = LengthConstants.serviceTypeMinLength, ErrorMessage = "Длина вида услуги должна быть не менее {2} и не более {1} символов")]
    [Comment("Вид услуги")]
    [DisplayName("Вид услуги")]
    public string ServiceType
    {
        get => serviceType;
        set
        {
            serviceType = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private string serviceType = default!;

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
    /// Стоимость услуги
    /// </summary>
    [Required(ErrorMessage = "Введите стоимость услуги")]
    [Range(0.01, 9999999.99, ErrorMessage = "Стоимость должна быть положительной и не превышать 9 999 999.99")]
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
    public MedicalService(string serviceName, string serviceType, string serviceCode, decimal servicePrice)
    {
        ServiceName = serviceName;
        ServiceType = serviceType;
        ServiceCode = serviceCode;
        ServicePrice = servicePrice;
    }
}
