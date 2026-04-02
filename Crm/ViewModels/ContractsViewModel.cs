using CreateDocuments;
namespace ViewModels;

public class ContractsViewModel : BaseAllEntitiesViewModel<Contract, IAddContractView>
{
    /// <summary>
    /// Фильтр
    /// </summary>
    public FilterData FilterData
    {
        get => filterData;
        set
        {
            filterData = value;
            OnPropertyChanged();
        }
    }
    private FilterData filterData = new();

    public IEnumerable<PaymentStatusEnum> PaymentStatusList => Enum.GetValues(typeof(PaymentStatusEnum)).Cast<PaymentStatusEnum>();
    public IEnumerable<ContractStatusEnum> ContractStatusList => Enum.GetValues(typeof(ContractStatusEnum)).Cast<ContractStatusEnum>();

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
    private ObservableCollection<Employee>? employees;

    /// <summary>
    /// Выбранная услуга из таблицы оказанных услуг
    /// </summary>
    public ContractItem? SelectedContractItem
    {
        get => selectedContractItem;
        set
        {
            selectedContractItem = value;
            OnPropertyChanged();
        }
    }
    private ContractItem? selectedContractItem;

    /// <summary>
    /// Выбранный платёж из таблицы платежей
    /// </summary>
    public Payment? SelectedPayment
    {
        get => selectedPayment;
        set
        {
            selectedPayment = value;
            OnPropertyChanged();
        }
    }
    private Payment? selectedPayment;

    /// <summary>
    /// Команда "Добавить платёж"
    /// </summary>
    public RelayCommand? CreateContractCommand { private set; get; }

    /// <summary>
    /// Команда "Добавить платёж"
    /// </summary>
    public RelayCommand? AddPaymentCommand { private set; get; }

    /// <summary>
    /// Команда "Редактировать платёж"
    /// </summary>
    public RelayCommand? EditPaymentCommand { private set; get; }

    /// <summary>
    /// Команда "Удалить платёж"
    /// </summary>
    public RelayCommand? DeletePaymentCommand { private set; get; }

    /// <summary>
    /// Команда "Добавить услугу"
    /// </summary>
    public RelayCommand? AddMedicalServiceForContectCommand { private set; get; }

    /// <summary>
    /// Команда "Редактировать услугу"
    /// </summary>
    public RelayCommand? EditMedicalServiceInContectCommand { private set; get; }

    /// <summary>
    /// Команда "Удалить услугу"
    /// </summary>
    public RelayCommand? DeleteMedicalServiceInContectCommand { private set; get; }

    /// <summary>
    /// Команда "Очистить фильтр"
    /// </summary>
    public RelayCommand? ClearFilterCommand { private set; get; }

    /// <summary>
    /// Команда "Отфильровать"
    /// </summary>
    public RelayCommand? FilterCommand { private set; get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ContractsViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
        CreateContractCommand = new RelayCommand(CreateContract, CheckIsPossibleCreateContract);

        AddPaymentCommand = new RelayCommand(AddPayment, CheckIsPossibleAddPayment);
        EditPaymentCommand = new RelayCommand(EditPayment, CheckIsPossibleEditPayment);
        DeletePaymentCommand = new RelayCommand(DeletePaymentPayment, CheckIsPossibleDeletePayment);

        AddMedicalServiceForContectCommand = new RelayCommand(AddMedicalServiceForContect, CheckIsPossibleAddMedicalServiceForContect);
        EditMedicalServiceInContectCommand = new RelayCommand(EditMedicalServiceInContect, CheckIsPossibleEditMedicalServiceInContect);
        DeleteMedicalServiceInContectCommand = new RelayCommand(DeleteMedicalServiceInContect, CheckIsPossibleDeleteMedicalServiceInContect);

        ClearFilterCommand = new RelayCommand(ClearFilter, CheckIsPossibleClearFilter);
        FilterCommand = new RelayCommand(ToFilter, CheckIsPossibleToFilter);

        var task = Task.Run(() => LoadEmployees());
        task.Wait();
    }

    /// <summary>
    /// Очистить фильтр
    /// </summary>
    protected async void ClearFilter(object? parametr)
    {
        FilterData = new();
        await LoadNecessaryDates();
    }

    protected bool CheckIsPossibleClearFilter(object? parametr)
    {
        return true;
    }

    /// <summary>
    /// Отфильтровать
    /// </summary>
    protected async void ToFilter(object? parametr)
    {
        await LoadNecessaryDates();
    }

    /// <summary>
    /// Можно ли выполнить команду
    /// </summary>
    protected bool CheckIsPossibleToFilter(object? parametr)
    {
        return true;
    }

