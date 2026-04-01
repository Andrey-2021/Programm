namespace Entities;
using Entities.Enums;
using System;

/// <summary>
/// Платежи
/// </summary>
[Comment("Платежи по договору")]
[Index(nameof(ContractId), IsUnique = false)] // Индекс
public class Payment : BaseINotifyDataErrorInfo, IHaveId
{
    /// <summary>
    /// ID платежа (ключевое поле)
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
    public Contract? Contract
    {
        get => contract;
        set
        {
            contract = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private Contract? contract;

    /// <summary>
    /// Дата платежа
    /// </summary>
    [Required(ErrorMessage = "Введите дату платежа")]
    [Comment("Дата платежа")]
    [DisplayName("Дата платежа")]
    [Range(typeof(DateTime), "1/1/1900", "1/1/2035", ErrorMessage = "Дата платежа вне диапазона")]
    public DateTime PaymentDate
    {
        get => paymentDate;
        set
        {
            paymentDate = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    public DateTime paymentDate = DateTime.Now;

    /// <summary>
    /// Способ оплаты
    /// </summary>
    [Required(ErrorMessage = "Введите способ оплаты")]
    [Comment("Способ оплаты")]
    [DisplayName("Способ оплаты")]
    public PaymentMethodEnum? PaymentMethod
    {
        get => paymentMethod;
        set
        {
            paymentMethod = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    public PaymentMethodEnum? paymentMethod;

    /// <summary>
    /// Сумма платежа
    /// </summary>
    [Required(ErrorMessage = "Введите сумму платежа")]
    [Range(0, (double)LengthConstants.paymentAmountMaxLength, ErrorMessage = "Недопустимое значение. Должно быть от {1} до {2}")]
    [DataType(DataType.Currency)]
    [Comment("Сумма платежа")]
    [DisplayName("Сумма платежа")]
    public decimal PaymentAmount
    {
        get => paymentAmount;
        set
        {
            paymentAmount = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private decimal paymentAmount = default!;

    /// <summary>
    /// Id транзакции
    /// </summary>
    [Required(ErrorMessage = "Введите Id транзакции")]
    [StringLength(LengthConstants.transactionIdMaxLength, MinimumLength = LengthConstants.transactionIdMinLength, ErrorMessage = "Длина наименования должна быть не менее {2} и не более {1} символов")]
    [Comment("Id транзакции")]
    [DisplayName("Id транзакции")]
    public string TransactionId
    {
        get => transactionId;
        set
        {
            transactionId = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private string transactionId = default!;

    /// <summary>
    /// Примечания к платежу
    /// </summary>
    [MaxLength(LengthConstants.paymentNotesMaxLength, ErrorMessage = "Примечание должно быть не более {1} символов")]
    [Comment("Примечания к платежу")]
    [DisplayName("Примечания к платежу")]
    public string? PaymentNotes
    {
        get => paymentNotes;
        set
        {
            paymentNotes = value;
            OnPropertyChanged();
            Validate(value);
        }
    }
    private string? paymentNotes = default!;

    public Payment()
    { 
    }

    /// <summary>
    /// Конструктор для инициализации всех свойств, кроме PaymentId.
    /// </summary>
    public Payment(Contract contract, DateTime paymentDate, PaymentMethodEnum paymentMethod,
                   decimal paymentAmount, string transactionId, string paymentNotes)
    {
        Contract = contract;
        PaymentDate = paymentDate;
        PaymentMethod = paymentMethod;
        PaymentAmount = paymentAmount;
        TransactionId = transactionId;
        PaymentNotes = paymentNotes;
    }
}