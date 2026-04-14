namespace ViewModels;

/// <summary>
/// ViewModel для окна ввода данных об оплате для догвора
/// </summary>
public class AddPaymentForContracViewModel : BaseAddEntityViewModel<Payment>
{
    public IEnumerable<PaymentMethodEnum> PaymentMethodList => Enum.GetValues(typeof(PaymentMethodEnum)).Cast<PaymentMethodEnum>();

    /// <summary>
	/// Конструктор
	/// </summary>
	public AddPaymentForContracViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
    }

    protected override async Task<bool> OperationBeforeSave()
    {
        MainEntity!.Contract = null;
        return true;
    }

    protected override void ClearData(object? parametr)
    {
        if (MainEntity == null)
            return;
        MainEntity.PaymentDate = DateTime.Now;
        MainEntity.PaymentMethod = null;
        MainEntity.PaymentAmount = 0;
        MainEntity.TransactionId = string.Empty;
        MainEntity.PaymentNotes = string.Empty;
    }
}
