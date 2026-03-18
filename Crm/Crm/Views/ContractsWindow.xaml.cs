namespace Crm.Views;

public partial class ContractsWindow : Window, IContractsView
{
    public ContractsWindow()
    {
        InitializeComponent();
        var viewModel = new ContractsViewModel();
        DataContext = viewModel;
    }
}
