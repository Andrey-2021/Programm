namespace Crm.Views;

public partial class AddPositionWindow : Window, IAddPositionView
{
    public IViewModelWithParametr ViewModel { get; set; }

    public AddPositionWindow(AddPositionViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = viewModel;
    }
}
