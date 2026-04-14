namespace ViewModels;

/// <summary>
/// ViewModel для главного окна
/// </summary>
public class MainWindowViewModel : BaseViewModel
{
    /// <summary>
	/// Команда "Создать новую БД"
	/// </summary>
	public ICommand? CreateDbCommand { get; private set; }

    /// <summary>
	/// Команда "Записать исходные данные в БД"
	/// </summary>
	public ICommand? SaveDataInDbCommand { get; private set; }

    /// <summary>
    /// Команда "Пользователи"
    /// </summary>
    public ICommand? ShowAllUsersCommand { get; private set; }

    /// <summary>
	/// Команда "показать пациентов"
	/// </summary>
	public ICommand? ShowAllPatientsCommand { get; private set; }

    /// <summary>
    /// Команда "показать сотрудников"
    /// </summary>
    public ICommand? ShowAllEmployeesCommand { get; private set; }

    /// <summary>
    /// Команда "показать должности сотрудников"
    /// </summary>
    public ICommand? ShowAllPositionsCommand { get; private set; }

    /// <summary>
	/// Команда "показать услуги"
	/// </summary>
	public ICommand? ShowAllMedicalServicesCommand { get; private set; }

    /// <summary>
	/// Команда "показать Вид медицинских услуги"
	/// </summary>
	public ICommand? ShowAllMedicalServicetypesCommand { get; private set; }

    
    /// <summary>
    /// Команда "Информация о медицинской организации"
    /// </summary>
    public ICommand? ShowOrganizationInfoCommand { get; private set; }

    /// <summary>
	/// Команда "показать услуги"
	/// </summary>
	public ICommand? ShowAllContractsCommand { get; private set; }

    /// <summary>
	/// Команда "показать услуги"
	/// </summary>
	public ICommand? AddContractCommand { get; private set; }

    /// <summary>
	/// Команда "Показать помощь"
	/// </summary>
	public ICommand? ShowHelpCommand { get; private set; }

    /// <summary>
    /// Команда "Показать информацию о программе"
    /// </summary>
    public ICommand? ShowAboutProgrammCommand { get; private set; }

    /// <summary>
    /// Команда "Выход"
    /// </summary>
    public ICommand? ExitCommand { get; private set; }

    /// <summary>
	/// Флаг что это администратор
	/// </summary>
	public bool IsAdmin { get; set; }

    public MainWindowViewModel(IServiceProvider serviceProvider, IDialogService dialogService):base(serviceProvider, dialogService)
    {
        var loginUserService = serviceProvider.GetService<LoginUserService>();
        if (loginUserService != null && loginUserService.RegisteredUser != null)
            IsAdmin = loginUserService!.RegisteredUser?.Role == Entities.Enums.RoleEnum.Админ;


        CreateDbCommand = new RelayCommand(CreateNewDb);
        SaveDataInDbCommand = new RelayCommand(SaveDataInDb);
        ShowAllUsersCommand = new RelayCommand(ShowAllUsers);

        ShowAllPatientsCommand = new RelayCommand(ShowAllPatients);
        ShowAllEmployeesCommand = new RelayCommand(ShowAllEmployees);
        ShowAllMedicalServicesCommand = new RelayCommand(ShowAllMedicalServices);
        ShowAllMedicalServicetypesCommand = new RelayCommand(ShowAllMedicalServicetypes);
        ShowAllPositionsCommand = new RelayCommand(ShowAllPositionsServices);
        ShowOrganizationInfoCommand = new RelayCommand(ShowOrganizationInfo);

        ShowAllContractsCommand = new RelayCommand(ShowAllContracts);
        AddContractCommand = new RelayCommand(AddContract);

        ShowAboutProgrammCommand = new RelayCommand(ShowAboutProgramm);
        ShowHelpCommand = new RelayCommand(ShowHelp);

        ExitCommand = new RelayCommand( _=>Environment.Exit(0));

        StatusService.SetMessage("Программа открыта.");
    }

    /// <summary>
	/// Создать новую БД
	/// </summary>
	/// <param name="parametr"></param>
	private async void CreateNewDb(object? parametr)
    {
        var result = await repository.CreateNewDbAsync();
        if (result.operationResult == false) //если ошибка
            dialogService.ShowError("Ошибка при создании новой БД. Попробуйте выполнить операцию позже или обратитесь к администратору.", exception: result.ex);
        else
            dialogService.ShowInfo("БД создана");
    }

    /// <summary>
	/// Записать данные в БД
	/// </summary>
	private async void SaveDataInDb(object? parametr)
    {
        var result = await repository.SaveInitDataInDbAsync();
        if (result.operationResult == false) //если ошибка
            dialogService.ShowError("Ошибка при записи данных а БД. Попробуйте выполнить операцию позже или обратитесь к администратору.", exception: result.ex);
        else
            dialogService.ShowInfo("Данные записаны в БД");
    }

    private void ShowAllUsers(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IUsersView>();
        view.ShowDialog();
    }

    private void ShowAllPatients(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IPatientsView>();
        view.ShowDialog();
    }

    private void ShowAllEmployees(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IEmployeesView>();
        view.ShowDialog();
    }

    private void ShowAllMedicalServices(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IMedicalServicesView>();
        view.ShowDialog();
    }

    private void ShowAllMedicalServicetypes(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IMedicalServiceTypesView>();
        view.ShowDialog();
    }
    
    private void ShowAllPositionsServices(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IPositionsView>();
        view.ShowDialog();
    }
    
    private void ShowOrganizationInfo(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IAddOrganizationInfoView>();
        view.ShowDialog();
    }

    private void ShowAllContracts(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IContractsView>();
        view.ShowDialog();
    }

    private void AddContract(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IAddContractView>();
        view.ShowDialog();
    }

    private void ShowHelp(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IHelpView>();
        view.ShowDialog();
    }

    private async void ShowAboutProgramm(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IAboutProgrammView>();
        view.ShowDialog();
    }
}
