using Crm.Views;
using DbLibrary;
using Microsoft.EntityFrameworkCore;
using UniverApp.Views;
namespace Crm;

public partial class App : Application
{
    public IServiceProvider ServiceProvider { get; private set; }

    public App()
    {
        ServiceCollection services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();
    }

    private void OnStartup(object sender, StartupEventArgs e)
    {
        //Disable shutdown when the dialog closes
        Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

        /*
        var checkPasswordWindow = serviceProvider.GetRequiredService<ICheckLoginView>();
        checkPasswordWindow.ShowDialog();

        var loginUserService = serviceProvider.GetService<LiginUserService>();
        if (loginUserService!.RegisteredUser == null)
        { //нет вошедшего пользователя, выходим из программы
            Current.Shutdown(-1);
            return;
        }
        */


        var mainWindow = ServiceProvider.GetRequiredService<IMainWindowView>();
        mainWindow.ShowDialog();
        Current.Shutdown(0);
    }

    private void ConfigureServices(ServiceCollection services)
    {
        string connectionString = "Data Source = WIN10PC; Initial Catalog =MedicalCRM ; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        services.AddDbContextFactory<SqlDbContext>
                (
                    options => options.UseSqlServer(connectionString
                                                    // описание  EnableRetryOnFailure -  https://makolyte.com/how-to-do-retries-in-ef-core/
                                                    , options => { options.EnableRetryOnFailure(); }
                                                    )
                    );

        services.AddTransient<DbRepository>();
        services.AddTransient<IMessageWindowView, MessageWindow>();


        // Регистрируем окна
        services.AddTransient<IMainWindowView, MainWindow>();
        services.AddTransient<IAboutProgrammView, AboutProgrammWindow>();
        services.AddTransient<IAddContractView, AddContractWindow>();
        services.AddTransient<IAddEmployeesView, AddEmployeesWindow>();
        services.AddTransient<IAddMedicalServiceView, AddMedicalServiceWindow>();

        services.AddTransient<IAddPatientView, AddPatientWindow>();
        services.AddTransient<IAddPaymentView, AddPaymentWindow>();
        services.AddTransient<IContractsView, ContractsWindow>();
        services.AddTransient<IEmployeesView, EmployeesWindow>();

        services.AddTransient<IHelpView, HelpWindow>();
        services.AddTransient<ILoginView, LoginWindow>();

        services.AddTransient<IMedicalServicesView, MedicalServicesWindow>();
        services.AddTransient<IPatientsView, PatientsWindow>();

        services.AddTransient<IAddUserView, AddUserWindow>();
        services.AddTransient<IUsersView, UsersWindow>();

        services.AddTransient<IAddPositionView, AddPositionWindow>();
        services.AddTransient<IPositionsView, PositionsWindow>();

        // Регистрируем ViewModel-и
        services.AddTransient<MessageViewModel>();

        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<AboutProgrammViewModel>();
        //services.AddTransient<AddContractViewModel>();
        //services.AddTransient<AddEmployeesWindowViewModel>();
        //services.AddTransient<AddMedicalServiceViewModel>();

        services.AddTransient<AddPatientViewModel>();
        //services.AddTransient<AddPaymentViewModel>();
        services.AddTransient<ContractsViewModel>();
        services.AddTransient<EmployeesViewModel>();

        //services.AddTransient<HelpViewModel>();
        services.AddTransient<LoginViewModel>();

        services.AddTransient<MedicalServicesViewModel>();
        services.AddTransient<PatientsViewModel>();

        services.AddTransient<AddUserViewModel>();
        services.AddTransient<UsersViewModel>();

        services.AddTransient<AddPositionViewModel>();
        services.AddTransient<PositionsViewModel>();
    }
}
