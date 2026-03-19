namespace Crm.Views;

public partial class ContractsWindow : Window, IContractsView
{
    public ContractsWindow(ContractsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
