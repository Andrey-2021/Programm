namespace ViewModels;

public class AddContractViewModel : BaseAddEntityViewModel<Contract>
{
    /// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="serviceProvider"></param>
	public AddContractViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {

    }
}

