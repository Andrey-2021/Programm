namespace Entities;

/// <summary>
/// Должность
/// </summary>
public class Position : BaseINotifyDataErrorInfo, IHaveId
{
    /// <summary>
    /// Id
    /// </summary>
    /// <remarks>
    /// Связь один-ко-многим с Employee
    ///</remarks>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Должность
    /// </summary>
    [Required(ErrorMessage = "Введите должность")]
    [StringLength(LengthConstants.positionNameMaxLength, MinimumLength = LengthConstants.positionNameMinLength, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
    [Comment("Должность")]
    [DisplayName("Должность")]
    public string PositionName
    {
        get => positionName;
        set
        {
            positionName = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    public string positionName=string.Empty;

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public Position() { }

    /// <summary>
    /// Конструктор с инициализацией названия должности.
    /// </summary>
    /// <param name="positionName">Название должности.</param>
    public Position(string positionName)
    {
        PositionName = positionName;
    }
}
