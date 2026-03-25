namespace Entities.Enums;

/// <summary>
/// Способ оплаты
/// </summary>
public enum PaymentMethodEnum
{
    /// <summary>
    /// Наличные
    /// </summary>
    [Description("Наличные")]
    наличные = 1,

    /// <summary>
    /// Банковская карта
    /// </summary>
    [Description("Банковская карта")]
    банковская_карта = 2,

    /// <summary>
    /// Банковский перевод
    /// </summary>
    [Description("Банковский перевод")]
    банковский_перевод = 3
}

