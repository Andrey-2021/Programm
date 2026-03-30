namespace ViewModels;

public class AddMedicalServiceViewModel : BaseAddEntityViewModel<MedicalService>
{
    /// <summary>
    /// Список типов медицинских услуг из БД
    /// </summary>
    public ObservableCollection<MedicalServiceType>? Entities
    {
        get => entities;
        set
        {
            entities = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<MedicalServiceType>? entities;

    /// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="serviceProvider"></param>
	public AddMedicalServiceViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
    }

    /// <summary>
	/// Загружаем список Групп из БД
	/// </summary>
	/// <returns></returns>
	protected override async Task LoadNecessaryDates()
    {
        IsBusy = true;
        var result = await repository.GetEntitiesAsync<MedicalServiceType>();
        if (result.ex == null)
            Entities = new ObservableCollection<MedicalServiceType>(result.data.OrderBy(x => x.Name));
        else
        {
            Entities?.Clear();
            dialogService.ShowError("Ошибка при чтении типов медицинских услуг из БД. Попробуйте выполнить операцию позже или обратитесь к администратору.", exception: result.ex);
        }
        IsBusy = false;
    }

    protected override async Task<bool> OperationBeforeSave()
    {
        MainEntity!.MedicalServiceType = null;
        return true;
    }
}
