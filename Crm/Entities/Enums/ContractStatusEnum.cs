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
    works = 1,

    /// <summary>
    /// Расторгнут
    /// </summary>
    [Description("Расторгнут")]
    terminated = 2,

    /// <summary>
    /// Завершён
    /// </summary>
    [Description("Завершён")]
    completed = 3
}

