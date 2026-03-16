using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

/// <summary>
/// Простой класс, представляющий запись таблицы "Договоры"
/// </summary>
public class Contract
{
    /// <summary>
    /// ID договора (ключевое поле)
    /// </summary>
    [Key]
    public int ContractId { get; set; }

    /// <summary>
    /// ID пациента
    /// </summary>
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }

    /// <summary>
    /// Дата заключения договора
    /// </summary>
    public DateTime ContractDate { get; set; }

    /// <summary>
    /// Номер договора
    /// </summary>
    public string ContractNumber { get; set; }

    /// <summary>
    /// Дата начала действия договора
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Дата окончания действия договора
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Общая сумма договора
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Общая сумма договора прописью
    /// </summary>
    public string TotalAmountText { get; set; }

    /// <summary>
    /// Статус оплаты
    /// </summary>
    public string PaymentStatus { get; set; }

    /// <summary>
    /// Статус договора
    /// </summary>
    public string ContractStatus { get; set; }

    /// <summary>
    /// Дополнительные примечания к договору
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// ID ответственного сотрудника
    /// </summary>
    [ForeignKey(nameof(Employee))]
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

}