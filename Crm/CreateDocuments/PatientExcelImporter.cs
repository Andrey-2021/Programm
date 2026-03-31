using Entities;
using Entities.Enums;
using OfficeOpenXml;
using System.Globalization;
namespace CreateDocuments;

/// <summary>
/// Импортирует данные пациентов из Excel-файла.
/// </summary>
// Поиск листа – сначала ищется лист с именем «Пациенты», иначе берётся первый.
// Чтение данных – начиная со второй строки (первая — заголовки). Как только в первой колонке встречается пустое значение, чтение прекращается.

public class PatientExcelImporter
{
    /// <summary>
    /// Импортирует данные пациентов из Excel-файла.
    /// </summary>
    /// <param name="filePath">Путь к файлу .xlsx.</param>
    /// <returns>Кортеж: успешность, список пациентов, исключение (если есть).</returns>
    public static async Task<(List<Patient>? patients, Exception? ex)> ImportFromExcel(string filePath)
    {
        try
        {
            ExcelPackage.License.SetNonCommercialPersonal("Diplom");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Файл не найден", filePath);

            var patients = new List<Patient>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                // Пытаемся найти лист "Пациенты", иначе берём первый
                var worksheet = package.Workbook.Worksheets["Пациенты"] ?? package.Workbook.Worksheets[0];
                if (worksheet == null)
                    throw new InvalidOperationException("В файле нет листов.");

                int row = 2; // Первая строка — заголовки
                while (true)
                {
                    // Проверяем, что в первой колонке есть непустое значение (фамилия)
                    string lastName = worksheet.Cells[row, 1].Text?.Trim();
                    if (string.IsNullOrWhiteSpace(lastName))
                        break; // данные закончились

                    string firstName = worksheet.Cells[row, 2].Text?.Trim();
                    string middleName = worksheet.Cells[row, 3].Text?.Trim();
                    string birthDateStr = worksheet.Cells[row, 4].Text?.Trim();
                    string genderStr = worksheet.Cells[row, 5].Text?.Trim();
                    string phoneNumber = worksheet.Cells[row, 6].Text?.Trim();
                    string email = worksheet.Cells[row, 7].Text?.Trim();
                    string address = worksheet.Cells[row, 8].Text?.Trim();
                    string passportSeries = worksheet.Cells[row, 9].Text?.Trim();
                    string passportNumber = worksheet.Cells[row, 10].Text?.Trim();
                    string passportIssueDateStr = worksheet.Cells[row, 11].Text?.Trim();
                    string passportIssuingAuthority = worksheet.Cells[row, 12].Text?.Trim();

                    // Преобразование дат (формат dd.MM.yyyy)
                    if (!DateTime.TryParseExact(birthDateStr, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate))
                        throw new FormatException($"Некорректный формат даты рождения в строке {row}: '{birthDateStr}'");

                    if (!DateTime.TryParseExact(passportIssueDateStr, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime passportIssueDate))
                        throw new FormatException($"Некорректный формат даты выдачи паспорта в строке {row}: '{passportIssueDateStr}'");

                    // Преобразование пола (ожидаются значения Male/Female)
                    GenderEnum? gender = null;
                    if (!string.IsNullOrEmpty(genderStr))
                    {
                        if (Enum.TryParse<GenderEnum>(genderStr, true, out var parsedGender))
                            gender = parsedGender;
                        else
                            throw new FormatException($"Некорректное значение пола в строке {row}: '{genderStr}'");
                    }

                    var patient = new Patient
                    {
                        LastName = lastName,
                        FirstName = firstName,
                        MiddleName = middleName,
                        BirthDate = birthDate,
                        Gender = gender,
                        PhoneNumber = phoneNumber,
                        Email = email,
                        Address = address,
                        PassportSeries = passportSeries,
                        PassportNumber = passportNumber,
                        PassportIssueDate = passportIssueDate,
                        PassportIssuingAuthority = passportIssuingAuthority
                    };

                    patients.Add(patient);
                    row++;
                }
            }

            return (patients, null);
        }
        catch (Exception ex)
        {
            return (null, ex);
        }
    }
}