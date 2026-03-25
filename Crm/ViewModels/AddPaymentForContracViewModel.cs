using Entities.Enums;
namespace ViewModels;

public class AddPaymentForContracViewModel : BaseAddEntityViewModel<Payment>
{
    public IEnumerable<PaymentMethodEnum> PaymentMethodList => Enum.GetValues(typeof(PaymentMethodEnum)).Cast<PaymentMethodEnum>();

    /// <summary>
	/// Конструктор
	/// </summary>
	public AddPaymentForContracViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override void OperationBeforeSave()
    {
        MainEntity!.Contract = null;
    }
}
