namespace ViewModels.Base;

/// <summary>
/// Базовый класс для ViewModel-ей окон в которых выводятся все данные (обычно в таблицу)
/// </summary>
/// <typeparam name="TEntity">Тип главной сущности</typeparam>
/// <typeparam name="TAddView">Тип View (Окна) для добавления новой/редактирования сущности</typeparam>
public class BaseAllEntitiesViewModel<TEntity, TAddView> : BaseViewModel  
    where TEntity : class, IHaveId, new()
    where TAddView : IViewWithViewModel
{
    /// <summary>
    /// Список сущностей из БД
    /// </summary>
    public ObservableCollection<TEntity>? Entities
    {
        get => entities;
        set
        {
            entities = value;
            OnPropertyChanged();
        }
    }
    private ObservableCollection<TEntity>? entities;

    /// <summary>
    /// Выбранная сущность
    /// </summary>
    public TEntity? SelectedEntity
    {
        get => selectedEntity;
        set
        {
            selectedEntity = value;
            OnPropertyChanged();
        }
    }
    private TEntity? selectedEntity;

    /// <summary>
    /// Команда "Добавить"
    /// </summary>
    public ICommand? AddCompanyCommand { private set; get; }

    /// <summary>
    /// Команда "Обновить"
    /// </summary>
    public ICommand? RefreshCommand { private set; get; }

    /// <summary>
    /// Команда "Удалить"
    /// </summary>
    public RelayCommand? DelCommand { private set; get; }

    /// <summary>
    /// Команда "Редактировать"
    /// </summary>
    public RelayCommand? EditCommand { private set; get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public BaseAllEntitiesViewModel(IServiceProvider serviceProvider, IDialogService dialogService) :base(serviceProvider, dialogService)
    {
        //настраиваем команды
        AddCompanyCommand = new RelayCommand(ShowAddEntityWindow, CheckIsPossibleShowAddEntityWindow);
        RefreshCommand = new RelayCommand(RefreshEntities);
        DelCommand = new RelayCommand(DelEntity, CheckIsPossibleDeleAddEntity);
        EditCommand = new RelayCommand(EditEntity, CheckIsPossibleEditAddEntity);

        var task = Task.Run(() => LoadNecessaryDates());
        task.Wait();
    }

    /// <summary>
    /// Открыть окно добавления данных
    /// </summary>
    protected virtual async void ShowAddEntityWindow(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<TAddView>();
        view.ShowDialog();
        SelectedEntity=view.ViewModel.Parametr as TEntity; // Чтобы выделить сохранённый объект после перезагрузки данных
        StatusService.Clea();
        await LoadNecessaryDates();
    }

    /// <summary>
    /// Проверка можно ли выполнить команду добавления данных
    /// </summary>
    protected virtual bool CheckIsPossibleShowAddEntityWindow(object? parametr)
    {
        return true;
    }

    /// <summary>
    /// Обновить данные
    /// </summary>
    /// <param name="parametr"></param>
    protected virtual async void RefreshEntities(object? parametr)
    {
        StatusService.Clea();
        await LoadNecessaryDates();
    }

    /// <summary>
    /// Удалить сущность
    /// </summary>
    /// <param name="parametr"></param>
    protected virtual async void DelEntity(object? parametr)
    {
        await Delete(SelectedEntity!);
        

    }

    /// <summary>
    /// Проверить можно ли выполнить команду удаления данных
    /// </summary>
    protected virtual bool CheckIsPossibleDeleAddEntity(object? parametr)
    {
        return SelectedEntity != null;
    }

    /// <summary>
    /// Удалить данные
    /// </summary>
    /// <typeparam name="T">Удаляемый тип </typeparam>
    /// <param name="deletedEntity">Удаляемая сущность</param>
    protected async Task Delete<T>(T deletedEntity)
        where T:class, IHaveId
    {
        StatusService.Clea();
        if (deletedEntity == null) 
            return;

        if (!AskQestionToDelete())
            return;

        IsPrgBusy = true;
        var result = await repository.DelEntityAsync<T>(deletedEntity);

        if (result.ex is not null)
            dialogService.ShowError("Ошибка при удалении данных. Попробуйте выполнить операцию позже или обратитесь к администратору.", exception: result.ex);
        else
        {
            StatusService.SetMessage("Данные удалены.");
        }
        
        await LoadNecessaryDates();
        IsPrgBusy = false;
    }

    protected virtual bool AskQestionToDelete()
    {
        return dialogService.Confirm("Удаление объекта может привести к удалению всех зависящих объектов, которые зависят от данного удаляемого. " +
            Environment.NewLine+ "Вы действительно хотите удалить лбъект?");
    }

    /// <summary>
    /// Отредактировать сущность
    /// </summary>
    protected virtual async void EditEntity(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<TAddView>();
        view.ViewModel.Parametr = SelectedEntity;
        view.ShowDialog();
        StatusService.Clea();
        await LoadNecessaryDates();
    }

    /// <summary>
    /// Можно ли выполнить команду редактирования данных
    /// </summary>
    protected virtual bool CheckIsPossibleEditAddEntity(object? parametr)
    {
        return SelectedEntity != null;
    }

    /// <summary>
    /// Загрузка сущностей из БД
    /// </summary>
    protected virtual async Task LoadNecessaryDates()
    {
        IsPrgBusy = true;
        var selectedId = SelectedEntity?.Id; // Для восстановления выбранного объекта
        var result = await LoadDataFromDb(repository);

        if (result.ex is null)
        {
            Entities = new ObservableCollection<TEntity>(result.data);
            StatusService.AddMessage("Данные прочитаны.");
            SelectedEntity = Entities.FirstOrDefault(x => x.Id == selectedId); // Восстанавливаем выбранный объект
        }
        else
        {
            Entities = null;
            dialogService.ShowError("Ошибка при чтении данных. Попробуйте выполнить операцию позже или обратитесь к администратору");
            StatusService.AddMessage("Ошибка чтения данных.");
        }
        IsPrgBusy = false;
    }

    /// <summary>
    /// Чтение данных из БД
    /// </summary>
    protected virtual async Task<(IEnumerable<TEntity> data, Exception? ex)> LoadDataFromDb(DbRepository repository)
    {
        return await repository.GetEntitiesAsync<TEntity>();
    }

    /// <summary>
    /// Проверка можно ли выполнить команды
    /// </summary>
    protected override void CheckCommands()
    {
        DelCommand?.RaiseCanExecuteChanged();
        EditCommand?.RaiseCanExecuteChanged();
        base.CheckCommands();
    }
}
