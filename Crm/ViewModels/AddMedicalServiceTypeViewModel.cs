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
}
