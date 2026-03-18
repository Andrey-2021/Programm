using Microsoft.Identity.Client;

namespace ViewModels;

public class MainWindowViewModel
{
    /// <summary>
	/// Команда "Создать новую БД"
	/// </summary>
	public ICommand? CreateDbCommand { get; private set; }

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
	/// Команда "показать услуги"
	/// </summary>
	public ICommand? ShowAllMedicalServicesCommand { get; private set; }

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


    private IServiceProvider container;

    public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        this.container = serviceProvider;

        CreateDbCommand = new RelayCommand(CreateNewDb);
        ShowAllUsersCommand = new RelayCommand(ShowAllUsers);

        ShowAllPatientsCommand = new RelayCommand(ShowAllPatients);
        ShowAllEmployeesCommand = new RelayCommand(ShowAllEmployees);
        ShowAllMedicalServicesCommand = new RelayCommand(ShowAllMedicalServices);

        ShowAllContractsCommand = new RelayCommand(ShowAllContracts);
        AddContractCommand = new RelayCommand(AddContract);

        ShowAboutProgrammCommand = new RelayCommand(ShowAboutProgramm);
        ShowHelpCommand = new RelayCommand(ShowHelp);

        ExitCommand = new RelayCommand( _=>Environment.Exit(0));
    }

    /// <summary>
	/// Создать новую БД
	/// </summary>
	/// <param name="parametr"></param>
	private async void CreateNewDb(object? parametr)
    {
        //var repository = new DbRepository();
        //var result = await repository.CreateNewDbAsync();

        //if(result.operationResult)
        //{
        //    MessageBox.Show("БД создана");
        //}
        //else
        //{
        //    MessageBox.Show("Ошибка при создании новой БД. Попробуйте выполнить операцию позже или обратитесь к администратору "
        //        + Environment.NewLine + "Exception:" + result.ex?.Message
        //        + Environment.NewLine+ "InnerException:" + result.ex?.InnerException?.Message);
        //}

        var repository = container.GetRequiredService<DbRepository>();
        var result = await repository.CreateNewDbAsync();

        var view = container.GetRequiredService<IMessageWindowView>();
        if (result.operationResult == false) //если ошибка
            view.ViewModel.Parametr = "Ошибка при создании новой БД. Попробуйте выполнить операцию позже или обратитесь к администратору."
                + Environment.NewLine + "Exception:" + result.ex?.Message
                + Environment.NewLine+ "InnerException:" + result.ex?.InnerException?.Message;
        else
            view.ViewModel.Parametr = "БД создана";
        view.ShowDialog();
    }

    private void ShowAllUsers(object? parametr)
    {
        var view = container.GetRequiredService<IUsersView>();
        view.ShowDialog();
    }

    private void ShowAllPatients(object? parametr)
    {
        var view = container.GetRequiredService<IPatientsView>();
        view.ShowDialog();
    }

    private void ShowAllEmployees(object? parametr)
    {
        var view = container.GetRequiredService<IEmployeesView>();
        view.ShowDialog();
    }

    private void ShowAllMedicalServices(object? parametr)
    {
        var view = container.GetRequiredService<IMedicalServicesView>();
        view.ShowDialog();
    }

    private void ShowAllContracts(object? parametr)
    {
        var view = container.GetRequiredService<IContractsView>();
        view.ShowDialog();
    }

    private void AddContract(object? parametr)
    {
        var view = container.GetRequiredService<IAddContractView>();
        view.ShowDialog();
    }

    private void ShowHelp(object? parametr)
    {
        var view = container.GetRequiredService<IHelpView>();
        view.ShowDialog();
    }

    private async void ShowAboutProgramm(object? parametr)
    {
        var view = container.GetRequiredService<IAboutProgrammView>();
        view.ShowDialog();
    }
}
