namespace ViewModels;

public class AddOrganizationInfoViewModel : BaseAddEntityViewModel<OrganizationInfo>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public AddOrganizationInfoViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
    }

    protected override async Task LoadNecessaryDates()
    {
        IsBusy = true;
        var repository = this.serviceProvider.GetRequiredService<DbRepository>();
        var result = await repository.GetFirstOrDefaultAsync<OrganizationInfo>();

        if (result.ex is null)
            MainEntity = result.entity;
        else
            dialogService.ShowError("Ошибка при чтении данных. Попробуйте выполнить операцию позже или обратитесь к администратору.", exception: result.ex);
        IsBusy = false;
    }
}
