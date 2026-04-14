namespace ViewModels;

public class AddContractViewModel : BaseAddEntityViewModel<Contract>
{
    /// <summary>
    /// Списое перечислений "Статус оплаты"
    /// </summary>
    public IEnumerable<PaymentStatusEnum> PaymentStatusList => Enum.GetValues(typeof(PaymentStatusEnum)).Cast<PaymentStatusEnum>();

    /// <summary>
    /// Список перечислений "Статус договора"
    /// </summary>
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
	public AddContractViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
        var task = Task.Run(() => LoadNecessaryDates());
        task.Wait();
    }

    /// <summary>
	/// Загружаем данных из БД
	/// </summary>
	/// <returns></returns>
	protected async Task LoadNecessaryDates()
    {
        IsPrgBusy = true;
        var patientsResult = await repository.GetEntitiesAsync<Patient>();
        if (patientsResult.ex == null)
            Patients = new ObservableCollection<Patient>(patientsResult.data.OrderBy(x => x.LastName));
        else
        {
            Patients?.Clear();
            dialogService.ShowError("Ошибка при чтении клиентов из БД. Попробуйте выполнить операцию позже или обратитесь к администратору.", exception: patientsResult.ex);
        }

        var employeesResult = await repository.GetEntitiesAsync<Employee>();
        if (employeesResult.ex == null)
            Employees = new ObservableCollection<Employee>(employeesResult.data.OrderBy(x => x.LastName));
        else
        {
            Employees?.Clear();
            dialogService.ShowError("Ошибка при чтении сотрудников из БД. Попробуйте выполнить операцию позже или обратитесь к администратору.", exception: employeesResult.ex);
        }
        IsPrgBusy = false;
    }

    protected override async Task<bool> OperationBeforeSave()
    {
        MainEntity!.Patient = null;
        MainEntity!.Employee = null;
        return true;
    }

    protected override void ClearData(object? parametr)
    {
        if (MainEntity == null)
            return;

        MainEntity.ContractNumber = string.Empty;
        MainEntity.ContractDate = DateTime.Now;
        MainEntity.StartDate = DateTime.Now;
        MainEntity.EndDate = DateTime.Now;
        MainEntity.PaymentStatus = null;
        MainEntity.ContractStatus = null;
        MainEntity.Notes = String.Empty;

        MainEntity.PatientId = 0;
        MainEntity.Patient = null;

        MainEntity.EmployeeId = 0;
        MainEntity.Employee = null;
    }

}

