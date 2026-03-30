namespace ViewModels;

/// <summary>
/// Добавить пользователя
/// </summary>
public class AddUserViewModel : BaseAddEntityViewModel<RegisteredUser>
{
	public Dictionary<RoleEnum, string> RolesList => TranslateRoleEnum.Roles;

	public AddUserViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
	}

    protected override async Task<bool> OperationBeforeSave()
    {
		var entity = await repository.GetFirstOrDefaultAsync<RegisteredUser>(x => x.Login == MainEntity!.Login && x.Id!=MainEntity.Id);

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