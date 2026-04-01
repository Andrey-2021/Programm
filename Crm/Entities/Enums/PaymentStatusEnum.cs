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
    Не_оплачен = 1,

    /// <summary>
    /// Оплачен
    /// </summary>
    [Description("Оплачен")]
    Оплачен = 2,

    /// <summary>
    /// Оплачен частично
    /// </summary>
    [Description("Оплачен частично")]
    Оплачен_частично = 3
}

