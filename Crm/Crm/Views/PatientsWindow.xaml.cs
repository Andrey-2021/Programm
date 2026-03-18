namespace Crm.Views;
public partial class PatientsWindow : Window, IPatientsView
{
    public PatientsWindow(PatientsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
