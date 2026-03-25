using CreateDocuments;
namespace ViewModels;

public class ContractsViewModel : BaseAllEntitiesViewModel<Contract, IAddContractView>
{
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
    public ContractItem? selectedContractItem;

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
    public Payment? selectedPayment;

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
    /// Конструктор
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ContractsViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        CreateContractCommand = new RelayCommand(CreateContract, CheckIsPossibleCreateContract);

        AddPaymentCommand = new RelayCommand(AddPayment, CheckIsPossibleAddPayment);
        EditPaymentCommand = new RelayCommand(EditPayment, CheckIsPossibleEditPayment);
        DeletePaymentCommand = new RelayCommand(DeletePaymentPayment, CheckIsPossibleDeletePayment);

        AddMedicalServiceForContectCommand = new RelayCommand(AddMedicalServiceForContect, CheckIsPossibleAddMedicalServiceForContect);
        EditMedicalServiceInContectCommand = new RelayCommand(EditMedicalServiceInContect, CheckIsPossibleEditMedicalServiceInContect);
        DeleteMedicalServiceInContectCommand = new RelayCommand(DeleteMedicalServiceInContect, CheckIsPossibleDeleteMedicalServiceInContect);
    }

    protected async void CreateContract(object? parametr)
    {
        var replacements = new Dictionary<string, string>
{
    { "!1!", "Иванов Иван Иванович" },
    { "!2!", "20.03.2026" },
    { "!3!", "№ 123-А" }
};
        WordReplacer.ReplacePlaceholders(@"d:\1\dogovor.docx", replacements);
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
        StatusMessage = "Данные прочитаны. " + DateTime.Now;
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
        StatusMessage = "Данные прочитаны. " + DateTime.Now;
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
        StatusMessage = "Данные прочитаны. " + DateTime.Now;
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
        StatusMessage = "Данные прочитаны. " + DateTime.Now;
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
        var result = await repository.GetAllInfoAboutContractsAsync();
        return result;
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
    }
}
