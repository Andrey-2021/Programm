namespace Crm.Views;

public partial class EmployeesWindow : Window
{
    public EmployeesWindow()
    {
        InitializeComponent();
        var viewModel = new EmployeesViewModel();
        DataContext = viewModel;
    }
}
