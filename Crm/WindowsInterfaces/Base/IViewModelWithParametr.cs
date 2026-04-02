namespace WindowsInterfaces;

/// <summary>
/// ViewModel с параметром
/// </summary>
public interface IViewModelWithParametr : IViewModel
{
	/// <summary>
	/// Параметр
	/// </summary>
	public object? Parametr { get; set; }
}

