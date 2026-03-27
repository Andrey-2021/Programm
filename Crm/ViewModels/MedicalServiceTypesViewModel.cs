namespace ViewModels;

public class MedicalServiceTypesViewModel : BaseAllEntitiesViewModel<MedicalServiceType, IAddMedicalServiceTypeView>
{
    public MedicalServiceTypesViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
    }
}
