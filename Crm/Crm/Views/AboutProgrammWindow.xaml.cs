namespace Crm.Views;

public partial class AboutProgrammWindow : Window, IAboutProgrammView
{
    public AboutProgrammWindow()
    {
        InitializeComponent();
        DataContext = new AboutProgrammViewModel();
    }
}
