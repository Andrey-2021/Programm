namespace ViewModels;

public class MedicalServiceTypesViewModel : BaseAllEntitiesViewModel<MedicalServiceType, IAddMedicalServiceTypeView>
{
    public MedicalServiceTypesViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
