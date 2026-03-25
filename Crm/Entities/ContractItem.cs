namespace Entities;

/// <summary>
/// Выбранная медицинская услуга для договора
/// </summary>
public class ContractItem : BaseINotifyDataErrorInfo, IHaveId
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Id договора
    /// </summary>
    /// <remarks>
	/// Внешний ключ. Связь Один-Ко-Многим
	///</remarks>
    [Required(ErrorMessage = "Для оплаты обязательно должна быть указана договор")]
    [Range(1, int.MaxValue, ErrorMessage = "Не выбран договор")]
    [Comment("Id договора")]
    [DisplayName("Id договора")]
    public int ContractId
    {
        get => contractId;
        set
        {
            contractId = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private int contractId;

    /// <summary>
    /// Договор
    /// </summary>
    /// <remarks>
    /// Навигационное свойство. Связь один-ко-многим
    ///</remarks>
    [Comment("Договор")]
    [DisplayName("Договор")]
    public Contract? Contract { get; set; }

    /// <summary>
    /// Id мед. услуги
    /// </summary>
    [Required(ErrorMessage = "Для оплаты обязательно должна быть выбрана мед.услуга")]
    [Range(1, int.MaxValue, ErrorMessage = "Не выбрана мед.услуга")]
    [Comment("Id мед. услуги")]
    [DisplayName("Id мед. услуги")]
    public int MedicalServiceId
    {
        get => medicalServiceId;
        set
        {
            medicalServiceId = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private int medicalServiceId;
    public MedicalService? MedicalService { get; set; }

    /// <summary>
    /// Количество услуг
    /// </summary>
    [Required(ErrorMessage = "Введите количество услуг")]
    [Range(1, (double)LengthConstants.medicalServicesQuantityMaxLength, ErrorMessage = "Недопустимое значение. Должно быть от {1} до {2}")]
    [Comment("Количество услуг")]
    [DisplayName("Количество услуг")]
    public uint Quantity
    {
        get => quantity;
        set
        {
            quantity = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(ItemTotal));
            Validate(value);
        }
    }
    private uint quantity = default!;

    /// <summary>
    /// Цена услуги на момент заключения договора (DECIMAL(10,2))
    /// </summary>
    [Required(ErrorMessage = "Введите цену")]
    [Range(0, (double)LengthConstants.medicalServicesPriceMaxLength, ErrorMessage = "Недопустимое значение. Должно быть от {1} до {2}")]
    [DataType(DataType.Currency)]
    //[Column(TypeName = "decimal(18, 2)")]
    [Comment("Цена услуги")]
    [DisplayName("Цена услуги")]
    public decimal Price
    {
        get => price;
        set
        {
            price = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(ItemTotal));
            Validate(value);
        }
    }
    private decimal price = default!;

    /// <summary>
    /// Скидка
    /// </summary>
    [Required(ErrorMessage = "Введите скидку")]
    [Range(0, (double)LengthConstants.medicalServicesDiscountMaxLength, ErrorMessage = "Недопустимое значение. Должно быть от {1} до {2}")]
    [Column(TypeName = "decimal(8, 2)")]
    [Comment("Скидка")]
    [DisplayName("Скидка")]
    public decimal Discount
    {
        get => discount;
        set
        {
            discount = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(ItemTotal));
            Validate(value);
        }
    }
    private decimal discount = default!;

    /// <summary>
    /// Итого
    /// </summary>
    [NotMapped]
    public decimal ItemTotal => Quantity*Price - Discount;

    /// <summary>
    /// Конструктор
    /// </summary>
    public ContractItem()
    { 
    }

    /// <summary>
    /// Конструктор для инициализации всех свойств, кроме ContractItemId.
    /// </summary>
    public ContractItem(Contract contract, MedicalService service, uint quantity, decimal price, decimal discount)
    {
        Contract = contract;
        MedicalService = service;
        Quantity = quantity;
        Price = price;
        Discount = discount;
    }
}