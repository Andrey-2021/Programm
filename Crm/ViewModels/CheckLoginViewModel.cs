namespace ViewModels;

public class CheckLoginViewModel : BaseAddEntityViewModel<CheckLogin>
{
	public CheckLoginViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
	{
	}

	protected override async void Save(object? parametr)
	{
		IsPrgBusy = true;
		var loginUserService = serviceProvider.GetService<LoginUserService>();
		var connectionError = await repository.DbAvailableAsync();
        IsPrgBusy = false;

        if (connectionError.ex != null || connectionError.checkResult==false) //ошибка соединения с БД
		{
			if ( MainEntity.Login== LoginUserService.DefaultAdminLogin && MainEntity!.Password == LoginUserService.DefaultAdminPassword)
			{
				dialogService.ShowWarning("БД недоступна/отсутствует. Вам предоставляется доступ в программу, создайте новую БД и смените пароли по умолчанию.");
				loginUserService!.CreateAdmin();
				CloseWindow(parametr);
                return;
			}

			dialogService.ShowError("БД недоступна. Неправильно ввели пароль или логин по умолчанию!");
            //CloseWindow(parametr);
            return;
		}

		var find= await repository.GetEntitiesAsync<RegisteredUser>(x => x.Password == MainEntity.Password && x.Login == MainEntity.Login);
		if(find.data == null || find.data.Count()==0)
		{
			dialogService.ShowWarning("Неправильно ввели пароль или логин!");
            //CloseWindow(parametr);
            return;
		}

		loginUserService!.SetUser(find.data.First());
        CloseWindow(parametr);//всё хорошо, закрываем  окно
	}
}
