namespace Crm.Views;

public partial class AddPaymentForContractWindow : Window, IAddPaymentForContractView
{
    public IViewModelWithParametr ViewModel { get; set; }

    public AddPaymentForContractWindow(AddPaymentForContracViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = viewModel;
    }
}
