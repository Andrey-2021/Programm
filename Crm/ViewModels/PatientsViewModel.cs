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

    protected override async void ImportData(object? parametr)
    {
        // открываем окно
        var file = dialogService.OpenFile("Excel (*.xlsx)|*.xlsx");
        if (file == null)
            return;
        // получаем данные из Excel
        var responce = await PatientExcelImporter.ImportFromExcel(file);

        if (responce.ex != null)
        {
            dialogService.ShowInfo($"Ошибка при чтении файла: {responce.ex?.Message} ");
            return;
        }

        int added = 0; // количество добавленных пациентов
        int error = 0; // количество ошибок
        int repeat = 0;// количество пациентов уже существующих в БД

        if (responce.patients?.Count > 0)
        {
            foreach (var item in responce.patients)
            {
                var findResult= await CheckFIO.GetFirstOrDefaultAsync(item, repository);
                if(findResult.ex!=null)
                {
                    error++;
                    continue;
                }

                if(findResult.entity !=null)
                {
                    repeat++;
                    continue;
                }

                var saveResult= await repository.UpdateEntityAsync(item!);
                if (saveResult != null)
                    error++;
                else
                    added++;
            }
        }

        dialogService.ShowInfo($"Файл {file} прочитан." 
            + Environment.NewLine + $"Прочитано {responce.patients?.Count} строк,"
            + Environment.NewLine + $"В БД добавлено {added} пациентов,"
            + Environment.NewLine + $"В БД уже есть {repeat} пациентов c такими ФИО и датой рождения, они не добавлены в БД."
            + Environment.NewLine + $"Ошибок: {error}"
            );

        await LoadNecessaryDates();
    }
}
