namespace Entities;

/// <summary>
/// Вид медицинской услуги
/// </summary>
[Comment("Вид медицинской услуги")]
public class MedicalServiceType : BaseINotifyDataErrorInfo, IHaveId
{
    /// <summary>
    /// Id
    /// </summary>
    /// <remarks>
    /// Связь один-ко-многим с MedicalService
    ///</remarks>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Наименование вида услуги.
    /// </summary>
    [Required(ErrorMessage = "Введите наименование вида услуги")]
    [StringLength(LengthConstants.serviceTypeNameMaxLength, MinimumLength = LengthConstants.serviceTypeNameMinLength, ErrorMessage = "Длина наименования должна быть не менее {2} и не более {1} символов")]
    [Comment("Наименование вида услуги")]
    [DisplayName("Наименование вида услуги")]
    public string Name
    {
        get => name;
        set
        {
            name = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private string name = string.Empty;

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public MedicalServiceType() { }

    /// <summary>
    /// Конструктор с инициализацией
    /// </summary>
    /// <param name="serviceTypeName">Наименование вида услуги</param>
    public MedicalServiceType(string serviceTypeName)
    {
        Name = serviceTypeName;
    }
}