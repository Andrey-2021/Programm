namespace Crm.Views;

public partial class AddPatientWindow : Window
{
    public AddPatientWindow()
    {
        InitializeComponent();
        DataContext = new AddPatientViewModel();
    }
}
