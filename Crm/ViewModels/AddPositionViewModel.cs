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

    protected override async Task<bool> OperationBeforeSave()
    {
        var entity = await repository.GetFirstOrDefaultAsync<Position>(x => x.PositionName.ToUpper() == MainEntity!.PositionName.ToUpper() && x.Id != MainEntity.Id);

        if (entity.ex != null)
        {
            dialogService.ShowError("Ошибка при проверке данных. Попробуйте выполнить операцию позже или обратитесь к администратору. " + entity.ex);
            return false;
        }

        if (entity.entity != null)
        {
            dialogService.ShowWarning("Такая должность уже существует, добавление отменено.");
            return false;
        }
        return true;
    }

    protected override void ClearData(object? parametr)
    {
        if (MainEntity == null)
            return;
        MainEntity.PositionName = string.Empty;

    }
}