    protected async void CreateContract(object? parametr)
    {
        var folder = dialogService.SelectFolder();
        if (folder is null)
            return;

        IsBusy = true;
        var repository = this.serviceProvider.GetRequiredService<DbRepository>();
        var result = await repository.GetFirstOrDefaultAsync<OrganizationInfo>();

        if (result.ex is not null)
        {
            dialogService.ShowError("Ошибка при чтении данных. Попробуйте выполнить операцию позже или обратитесь к администратору.", exception: result.ex);
            return;
        }

        var createDocResult = MegicalApprovalDocument.CreateDoc(SelectedEntity!, result.entity!, folder);
        if (createDocResult.ex is null)
            dialogService.ShowInfo("Документы созданы");
        else
            dialogService.ShowError("Ошибка при создании документов: ", exception: createDocResult.ex);
        IsBusy = false;
    }

    protected bool CheckIsPossibleCreateContract(object? parametr)
    {
        return SelectedEntity != null;
    }

    protected virtual async void AddPayment(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IAddPaymentForContractView>();
        view.ViewModel.Parametr = new Payment() { ContractId = SelectedEntity!.Id, Contract = SelectedEntity };
        view.ShowDialog();
        await LoadNecessaryDates();
    }

    private bool CheckIsPossibleAddPayment(object? parametr)
    {
        return SelectedEntity != null;
    }

    private async void EditPayment(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IAddPaymentForContractView>();
        view.ViewModel.Parametr = SelectedPayment;
        view.ShowDialog();
        await LoadNecessaryDates();
    }

    private bool CheckIsPossibleEditPayment(object? parametr)
    {
        return SelectedPayment != null;
    }

    private async void DeletePaymentPayment(object? parametr)
    {
        await Delete(SelectedPayment!);
    }

    private bool CheckIsPossibleDeletePayment(object? parametr)
    {
        return SelectedPayment != null;
    }

    protected virtual async void AddMedicalServiceForContect(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IAddMedicalServiceForContractView>();
        view.ViewModel.Parametr = new ContractItem() { ContractId = SelectedEntity!.Id, Contract = SelectedEntity };
        view.ShowDialog();
        await LoadNecessaryDates();
    }

    protected virtual bool CheckIsPossibleAddMedicalServiceForContect(object? parametr)
    {
        return SelectedEntity != null;
    }

    protected virtual async void EditMedicalServiceInContect(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IAddMedicalServiceForContractView>();
        view.ViewModel.Parametr = SelectedContractItem;
        view.ShowDialog();
        await LoadNecessaryDates();
    }

    protected virtual bool CheckIsPossibleEditMedicalServiceInContect(object? parametr)
    {
        return selectedContractItem != null;
    }

    protected virtual async void DeleteMedicalServiceInContect(object? parametr)
    {
        await Delete(selectedContractItem!);
    }

    protected virtual bool CheckIsPossibleDeleteMedicalServiceInContect(object? parametr)
    {
        return selectedContractItem != null;
    }

    protected override async Task<(IEnumerable<Contract> data, Exception? ex)> LoadDataFromDb(DbRepository repository)
    {
        var filter = FilterData?.GetFilter();
        return await repository.GetAllInfoAboutContractsAsync(filter);
    }

    protected override void CheckCommands()
    {
        base.CheckCommands();
        CreateContractCommand?.RaiseCanExecuteChanged();

        AddMedicalServiceForContectCommand?.RaiseCanExecuteChanged();
        EditMedicalServiceInContectCommand?.RaiseCanExecuteChanged();
        DeleteMedicalServiceInContectCommand?.RaiseCanExecuteChanged();

        AddPaymentCommand?.RaiseCanExecuteChanged();
        EditPaymentCommand?.RaiseCanExecuteChanged();
        DeletePaymentCommand?.RaiseCanExecuteChanged();

        ClearFilterCommand?.RaiseCanExecuteChanged();
        FilterCommand?.RaiseCanExecuteChanged();
    }

    /// <summary>
	/// Загружаем сотрудников из БД
	/// </summary>
	protected async Task LoadEmployees()
    {
        IsBusy = true;
        var employeesResult = await repository.GetEntitiesAsync<Employee>();
        if (employeesResult.ex == null)
            Employees = new ObservableCollection<Employee>(employeesResult.data.OrderBy(x => x.LastName));
        else
        {
            Employees?.Clear();
            dialogService.ShowError("Ошибка при чтении сотрудников из БД. Попробуйте выполнить операцию позже или обратитесь к администратору.", exception: employeesResult.ex);
        }
        IsBusy = false;
    }
}
