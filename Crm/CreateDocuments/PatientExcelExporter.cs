using Entities;
using OfficeOpenXml;
using OfficeOpenXml.Style;
namespace CreateDocuments;

public class PatientExcelExporter
{
    public static async Task<(bool rezult, Exception? ex)> ExportToExcel(IEnumerable<Patient>? patients, string filePath)
    {
        try
        {
            ExcelPackage.License.SetNonCommercialPersonal("Diplom");

            if (patients == null)
                throw new ArgumentNullException(nameof(patients));


            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Пациенты");

                // Заголовки колонок (используем DisplayName)
                var headers = new List<string>()
            {
                "Фамилия",
                "Имя",
                "Отчество",
                "Дата рождения",
                "Пол",
                "Телефон",
                "e-mail",
                "Адрес проживания",
                "Серия паспорта",
                "Номер паспорта",
                "Дата выдачи",
                "Орган, выдавший паспорт",
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
                foreach (var patient in patients)
                {
                    // FIO (вычисляемое свойство)
                    worksheet.Cells[row, 1].Value = patient.LastName;
                    worksheet.Cells[row, 2].Value = patient.FirstName;
                    worksheet.Cells[row, 3].Value = patient.MiddleName;
                    worksheet.Cells[row, 4].Value = patient.BirthDate.ToShortDateString();

                    worksheet.Cells[row, 5].Value = patient.Gender;
                    worksheet.Cells[row, 6].Value = patient.PhoneNumber;
                    worksheet.Cells[row, 7].Value = patient.Email;
                    worksheet.Cells[row, 8].Value = patient.Address;
                    worksheet.Cells[row, 9].Value = patient.PassportSeries;
                    worksheet.Cells[row, 10].Value = patient.PassportNumber;
                    worksheet.Cells[row, 11].Value = patient.PassportIssueDate.ToShortDateString(); ;
                    worksheet.Cells[row, 12].Value = patient.PassportIssuingAuthority;
                    row++;
                }
                worksheet.Cells[1, 1, row - 1, headers.Count].AutoFitColumns();// Авто-подбор ширины колонок
                await package.SaveAsAsync(filePath);// Сохраняем файл
            }
            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex);
        }
    }
}
