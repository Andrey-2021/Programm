namespace Entities;

/// <summary>
/// Простой класс, представляющий запись таблицы "Услуги"
/// </summary>
public class MedicalService
{
    /// <summary>
    /// ID услуги (ключевое поле)
    /// </summary>
    [Key]
    public int ServiceId { get; set; }

    /// <summary>
    /// Наименование услуги
    /// </summary>
    public string ServiceName { get; set; }

    /// <summary>
    /// Вид услуги
    /// </summary>
    public string ServiceType { get; set; }

    /// <summary>
    /// Код услуги
    /// </summary>
    public string ServiceCode { get; set; }

    /// <summary>
    /// Стоимость услуги
    /// </summary>
    public decimal ServicePrice { get; set; }
}
