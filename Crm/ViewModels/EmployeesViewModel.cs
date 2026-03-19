namespace ViewModels;

public class EmployeesViewModel : BaseAllEntitiesViewModel<Employee, IAddEmployeesView>
{
    public EmployeesViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
