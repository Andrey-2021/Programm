namespace Crm.Views;


public partial class AddMedicalServiceTypeWindow : Window, IAddMedicalServiceTypeView
{
    public IViewModelWithParametr ViewModel { get; set; }

    public AddMedicalServiceTypeWindow(AddMedicalServiceTypeViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = viewModel;
    }
}
