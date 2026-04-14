using CreateDocuments;

namespace ViewModels;

/// <summary>
/// ViewModel для окна вывода данных о сотрудниках
/// </summary>
public class EmployeesViewModel : BaseImportExportDataViewModel<Employee, IAddEmployeesView>
{
    public EmployeesViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
    }

    protected override async void ExportData(object? parametr)
    {
        var file = dialogService.SaveFile("Excel (*.xlsx)|*.xlsx");
        if (file == null)
            return;

        var responce = await EmployeeExcelExporter.ExportToExcel(Entities, file);
        if (responce.result)
            dialogService.ShowInfo($"Файл {file} сохранён ");
        else
            dialogService.ShowInfo($"Ошибка при сохранении файла: {responce.ex?.Message} ");

    }
}
