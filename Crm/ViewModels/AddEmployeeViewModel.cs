namespace ViewModels;

public class AddEmployeeViewModel : BaseAddEntityViewModel<Employee>
{
    /// <summary>
    /// Список Групп из БД
    /// </summary>
    public ObservableCollection<Position>? Entities
    {
        get => entities;
        set
        {
            entities = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<Position>? entities;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="serviceProvider"></param>
    public AddEmployeeViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
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
        var result = await repository.GetEntitiesAsync<Position>();
        if (result.ex == null)
            Entities= new ObservableCollection<Position>(result.data.OrderBy(x => x.PositionName));
        else
        {
            Entities?.Clear();
            dialogService.ShowError("Ошибка при чтении должностей из БД. Попробуйте выполнить операцию позже или обратитесь к администратору.", exception: result.ex);
        }
        IsBusy = false;
    }

    protected override async Task<bool> OperationBeforeSave()
    {
        MainEntity!.Position = null;
        return true;
    }
}
