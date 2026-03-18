namespace Crm.Views;
public partial class PatientsWindow : Window, IPatientsView
{
    public PatientsWindow()
    {
        InitializeComponent();
        DataContext = new PatientsViewModel();
    }
}
