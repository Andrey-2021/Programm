namespace Crm.Views;

public partial class AddContractWindow : Window, IAddContractView
{
    public IViewModelWithParametr ViewModel { get; set; }

    public AddContractWindow(AddContractViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = viewModel;
    }

    private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {

    }
}
