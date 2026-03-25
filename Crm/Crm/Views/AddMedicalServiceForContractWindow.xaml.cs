namespace Crm.Views;

public partial class AddMedicalServiceForContractWindow : Window, IAddMedicalServiceForContractView
{
    public IViewModelWithParametr ViewModel { get; set; }

    public AddMedicalServiceForContractWindow(AddMedicalServiceForContractViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = viewModel;
    }
}
