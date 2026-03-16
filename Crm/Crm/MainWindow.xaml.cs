using Crm.ViewModels;
using InitDb;
using System.Windows;
namespace Crm;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var viewModel =new MainWindowViewModel();
        DataContext = viewModel;
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                await db.Database.EnsureDeletedAsync();
                var rezult=await db.Database.EnsureCreatedAsync();
                if(rezult)
                {
                    var patients = PatientSeeder.GetSamplePatients();
                    await db.Patients.AddRangeAsync(patients);
                    await db.SaveChangesAsync();
                }
            }
            MessageBox.Show("БД создана");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка: "+ex.Message 
                + Environment.NewLine+ " InnerException:" + ex.InnerException?.Message);
        }
    }
}