namespace Crm;

public partial class App : Application
{
    /// <summary>
    /// Контейнер (поставщик) сервисов
    /// </summary>
    public IServiceProvider ServiceProvider { get; private set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public App()
    {
        ServiceCollection services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();
    }

    /// <summary>
    /// Начало работы программы
    /// </summary>
    private void OnStartup(object sender, StartupEventArgs e)
    {
        // Настраиваем закрытие программы - приложение работает, пока не будет явно вызвано Application.Shutdown()
        // Статья: https://metanit.com/sharp/wpf/3.2.php
        Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
        
        var checkPasswordWindow = ServiceProvider.GetRequiredService<ICheckLoginView>();
        checkPasswordWindow.ShowDialog(); // Показать окно

        var loginUserService = ServiceProvider.GetService<LoginUserService>();
        if (loginUserService!.RegisteredUser == null)
        { 
            //нет вошедшего пользователя, выходим из программы
            Current.Shutdown(-1);
            return;
        }

        var mainWindow = ServiceProvider.GetRequiredService<IMainWindowView>();
        mainWindow.ShowDialog(); // Показать окно
        Current.Shutdown(0); //Закрываем программу
    }

    /// <summary>
    /// Регистрация в контейнере
    /// </summary>
    private void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton<IDialogService, DialogService>();
        services.AddSingleton<LoginUserService>();
        DbConteinerConfiguration.AddToServiceCollection(services);
        services.AddTransient<DbRepository>();

        // Регистрируем окна
        services.AddTransient<IMainWindowView, MainWindow>();
        services.AddTransient<IAboutProgrammView, AboutProgrammWindow>();
        services.AddTransient<IHelpView, HelpWindow>();
        services.AddTransient<ICheckLoginView, CheckLoginWindow>();

        services.AddTransient<IMedicalServicesView, MedicalServicesWindow>();
        services.AddTransient<IAddMedicalServiceView, AddMedicalServiceWindow>();

        services.AddTransient<IMedicalServiceTypesView, MedicalServiceTypesWindow>();
        services.AddTransient<IAddMedicalServiceTypeView, AddMedicalServiceTypeWindow>();

        services.AddTransient<IAddEmployeesView, AddEmployeesWindow>();
        services.AddTransient<IEmployeesView, EmployeesWindow>();

        services.AddTransient<IContractsView, ContractsWindow>();
        services.AddTransient<IAddContractView, AddContractWindow>();
        services.AddTransient<IAddPaymentForContractView, AddPaymentForContractWindow>();
        services.AddTransient<IAddMedicalServiceForContractView, AddMedicalServiceForContractWindow>();

        services.AddTransient<IPatientsView, PatientsWindow>();
        services.AddTransient<IAddPatientView, AddPatientWindow>();

        services.AddTransient<IAddUserView, AddUserWindow>();
        services.AddTransient<IUsersView, UsersWindow>();

        services.AddTransient<IAddPositionView, AddPositionWindow>();
        services.AddTransient<IPositionsView, PositionsWindow>();

        services.AddTransient<IAddOrganizationInfoView, OrganizationInfoWindow>();

        // Регистрируем ViewModel-и
        services.AddTransient<MessageViewModel>();

        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<AboutProgrammViewModel>();
        services.AddTransient<CheckLoginViewModel>();

        services.AddTransient<PatientsViewModel>();
        services.AddTransient<AddPatientViewModel>();

        services.AddTransient<ContractsViewModel>();
        services.AddTransient<AddContractViewModel>();
        services.AddTransient<AddPaymentForContracViewModel>();
        services.AddTransient<AddMedicalServiceForContractViewModel>();

        services.AddTransient<EmployeesViewModel>();
        services.AddTransient<AddEmployeeViewModel>();

        services.AddTransient<MedicalServicesViewModel>();
        services.AddTransient<AddMedicalServiceViewModel>();

        services.AddTransient<MedicalServiceTypesViewModel>();
        services.AddTransient<AddMedicalServiceTypeViewModel>();

        services.AddTransient<AddUserViewModel>();
        services.AddTransient<UsersViewModel>();

        services.AddTransient<AddPositionViewModel>();
        services.AddTransient<PositionsViewModel>();

        services.AddTransient<AddOrganizationInfoViewModel>();
    }
}
