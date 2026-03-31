namespace ViewModels;

public class AddMedicalServiceTypeViewModel : BaseAddEntityViewModel<MedicalServiceType>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="serviceProvider"></param>
    public AddMedicalServiceTypeViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
    }

    protected override async Task<bool> OperationBeforeSave()
    {
        var entity = await repository.GetFirstOrDefaultAsync<MedicalServiceType>(x => x.Name.ToUpper() == MainEntity!.Name.ToUpper() && x.Id != MainEntity.Id);

        if (entity.ex != null)
        {
            dialogService.ShowError("Ошибка при проверке данных. Попробуйте выполнить операцию позже или обратитесь к администратору. " + entity.ex);
            return false;
        }

        if (entity.entity != null)
        {
            dialogService.ShowWarning("Такой вид мед.услуг уже существует, добавление отменено.");
            return false;
        }
        return true;
    }
}
