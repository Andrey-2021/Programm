namespace ViewModels;

/// <summary>
/// ViewModel для окна ввода данных о пользователе
/// </summary>
public class AddUserViewModel : BaseAddEntityViewModel<RegisteredUser>
{
    public IEnumerable<RoleEnum> RoleEnumList => Enum.GetValues(typeof(RoleEnum)).Cast<RoleEnum>();

    public AddUserViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
	}

    protected override async Task<bool> OperationBeforeSave()
    {
		var entity = await repository.GetFirstOrDefaultAsync<RegisteredUser>(x => x.Login.ToUpper() == MainEntity!.Login.ToUpper() && x.Id!=MainEntity.Id);

		if (entity.ex != null)
		{
            dialogService.ShowError("Ошибка при проверке данных. Попробуйте выполнить операцию позже или обратитесь к администратору. " + entity.ex);
			return false;
		}

		if (entity.entity != null)
		{
            dialogService.ShowWarning("Такой логин уже существует, придумайте другой");
			return false;
		}
		return true;
	}
}