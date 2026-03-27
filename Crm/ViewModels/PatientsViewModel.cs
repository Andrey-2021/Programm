using CreateDocuments;

namespace ViewModels;

public class PatientsViewModel : BaseImportExportDataViewModel<Patient, IAddPatientView>
{
    public PatientsViewModel(IServiceProvider serviceProvider, IDialogService dialogService) : base(serviceProvider, dialogService)
    {
    }

    protected override async void ExportData(object? parametr)
    {
        var file = dialogService.SaveFile("Excel (*.xlsx)|*.xlsx");
        if (file == null)
            return;

        var responce=await PatientExcelExporter.ExportToExcel(Entities, file);
        if(responce.rezult)
            dialogService.ShowInfo($"Файл {file} сохранён ");
        else
            dialogService.ShowInfo($"Ошибка при сохранении файла: {responce.ex?.Message} ");

    }
}
