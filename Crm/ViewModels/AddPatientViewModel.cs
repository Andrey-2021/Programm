namespace ViewModels;

/// <summary>
/// ViewModel для окна ввода данных о пациенте
/// </summary>
public class AddPatientViewModel : BaseAddEntityViewModel<Patient>
{
    public IEnumerable<GenderEnum> GendersList => Enum.GetValues(typeof(GenderEnum)).Cast<GenderEnum>();

    /// <summary>
	/// Конструктор
	/// </summary>
	public AddPatientViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
    }

    protected override async Task<bool> OperationBeforeSave()
    {
        var entity = await repository.GetFirstOrDefaultAsync<Patient>(x => x.BirthDate == MainEntity!.BirthDate
        && x.LastName.ToUpper() == MainEntity!.LastName.ToUpper()
        && x.FirstName.ToUpper() == MainEntity!.FirstName.ToUpper()
        && x.MiddleName.ToUpper() == MainEntity!.MiddleName.ToUpper()
        && x.Id != MainEntity.Id);

        if (entity.ex != null)
        {
            dialogService.ShowError("Ошибка при проверке данных. Попробуйте выполнить операцию позже или обратитесь к администратору. " + entity.ex);
            return false;
        }

        if (entity.entity != null)
        {
            dialogService.ShowWarning("Пациент с дакими ФИО и датой рождения уже есть в БД, добавление отменено.");
            return false;
        }
        return true;
    }

    protected override void ClearData(object? parametr)
    {
        if (MainEntity == null)
            return;
        MainEntity.LastName = string.Empty;
        MainEntity.FirstName = string.Empty;
        MainEntity.MiddleName = string.Empty;
        MainEntity.PhoneNumber = string.Empty;
        MainEntity.Email = string.Empty;
        MainEntity.Address = string.Empty;

        MainEntity.PassportSeries= string.Empty;
        MainEntity.PassportNumber= string.Empty;
        MainEntity.PassportIssueDate= DateTime.Now;
        MainEntity.PassportIssuingAuthority= string.Empty;
        MainEntity.BirthDate = DateTime.Now;
        MainEntity.Gender = null;
    }
}

internal class CheckFIO
{
    public static async Task<(Patient? entity, Exception? ex)> GetFirstOrDefaultAsync(Patient MainEntity, DbRepository repository)
    {
        return await repository.GetFirstOrDefaultAsync<Patient>(x => x.BirthDate == MainEntity!.BirthDate
        && x.LastName.ToUpper() == MainEntity!.LastName.ToUpper()
        && x.FirstName.ToUpper() == MainEntity!.FirstName.ToUpper()
        && x.MiddleName.ToUpper() == MainEntity!.MiddleName.ToUpper()
        && x.Id != MainEntity.Id);
    }

}
