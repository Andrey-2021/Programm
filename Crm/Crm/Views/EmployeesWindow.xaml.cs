using Entities;

namespace Crm.Views;

public partial class EmployeesWindow : Window, IEmployeesView
{
    public EmployeesWindow()
    {
        InitializeComponent();
        var viewModel = new EmployeesViewModel();
        DataContext = viewModel;
    }
}
