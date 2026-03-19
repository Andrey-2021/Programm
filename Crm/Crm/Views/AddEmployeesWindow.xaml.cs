namespace Crm.Views;

public partial class AddEmployeesWindow : Window, IAddEmployeesView
{
    public IViewModelWithParametr ViewModel { get; set; }

    public AddEmployeesWindow(AddEmployeeViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = viewModel;
    }
}
