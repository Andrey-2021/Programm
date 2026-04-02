namespace Crm.Views;

public partial class HelpWindow : Window, IHelpView
{
    public HelpWindow()
    {
        InitializeComponent();
    }
    // Методы прокрутки к разделам
    private void ScrollToAdminSection(object sender, RoutedEventArgs e)
    {
        AdminSection.BringIntoView();
    }

    private void ScrollToDirectoriesSection(object sender, RoutedEventArgs e)
    {
        DirectoriesSection.BringIntoView();
    }

    private void ScrollToContractsSection(object sender, RoutedEventArgs e)
    {
        ContractsSection.BringIntoView();
    }

    private void ScrollToHelpSection(object sender, RoutedEventArgs e)
    {
        HelpSection.BringIntoView();
    }

    private void ScrollToExitSection(object sender, RoutedEventArgs e)
    {
        ExitSection.BringIntoView();
    }

    private void ScrollToToolbarSection(object sender, RoutedEventArgs e)
    {
        ToolbarSection.BringIntoView();
    }

    private void ScrollToStatusBarSection(object sender, RoutedEventArgs e)
    {
        StatusBarSection.BringIntoView();
    }
}
