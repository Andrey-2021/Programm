namespace Entities.Enums;

/// <summary>
/// Статус договора
/// </summary>
public enum ContractStatusEnum
{
    /// <summary>
    /// Действует
    /// </summary>
    [Description("Действует")]
    Действует = 1,

    /// <summary>
    /// Расторгнут
    /// </summary>
    [Description("Расторгнут")]
    Расторгнут = 2,

    /// <summary>
    /// Завершён
    /// </summary>
    [Description("Завершён")]
    Завершён = 3
}

