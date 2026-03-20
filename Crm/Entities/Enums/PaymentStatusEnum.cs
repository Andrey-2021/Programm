namespace Entities.Enums;

/// <summary>
/// Статус оплаты
/// </summary>
public enum PaymentStatusEnum
{
    /// <summary>
    /// Не оплачен
    /// </summary>
    [Description("Не оплачен")]
    unpaid = 1,

    /// <summary>
    /// Оплачен
    /// </summary>
    [Description("Оплачен")]
    paid = 2,

    /// <summary>
    /// Оплачен частично
    /// </summary>
    [Description("Оплачен частично")]
    partiallyPaid = 3
}

