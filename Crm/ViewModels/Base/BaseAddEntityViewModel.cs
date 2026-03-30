namespace ViewModels.Base;

/// <summary>
/// Базовый класс для всех AddViewModel
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class BaseAddEntityViewModel<TEntity>: BaseViewModel,  IViewModelWithParametr //, IDisposable
	where TEntity : class, INotifyPropertyChanged, new()
{
	public object? Parametr { set => OnParametrSet(value); }

	/// <summary>
	/// Главная сущность/объект
	/// </summary>
	public TEntity? MainEntity { get=> mainEntity; set { mainEntity = value; OnPropertyChanged(); } }
	private TEntity? mainEntity;

	/// <summary>
	/// Команда "Сохранить"
	/// </summary>
	public RelayCommand? SaveCommand { get; set; }
	
	/// <summary>
	/// Команда "Отмена/закрыть окно"
	/// </summary>
	public RelayCommand? CloseWindowCommand { get; set; }
	
	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="serviceProvider"></param>
	public BaseAddEntityViewModel(IServiceProvider serviceProvider, IDialogService dialogService) :base(serviceProvider, dialogService)
	{
		MainEntity = new();
		//настраиваем команды
		SaveCommand = new RelayCommand(Save, CheckIsPossibleSave);
		CloseWindowCommand = new RelayCommand(CloseWindow, CheckIsPossibleCloseWindow);

        var task = Task.Run(() => LoadNecessaryDates());
        task.Wait();
    }

	/// <summary>
	/// Загрузка исходных данных
	/// </summary>
    protected virtual async Task LoadNecessaryDates()
    {
    }

    /// <summary>
    /// Приведение типов. Переданный параметр типа object приводим к типу TEntity
    /// </summary>
    protected virtual async void OnParametrSet(object? parametr)
	{
		var mainEntity = parametr as TEntity;
		if (mainEntity == null) 
			throw new ArgumentException("Неправильно задан тип параметра");//если не удалость привести, бросаем исключение
		MainEntity = mainEntity;
		await OperationsAfterSetParametrAsync(parametr);
	}

	/// <summary>
	/// Опреации после получения параметра
	/// </summary>
	protected virtual async Task OperationsAfterSetParametrAsync(object? parametr)
	{
		await Task.CompletedTask;
	}

	/// <summary>
	/// Сохранить данные. (Метод который вызывается командой SaveCommand)
	/// </summary>
	protected virtual async void Save(object? parametr)
	{
		if (BaseINotifyDataErrorInfo.HasErrorsOnlyInAllMyPublicProperties(MainEntity))
			return;

		var continueSave= await OperationBeforeSave();
        if(!continueSave) 
			return;

        var result = await SaveDataToDb();
        if (result!=null) //если ошибка
		{
			dialogService.ShowError("Ошибка при выполнении операции сохранения данных. Попробуйте выполнить операцию позже или обратитесь к администратору", exception: result);
			return;
		}
		CloseWindow(parametr);//всё хорошо, закрываем  окно
	}

	/// <summary>
	/// Опреации выполняемые до операции записи данных в БД
	/// </summary>
	protected virtual async Task<bool> OperationBeforeSave()
	{
		return true;
	}

	/// <summary>
	/// Записать данные в БД
	/// </summary>
	/// <returns></returns>
	protected virtual async Task<Exception?> SaveDataToDb()
	{
        return await repository.UpdateEntityAsync(MainEntity!);
    }

	/// <summary>
	/// Проверка можно ли выполнять команду Сохранить
	/// </summary>
	protected virtual bool CheckIsPossibleSave(object? parametr)
	{
		//Если объект не существуе, возвращаем false
		if (MainEntity == null) 
			return false;
        return true;
	}

	/// <summary>
	/// Закрыть окно. (Метод который вызывается командой CloseWindowCommand)
	/// </summary>
	protected void CloseWindow(object? parametr)
	{
		var view = parametr as IView;
		if (view != null) view.Close();
	}

	/// <summary>
	/// Проверка можно ли выполнять команду "Отмена/закрыть окно"
	/// </summary>
	private bool CheckIsPossibleCloseWindow(object? parametr)
	{
		return true;
	}

	/// <summary>
	/// Проверка можно ли выполнить команды
	/// </summary>
	protected override void CheckCommands()
	{
		SaveCommand?.RaiseCanExecuteChanged();
		CloseWindowCommand?.RaiseCanExecuteChanged();
        base.CheckCommands();
    }
}
