namespace Crm.Views;

public partial class OrganizationInfoWindow : Window, IAddOrganizationInfoView
{
    public IViewModelWithParametr ViewModel { get; set; }

    public OrganizationInfoWindow(AddOrganizationInfoViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = viewModel;
    }
}
