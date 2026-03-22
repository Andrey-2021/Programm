namespace ViewModels;

public class MedicalServicesViewModel : BaseImportExportDataViewModel<MedicalService, IAddMedicalServiceView>
{
    public MedicalServicesViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
