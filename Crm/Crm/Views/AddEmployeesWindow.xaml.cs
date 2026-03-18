namespace Crm.Views;

public partial class AddEmployeesWindow : Window, IAddEmployeesView
{
    public AddEmployeesWindow()
    {
        InitializeComponent();
        DataContext = new AddEmployeeViewModel();
    }
}
