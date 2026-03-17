using Crm.Views;
using DbLibrary;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
namespace Crm.ViewModels;

internal class MainWindowViewModel
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

    public MainWindowViewModel()
    {
        CreateDbCommand = new RelayCommand(CreateNewDb);
        ShowAllUsersCommand = new RelayCommand(ShowAllUsers);

        ShowAllPatientsCommand = new RelayCommand(ShowAllPatients);
        ShowAllEmployeesCommand = new RelayCommand(ShowAllEmployees);
        ShowAllMedicalServicesCommand = new RelayCommand(ShowAllMedicalServices);

        ShowAllContractsCommand = new RelayCommand(ShowAllContracts);
        AddContractCommand = new RelayCommand(AddContract);

        ShowAboutProgrammCommand = new RelayCommand(ShowAboutProgramm);
        ShowHelpCommand = new RelayCommand(ShowHelp);
    }

    /// <summary>
	/// Создать новую БД
	/// </summary>
	/// <param name="parametr"></param>
	private async void CreateNewDb(object? parametr)
    {
        var repository = new DbRepository();
        var result = await repository.CreateNewDbAsync();

        if(result.operationResult)
        {
            MessageBox.Show("БД создана");
        }
        else
        {
            MessageBox.Show("Ошибка при создании новой БД. Попробуйте выполнить операцию позже или обратитесь к администратору "
                + Environment.NewLine + "Exception:" + result.ex?.Message
                + Environment.NewLine+ "InnerException:" + result.ex?.InnerException?.Message);
        }
    }

    private void ShowAllUsers(object? parametr)
    {
        //var view = container.GetRequiredService<IUsersView>();
        //view.ShowDialog();
    }

    private void ShowAllPatients(object? parametr)
    {
        var view = new PatientsWindow();
        view.ShowDialog();
    }

    private void ShowAllEmployees(object? parametr)
    {
        var view = new EmployeesWindow();
        view.ShowDialog();
    }

    private void ShowAllMedicalServices(object? parametr)
    {
        var view = new MedicalServicesWindow();
        view.ShowDialog();
    }

    private void ShowAllContracts(object? parametr)
    {
        var view = new ContractsWindow();
        view.ShowDialog();
    }

    private void AddContract(object? parametr)
    {
        var view = new AddContractWindow();
        view.ShowDialog();
    }

    private void ShowHelp(object? parametr)
    {
        //var view = container.GetRequiredService<IHelpView>();
        var view = new HelpWindow();
        view.ShowDialog();
    }

    private async void ShowAboutProgramm(object? parametr)
    {
        //var view = container.GetRequiredService<IAboutProgrammView>();
        var view = new AboutProgrammWindow();
        view.ShowDialog();
        //await view.ShowMAUIPage();
    }
}
