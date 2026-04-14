namespace ViewModels;

/// <summary>
/// ViewModel для окна вывода данных о должностях
/// </summary>
public class PositionsViewModel : BaseAllEntitiesViewModel<Position, IAddPositionView>
{
    public PositionsViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
    }
}
