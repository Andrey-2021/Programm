namespace ViewModels;

public class EmployeesViewModel : BaseImportExportDataViewModel<Employee, IAddEmployeesView>
{
    public EmployeesViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
