namespace ViewModels;

public class AddPositionViewModel : BaseAddEntityViewModel<Position>
{
    /// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="serviceProvider"></param>
	public AddPositionViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {

    }
}
