namespace ViewModels.Base;

public class BaseImportExportDataViewModel<TEntity, TAddView> : BaseAllEntitiesViewModel<TEntity, TAddView>
    where TEntity : class, IHaveId, new()
    where TAddView : IViewWithViewModel
{
    /// <summary>
    /// Команда "Экспортировать данные"
    /// </summary>
    public ICommand? ExportDataCommand { private set; get; }

    /// <summary>
    /// Команда "Импортировать данные"
    /// </summary>
    public ICommand? ImportDataCommand { private set; get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="serviceProvider"></param>
    public BaseImportExportDataViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
        ExportDataCommand = new RelayCommand(ExportData, CheckIsPossibleExportData);
        ImportDataCommand = new RelayCommand(ImportData, CheckIsPossibleImportData);
    }

    protected virtual async void ExportData(object? parametr)
    {
        dialogService.ShowInfo("Экспортировать данные");
    }

    protected virtual bool CheckIsPossibleExportData(object? parametr)
    {
        return Entities?.Count>0;
    }

    protected virtual async void ImportData(object? parametr)
    {
        dialogService.ShowInfo("Импортировать данные");
    }

    protected virtual bool CheckIsPossibleImportData(object? parametr)
    {
        return true;
    }

}
