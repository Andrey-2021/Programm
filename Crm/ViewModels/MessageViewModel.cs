namespace ViewModels;

public class MessageViewModel: IViewModelWithParametr
{
	public bool IsPrgBusy { get; set; }
    public object? Parametr
    {
        get => parametr;

        set
        {
            parametr = value;
            OnParametrSet(value);
        }
    }
    private object? parametr;

    public string? Message { get; set; }

	protected void OnParametrSet(object? parametr)
	{
		Message = parametr as string;
	}

	/// <summary>
	/// Команда "Отмена/закрыть окно"
	/// </summary>
	public RelayCommand? CloseWindowCommand { get; set; }

	public MessageViewModel()
	{
		CloseWindowCommand = new RelayCommand(CloseWindow);
	}

	/// <summary>
	/// Закрыть окно. (Метод который вызывается командой CloseWindowCommand)
	/// </summary>
	/// <param name="parametr"></param>
	protected void CloseWindow(object? parametr)
	{
		var view = parametr as IView;
		if (view != null) view.Close();
	}
}
