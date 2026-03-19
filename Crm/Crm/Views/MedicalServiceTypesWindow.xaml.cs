namespace Crm.Views;

public partial class MedicalServiceTypesWindow : Window, IMedicalServiceTypesView
{
    public MedicalServiceTypesWindow(MedicalServiceTypesViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
