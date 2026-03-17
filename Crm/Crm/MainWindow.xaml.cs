namespace Crm;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var viewModel =new MainWindowViewModel();
        DataContext = viewModel;
    }
}