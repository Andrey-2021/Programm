namespace ViewModels;

/// <summary>
/// ViewModel для окна вывода данных о типах медицинских услуг
/// </summary>
public class MedicalServiceTypesViewModel : BaseAllEntitiesViewModel<MedicalServiceType, IAddMedicalServiceTypeView>
{
    public MedicalServiceTypesViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
    }
}
