namespace ViewModels.Base;

/// <summary>
/// Базовый класс для ViewModel-ей окон в которых выводятся все данные (обычно в таблицу)
/// </summary>
/// <typeparam name="TEntity">Тип главной сущности</typeparam>
/// <typeparam name="TAddView">Тип View (Окна) для добавления новой/редактирования сущности</typeparam>
public class BaseAllEntitiesViewModel<TEntity, TAddView> : BaseViewModel,  IViewModel
    where TEntity : class, IHaveId, new()
    where TAddView : IViewWithViewModel
{
    /// <summary>
    /// Сообщение в строку статуса
    /// </summary>
    public string? StatusMessage
    {
        get => statusMessage;
        set
        {
            statusMessage = value;
            OnPropertyChanged();
        }
    }
    public string? statusMessage;

    /// <summary>
    /// Флаг занятости
    /// </summary>
    public bool IsBusy { get; set; }

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
    public ObservableCollection<TEntity>? entities;

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
    public TEntity? selectedEntity;

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
    /// <param name="serviceProvider"></param>
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

    protected virtual async void ShowAddEntityWindow(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<TAddView>();
        view.ShowDialog();
        await LoadNecessaryDates();
        StatusMessage = "Данные прочитаны. " + DateTime.Now;
    }

    protected virtual bool CheckIsPossibleShowAddEntityWindow(object? parametr)
    {
        return true;
    }

    protected virtual async void RefreshEntities(object? parametr)
    {
        await LoadNecessaryDates();
        StatusMessage = "Данные перепрочитаны. " + DateTime.Now;
    }

    protected virtual async void DelEntity(object? parametr)
    {
        //if (SelectedEntity == null) return;
        //IsBusy = true;
        //var repository = this.serviceProvider.GetRequiredService<DbRepository>();
        //var result = await repository.DelEntityAsync<TEntity>(SelectedEntity);

        //if (result.ex is not null)
        //{
        //    var view = serviceProvider.GetRequiredService<IMessageWindowView>();
        //    view.ViewModel.Parametr = "Ошибка при удалении данных. Попробуйте выполнить операцию позже или обратитесь к администратору."
        //        + Environment.NewLine + "Exception:" + result.ex?.Message
        //        + Environment.NewLine + "InnerException:" + result.ex?.InnerException?.Message;
        //    view.ShowDialog();
        //}
        //else
        //{
        //    StatusMessage = "Данные удалены. " + DateTime.Now;
        //}

        //await LoadNecessaryDates();
        //IsBusy = false;
        await Delete(SelectedEntity!);
    }

    protected async Task Delete<T>(T deletedEntity)
        where T:class, IHaveId
    {
        if (deletedEntity == null) return;
        IsBusy = true;
        var repository = this.serviceProvider.GetRequiredService<DbRepository>();
        var result = await repository.DelEntityAsync<T>(deletedEntity);

        if (result.ex is not null)
        {
            var view = serviceProvider.GetRequiredService<IMessageWindowView>();
            view.ViewModel.Parametr = "Ошибка при удалении данных. Попробуйте выполнить операцию позже или обратитесь к администратору."
                + Environment.NewLine + "Exception:" + result.ex?.Message
                + Environment.NewLine + "InnerException:" + result.ex?.InnerException?.Message;
            view.ShowDialog();
        }
        else
        {
            StatusMessage = "Данные удалены. " + DateTime.Now;
        }

        await LoadNecessaryDates();
        IsBusy = false;
    }




    protected virtual bool CheckIsPossibleDeleAddEntity(object? parametr)
    {
        return SelectedEntity != null;
    }

    protected virtual async void EditEntity(object? parametr)
    {
        var view = serviceProvider.GetRequiredService<TAddView>();
        view.ViewModel.Parametr = SelectedEntity;
        view.ShowDialog();
        await LoadNecessaryDates();
        StatusMessage = "Данные прочитаны. " + DateTime.Now;
    }

    protected virtual bool CheckIsPossibleEditAddEntity(object? parametr)
    {
        return SelectedEntity != null;
    }

    /// <summary>
    /// Загрузка сущностей из БД
    /// </summary>
    /// <returns></returns>
    protected async Task LoadNecessaryDates()
    {
        IsBusy = true;
        var repository = this.serviceProvider.GetRequiredService<DbRepository>();

        //var result = await repository.GetEntitiesAsync<TEntity>();
        var result = await LoadDataFromDb(repository);

        if (result.ex is null)
            Entities = new ObservableCollection<TEntity>(result.data);
        else
        {
            Entities = null;
            var view = serviceProvider.GetRequiredService<IMessageWindowView>();
            view.ViewModel.Parametr = "Ошибка при чтении данных. Попробуйте выполнить операцию позже или обратитесь к администратору."
                + Environment.NewLine + "Exception:" + result.ex?.Message
                + Environment.NewLine + "InnerException:" + result.ex?.InnerException?.Message;
        }
        IsBusy = false;
    }

    /// <summary>
    /// Чтение данных из БД
    /// </summary>
    protected virtual async Task<(IEnumerable<TEntity> data, Exception? ex)> LoadDataFromDb(DbRepository repository)
    {
        var result = await repository.GetEntitiesAsync<TEntity>();
        return result;
    }

    /// <summary>
    /// Проверка можно ли выполнить команды
    /// </summary>
    protected override void CheckCommands()
    {
        DelCommand?.RaiseCanExecuteChanged();
        EditCommand?.RaiseCanExecuteChanged();
    }
}
