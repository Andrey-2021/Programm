using Entities;
using OfficeOpenXml;
using OfficeOpenXml.Style;
namespace CreateDocuments;

public class EmployeeExcelExporter
{
    public static async Task<(bool result, Exception? ex)> ExportToExcel(IEnumerable<Employee>? employees, string filePath)
    {
        try
        {
            ExcelPackage.License.SetNonCommercialPersonal("Diplom");

            if (employees == null)
                throw new ArgumentNullException("Нет данных о сотрудниках");

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Сотрудники");

                // Заголовки колонок
                var headers = new List<string>
                {
                    "Фамилия",
                    "Имя",
                    "Отчество",
                    "Должность",
                    "Телефон",
                    "E-mail"
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
                foreach (var employee in employees)
                {
                    worksheet.Cells[row, 1].Value = employee.LastName;
                    worksheet.Cells[row, 2].Value = employee.FirstName;
                    worksheet.Cells[row, 3].Value = employee.MiddleName;

                    // Должность: если навигационное свойство Position загружено, выводим его название,
                    // иначе можно вывести ID должности или оставить пустым
                    string positionValue = employee.Position?.PositionName ?? (employee.PositionId > 0 ? $"ID: {employee.PositionId}" : "");
                    worksheet.Cells[row, 4].Value = positionValue;

                    worksheet.Cells[row, 5].Value = employee.PhoneNumber;
                    worksheet.Cells[row, 6].Value = employee.Email ?? ""; // если email null, выводим пустую строку

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