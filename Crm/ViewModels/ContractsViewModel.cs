using CreateDocuments;

namespace ViewModels;

public class ContractsViewModel : BaseAllEntitiesViewModel<Contract, IAddContractView>
{
    /// <summary>
    /// Команда "Добавить платёж"
    /// </summary>
    public RelayCommand? CreateContractCommand { private set; get; }

    /// <summary>
    /// Команда "Добавить платёж"
    /// </summary>
    public ICommand? AddPaymentCommand { private set; get; }

    /// <summary>
    /// Команда "Редактировать платёж"
    /// </summary>
    public ICommand? EditPaymentCommand { private set; get; }

    /// <summary>
    /// Команда "Добавить услугу"
    /// </summary>
    public ICommand? AddMedicalServiceForContectCommand { private set; get; }

    /// <summary>
    /// Команда "Редактировать услугу"
    /// </summary>
    public ICommand? EditMedicalServiceInContectCommand { private set; get; }


    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ContractsViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        CreateContractCommand = new RelayCommand(CreateContract, CheckIsPossibleCreateContract);

        AddPaymentCommand = new RelayCommand(AddPayment, CheckIsPossibleAddPayment);
        EditPaymentCommand = new RelayCommand(EditPayment, CheckIsPossibleEditPayment);

        AddMedicalServiceForContectCommand = new RelayCommand(AddMedicalServiceForContect, CheckIsPossibleAddMedicalServiceForContect);
        EditMedicalServiceInContectCommand = new RelayCommand(EditMedicalServiceInContect, CheckIsPossibleImportEditMedicalServiceInContect);
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
        var view = serviceProvider.GetRequiredService<IMessageWindowView>();
        view.ViewModel.Parametr = "Добавить платёж";
        view.ShowDialog();
    }

    protected virtual bool CheckIsPossibleAddPayment(object? parametr)
    {
        return Entities?.Count > 0;
    }

    protected virtual async void EditPayment(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IMessageWindowView>();
        view.ViewModel.Parametr = "Редактировать платёж";
        view.ShowDialog();
    }

    protected virtual bool CheckIsPossibleEditPayment(object? parametr)
    {
        return true;
    }

    protected virtual async void AddMedicalServiceForContect(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IMessageWindowView>();
        view.ViewModel.Parametr = "Добавить услугу";
        view.ShowDialog();
    }

    protected virtual bool CheckIsPossibleAddMedicalServiceForContect(object? parametr)
    {
        return Entities?.Count > 0;
    }

    protected virtual async void EditMedicalServiceInContect(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<IMessageWindowView>();
        view.ViewModel.Parametr = "Редактировать услугу";
        view.ShowDialog();
    }

    protected virtual bool CheckIsPossibleImportEditMedicalServiceInContect(object? parametr)
    {
        return true;
    }

    protected override async Task<(IEnumerable<Contract> data, Exception? ex)> LoadDataFromDb(DbRepository repository)
    {
        var result = await repository.GetEntitiesAsync<Contract>(include: x=>x.Include(cont=> cont.Patient) //Подгружаем данные о пациенте
                                                                             .Include(cont => cont.Employee), //Подгружаем данные о сотруднике
                                                                             orderBy:x=>x.OrderByDescending(contr=>contr.ContractDate)); // Сортируем по дате заключения договора
        return result;
    }

    protected override void CheckCommands()
    {
        base.CheckCommands();
        CreateContractCommand?.RaiseCanExecuteChanged();
    }
}
