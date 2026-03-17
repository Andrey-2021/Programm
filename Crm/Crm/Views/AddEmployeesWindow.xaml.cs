namespace Crm.Views;

public partial class AddEmployeesWindow : Window
{
    public AddEmployeesWindow()
    {
        InitializeComponent();
        DataContext = new AddEmployeeViewModel();
    }
}
