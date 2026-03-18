namespace Crm.Views;

public partial class LoginWindow : Window, ILoginView
{
    public LoginWindow()
    {
        InitializeComponent();
        DataContext = new LoginViewModel();
        //ViewModel = viewModel;
    }
}
