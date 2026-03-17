namespace Crm.Views;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
        DataContext = new LoginViewModel();
        //ViewModel = viewModel;
    }
}
