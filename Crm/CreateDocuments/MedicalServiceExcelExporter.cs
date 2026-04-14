using Entities;
using OfficeOpenXml;
using OfficeOpenXml.Style;
namespace CreateDocuments;

/// <summary>
/// Передача данных о медицинских услугах в Excel-файл
/// </summary>
public class MedicalServiceExcelExporter
{
    /// <summary>
    /// Сохранение данных в Excel-файл
    /// </summary>
    /// <param name="medicalServices">Данные</param>
    /// <param name="filePath">Имя файла</param>
    public static async Task<(bool result, Exception? ex)> ExportToExcel(IEnumerable<MedicalService>? medicalServices, string filePath)
    {
        try
        {
            ExcelPackage.License.SetNonCommercialPersonal("Diplom");

            if (medicalServices == null)
                throw new ArgumentNullException("Нет данных о мед.услугах");

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Медицинские услуги");

                // Заголовки колонок
                var headers = new List<string>
                {
                    "Наименование услуги",
                    "Код услуги",
                    "Вид медицинской услуги",
                    "Стоимость услуги (руб.)"
                };

                // Записываем заголовки в первую строку
                for (int i = 0; i < headers.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = headers[i];
                    worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Azure);
                }

                // Заполняем данными
                int row = 2;
                foreach (var service in medicalServices)
                {
                    worksheet.Cells[row, 1].Value = service.ServiceName;
                    worksheet.Cells[row, 2].Value = service.ServiceCode;

                    // Вид медицинской услуги: если навигационное свойство загружено, выводим его название,
                    // иначе можно вывести ID или оставить пустым
                    string serviceTypeValue = service.MedicalServiceType?.Name??
                                              (service.MedicalServiceTypeId > 0 ? $"ID: {service.MedicalServiceTypeId}" : "");
                    worksheet.Cells[row, 3].Value = serviceTypeValue;

                    // Стоимость услуги: форматируем как число с двумя знаками после запятой
                    worksheet.Cells[row, 4].Value = service.ServicePrice;
                    worksheet.Cells[row, 4].Style.Numberformat.Format = "#,##0.00";
                    row++;
                }

                // Авто-подбор ширины колонок
                worksheet.Cells[1, 1, row - 1, headers.Count].AutoFitColumns();

                // Сохраняем файл асинхронно
                await package.SaveAsAsync(filePath);
            }

            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex);
        }
    }
}