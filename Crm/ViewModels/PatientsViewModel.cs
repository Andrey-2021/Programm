namespace ViewModels;

public class PatientsViewModel : BaseImportExportDataViewModel<Patient, IAddPatientView>
{
    public PatientsViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
