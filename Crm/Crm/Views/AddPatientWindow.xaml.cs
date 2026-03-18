namespace Crm.Views;

public partial class AddPatientWindow : Window, IAddPatientView
{
    public IViewModelWithParametr ViewModel { get; set; }

    public AddPatientWindow(AddPatientViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = viewModel;
    }
}
