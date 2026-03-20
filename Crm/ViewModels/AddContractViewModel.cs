using Entities.Enums;

namespace ViewModels;

public class AddContractViewModel : BaseAddEntityViewModel<Contract>
{
    public IEnumerable<PaymentStatusEnum> PaymentStatusList => Enum.GetValues(typeof(PaymentStatusEnum)).Cast<PaymentStatusEnum>();
    public IEnumerable<ContractStatusEnum> ContractStatusList => Enum.GetValues(typeof(ContractStatusEnum)).Cast<ContractStatusEnum>();


    /// <summary>
    /// Список Групп из БД
    /// </summary>
    public ObservableCollection<Patient>? Patients
    {
        get => patients;
        set
        {
            patients = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<Patient>? patients;

    /// <summary>
    /// Сотрудники
    /// </summary>
    public ObservableCollection<Employee>? Employees
    {
        get => employees;
        set
        {
            employees = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<Employee>? employees;


    /// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="serviceProvider"></param>
	public AddContractViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Task.Run(() => LoadNecessaryDates());
    }

    /// <summary>
	/// Загружаем список Групп из БД
	/// </summary>
	/// <returns></returns>
	protected async Task LoadNecessaryDates()
    {
        IsBusy = true;
        var patientsResult = await repository.GetEntitiesAsync<Patient>();
        if (patientsResult.ex == null)
        {
            Patients = new ObservableCollection<Patient>(patientsResult.data.OrderBy(x => x.LastName));
        }
        else
        {
            Patients?.Clear();

            var view = serviceProvider.GetRequiredService<IMessageWindowView>();
            view.ViewModel.Parametr = "Ошибка при чтении клиентов из БД. Попробуйте выполнить операцию позже или обратитесь к администратору."
                + Environment.NewLine + "Exception:" + patientsResult.ex?.Message
                + Environment.NewLine + "InnerException:" + patientsResult.ex?.InnerException?.Message;
        }


        var employeesResult = await repository.GetEntitiesAsync<Employee>();
        if (employeesResult.ex == null)
        {
            Employees = new ObservableCollection<Employee>(employeesResult.data.OrderBy(x => x.LastName));
        }
        else
        {
            Employees?.Clear();

            var view = serviceProvider.GetRequiredService<IMessageWindowView>();
            view.ViewModel.Parametr = "Ошибка при чтении сотрудников из БД. Попробуйте выполнить операцию позже или обратитесь к администратору."
                + Environment.NewLine + "Exception:" + employeesResult.ex?.Message
                + Environment.NewLine + "InnerException:" + employeesResult.ex?.InnerException?.Message;
        }



        IsBusy = false;
    }
}

