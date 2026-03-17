namespace Crm.Views;

public partial class ContractsWindow : Window
{
    public ContractsWindow()
    {
        InitializeComponent();
        var viewModel = new ContractsViewModel();
        DataContext = viewModel;
    }
}
