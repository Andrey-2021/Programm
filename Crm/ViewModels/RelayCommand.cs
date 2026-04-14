namespace ViewModels;

/// <summary>
/// Класс реализующий интерфей команд ICommand
/// </summary>
public class RelayCommand : ICommand
{
	public event EventHandler? CanExecuteChanged;
	//{
	//	add { CommandManager.RequerySuggested += value; }
	//	remove { CommandManager.RequerySuggested -= value; }
	//}

	private readonly Action<object?> execute;
	private readonly Func<object?, bool>? canExecute;

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="execute">Метод выполняющийся при вызове команды</param>
	/// <param name="canExecute">Функция проверки можно ли вызвать метод</param>
	public RelayCommand(Action<object?> execute, Func<object?, bool> canExecute)
	{
		this.execute = execute;
		this.canExecute = canExecute;
	}

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="execute">Метод выполняющийся при вызове команды</param>
    public RelayCommand(Action<object?> execute)
	{
		this.execute = execute;
		this.canExecute = this.AlwaysCanExecute; ;
	}

    /// <summary>
    /// Определяет, может ли команда выполняться
    /// </summary>
    public bool CanExecute(object? parameter)
	{
		return this.canExecute == null || this.canExecute(parameter);
	}

    /// <summary>
    /// Выполняет команду
    /// </summary>
    /// <param name="parameter"></param>
    public void Execute(object? parameter)
	{
		this.execute(parameter);
	}

    /// <summary>
    /// Метод CanExecute по умолчанию. Показывает что команду можно выполнить 
    /// </summary>
    private bool AlwaysCanExecute(object? param)
	{
		return true;
	}

	public void RaiseCanExecuteChanged()
	{
		if (CanExecuteChanged != null)
		{
			CanExecuteChanged(this, EventArgs.Empty);
		}
	}
}
