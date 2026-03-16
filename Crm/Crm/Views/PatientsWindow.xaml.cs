using Crm.ViewModels;
using System.Windows;
namespace Crm.Views;

public partial class PatientsWindow : Window
{
    public PatientsWindow()
    {
        InitializeComponent();
        var viewModel =new PatientsViewModel();
        DataContext = viewModel;
    }
}
