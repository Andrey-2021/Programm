namespace ViewModels;

public class MedicalServicesViewModel : BaseAllEntitiesViewModel<MedicalService, IAddMedicalServiceView>
{
    public MedicalServicesViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
