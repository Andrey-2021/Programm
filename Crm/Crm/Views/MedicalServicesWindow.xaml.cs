namespace Crm.Views;

public partial class MedicalServicesWindow : Window, IMedicalServicesView
{
    public MedicalServicesWindow(MedicalServicesViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
