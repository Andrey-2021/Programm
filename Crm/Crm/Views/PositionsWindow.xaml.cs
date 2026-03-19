namespace Crm.Views;

public partial class PositionsWindow : Window, IPositionsView
{
    public PositionsWindow(PositionsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
