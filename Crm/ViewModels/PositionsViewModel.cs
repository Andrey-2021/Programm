namespace ViewModels;

public class PositionsViewModel : BaseAllEntitiesViewModel<Position, IAddPositionView>
{
    public PositionsViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
    }
}
