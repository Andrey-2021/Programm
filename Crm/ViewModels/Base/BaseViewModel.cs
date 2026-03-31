namespace ViewModels.Base;

/// <summary>
/// Базовый класс ViewModel
/// </summary>
public class BaseViewModel : INotifyPropertyChanged, IViewModel
{
    /// <summary>
    /// Контейнер. использовать внедрение зависимостей (dependency injection) 
    /// </summary>
    /// <remarks>
	/// Используется для внедрения зависимостей (dependency injection) 
	///</remarks>
    protected readonly IServiceProvider serviceProvider;

    /// <summary>
    /// Сервис диалоговых окон
    /// </summary>
    protected readonly IDialogService dialogService;

    /// <summary>
	/// Репозиторий для работы с БД
	/// </summary>
	protected readonly DbRepository repository;

    /// <summary>
    /// Сервис для статусной строки
    /// </summary>
    public StatusService StatusService
    {
        get => statusService;
        set
        {
            statusService = value;
            OnPropertyChanged();
        }
    }
    private StatusService statusService = new();

    /// <summary>
    /// Флаг занятости
    /// </summary>
    public bool IsBusy
    {
        get => isBusy;
        set
        {
            isBusy = value;
            OnPropertyChanged();
        }
    }
    private bool isBusy { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="serviceProvider"></param>
    public BaseViewModel(IServiceProvider serviceProvider, IDialogService dialogService)
    {
        this.serviceProvider = serviceProvider;
        this.dialogService = dialogService;
        this.repository = this.serviceProvider.GetRequiredService<DbRepository>(); //сразу создаём репозиторий для работы с БД
    }

    #region Реализация интерфейса INotifyPropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
            CheckCommands();
        }
    }

    /// <summary>
    /// Проверка можно ли выполнить команды
    /// </summary>
    protected virtual void CheckCommands()
    {
    }

    #endregion
}
