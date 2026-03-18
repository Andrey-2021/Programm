namespace Crm.Views;

public partial class AddPatientWindow : Window, IAddPatientView
{
    public AddPatientWindow()
    {
        InitializeComponent();
        DataContext = new AddPatientViewModel();
    }
}
