namespace Crm.Views;

public partial class EmployeesWindow : Window, IEmployeesView
{
    public EmployeesWindow(EmployeesViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
