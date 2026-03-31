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
        var entity = await repository.GetFirstOrDefaultAsync<Employee>(x=>x.LastName.ToUpper() == MainEntity!.LastName.ToUpper()
        && x.FirstName.ToUpper() == MainEntity!.FirstName.ToUpper()
        && x.MiddleName.ToUpper() == MainEntity!.MiddleName.ToUpper()
        && x.Id != MainEntity.Id);

        if (entity.ex != null)
        {
            dialogService.ShowError("Ошибка при проверке данных. Попробуйте выполнить операцию позже или обратитесь к администратору. " + entity.ex);
            return false;
        }

        if (entity.entity != null)
        {
            dialogService.ShowWarning("Сотрудник с дакими ФИО уже есть в БД, добавление отменено.");
            return false;
        }

        MainEntity!.Position = null;
        return true;
    }
}
