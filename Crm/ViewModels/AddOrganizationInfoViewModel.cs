namespace ViewModels;

public class AddOrganizationInfoViewModel : BaseAddEntityViewModel<OrganizationInfo>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public AddOrganizationInfoViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
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
        {
            var view = serviceProvider.GetRequiredService<IMessageWindowView>();
            view.ViewModel.Parametr = "Ошибка при чтении данных. Попробуйте выполнить операцию позже или обратитесь к администратору."
                + Environment.NewLine + "Exception:" + result.ex?.Message
                + Environment.NewLine + "InnerException:" + result.ex?.InnerException?.Message;
        }
        IsBusy = false;
    }
}
