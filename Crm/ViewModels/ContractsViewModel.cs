

namespace ViewModels;

public class ContractsViewModel : BaseAllEntitiesViewModel<Contract, IAddContractView>
{
    public ContractsViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
