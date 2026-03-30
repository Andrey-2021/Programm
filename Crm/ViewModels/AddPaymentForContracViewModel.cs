using Entities.Enums;
namespace ViewModels;

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
}
