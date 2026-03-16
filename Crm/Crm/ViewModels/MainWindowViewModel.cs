using Crm.Views;
using System.ComponentModel;
using System.Windows.Input;
namespace Crm.ViewModels;

internal class MainWindowViewModel
{
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

    public MainWindowViewModel()
    {
        ShowAllPatientsCommand = new RelayCommand(ShowAllPatients);
        ShowAllEmployeesCommand = new RelayCommand(ShowAllEmployees);
        ShowAllMedicalServicesCommand = new RelayCommand(ShowAllMedicalServices);

        ShowAllContractsCommand = new RelayCommand(ShowAllContracts);
        AddContractCommand = new RelayCommand(AddContract);
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
}
