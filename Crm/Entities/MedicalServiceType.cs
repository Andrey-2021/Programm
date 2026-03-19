using System.Runtime.CompilerServices;
namespace Entities;

/// <summary>
/// Вид медицинской услуги
/// </summary>
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
    /// Конструктор с инициализацией наименования вида услуги.
    /// </summary>
    /// <param name="serviceTypeName">Наименование вида услуги.</param>
    public MedicalServiceType(string serviceTypeName)
    {
        Name = serviceTypeName;
    }
}