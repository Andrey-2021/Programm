namespace ViewModels;

public class PositionsViewModel : BaseAllEntitiesViewModel<Position, IAddPositionView>
{
    public PositionsViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
