namespace ViewModels.Base;

public class BaseViewModel: INotifyPropertyChanged
{
    /// <summary>
    /// Контейнер. использовать внедрение зависимостей (dependency injection) 
    /// </summary>
    /// <remarks>
	/// Используется для внедрения зависимостей (dependency injection) 
	///</remarks>
    protected IServiceProvider serviceProvider;

    protected readonly IDialogService dialogService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="serviceProvider"></param>
    public BaseViewModel(IServiceProvider serviceProvider, IDialogService dialogService)
    {
        this.serviceProvider = serviceProvider;
        this.dialogService = dialogService;
    }

    //для реализации интерфейса INotifyPropertyChanged
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
}
