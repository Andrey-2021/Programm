using System.ComponentModel.DataAnnotations;

namespace ViewModels;

public class AddMedicalServiceForContractViewModel : BaseAddEntityViewModel<ContractItem>//, IDataErrorInfo
{
    /// <summary>
    /// Выбранная мед.услуга
    /// </summary>
    [Required(ErrorMessage = "Выберите мед.услугу")]
    public MedicalService? SelectedMedicalService
    {
        get => selectedMedicalService;
        set
        {
            selectedMedicalService = value;

            MainEntity.MedicalServiceId = selectedMedicalService.Id;
            MainEntity.MedicalService = selectedMedicalService;
            MainEntity.Quantity = 1;
            MainEntity.Price = selectedMedicalService.ServicePrice;
            MainEntity.Discount = 0;
            OnPropertyChanged();
        }
    }
    public MedicalService? selectedMedicalService;

    //#region Вылидация для SelectedMedicalService
    //public string Error => throw new NotImplementedException();
    //public string this[string columnName] => SelectedMedicalService==null?"Не выбрали мед.услугу":String.Empty;
    //#endregion

    /// <summary>
    /// Список медицинских услуг из БД
    /// </summary>
    public ObservableCollection<MedicalService>? MedicalServices
    {
        get => medicalServices;
        set
        {
            medicalServices = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<MedicalService>? medicalServices;

    /// <summary>
	/// Конструктор
	/// </summary>
	public AddMedicalServiceForContractViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    /// <summary>
	/// Загружаем список Групп из БД
	/// </summary>
	/// <returns></returns>
	protected override async Task LoadNecessaryDates()
    {
        IsBusy = true;
        var result = await repository.GetEntitiesAsync<MedicalService>();
        if (result.ex == null)
        {
            MedicalServices = new ObservableCollection<MedicalService>(result.data.OrderBy(x => x.ServiceName));
            //if(MainEntity?.MedicalServiceId>0)
            //    SelectedMedicalService = MedicalServices.FirstOrDefault(x => x.Id == MainEntity.MedicalServiceId);
        }
        else
        {
            MedicalServices?.Clear();

            var view = serviceProvider.GetRequiredService<IMessageWindowView>();
            view.ViewModel.Parametr = "Ошибка при чтении медицинских услуг из БД. Попробуйте выполнить операцию позже или обратитесь к администратору."
                + Environment.NewLine + "Exception:" + result.ex?.Message
                + Environment.NewLine + "InnerException:" + result.ex?.InnerException?.Message;
        }
        IsBusy = false;
    }

    protected override async Task OperationsAfterSetParametrAsync(object? parametr)
    {
        if (MainEntity!.MedicalServiceId == 0) // Если это новя мед.услуга
            SelectedMedicalService = MedicalServices!.FirstOrDefault(); // тогда, по умолчанию, сразу выбираем первую из списка
    }


    protected override void OperationBeforeSave()
    {
        MainEntity!.Contract = null;
        MainEntity!.MedicalService = null;
    }
}
