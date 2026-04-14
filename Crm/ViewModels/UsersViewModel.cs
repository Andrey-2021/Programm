namespace ViewModels;

/// <summary>
/// ViewModel для окна вывода данных о пользователях
/// </summary>
public class UsersViewModel : BaseAllEntitiesViewModel<RegisteredUser, IAddUserView>
{
	public UsersViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
	}
}
