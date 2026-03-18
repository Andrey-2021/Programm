namespace ViewModels;

public class PatientsViewModel : BaseAllEntitiesViewModel<Patient, IAddPatientView>
{
    public PatientsViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
