namespace Crm.Views;

public partial class MedicalServicesWindow : Window, IMedicalServicesView
{
    public MedicalServicesWindow()
    {
        InitializeComponent();
        var viewModel = new MedicalServicesViewModel();
        DataContext = viewModel;
    }
}
