namespace Crm.Views;

public partial class MedicalServicesWindow : Window
{
    public MedicalServicesWindow()
    {
        InitializeComponent();
        var viewModel = new MedicalServicesViewModel();
        DataContext = viewModel;
    }
}
