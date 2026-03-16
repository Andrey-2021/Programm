namespace Entities;

using System;

/// <summary>
/// Простой класс, представляющий запись таблицы "Платежи"
/// </summary>
public class Payment
{
    /// <summary>
    /// ID платежа (ключевое поле)
    /// </summary>
    [Key]
    public int PaymentId { get; set; }

    /// <summary>
    /// ID договора
    /// </summary>
    public int ContractId { get; set; }
    public Contract? Contract { get; set; }

    /// <summary>
    /// Дата и время платежа
    /// </summary>
    public DateTime PaymentDate { get; set; }

    /// <summary>
    /// Способ оплаты
    /// </summary>
    public string PaymentMethod { get; set; }

    /// <summary>
    /// Сумма платежа (DECIMAL(12,2))
    /// </summary>
    public decimal PaymentAmount { get; set; }

    /// <summary>
    /// ID транзакции
    /// </summary>
    public string TransactionId { get; set; }

    /// <summary>
    /// Примечания к платежу
    /// </summary>
    public string PaymentNotes { get; set; }
}