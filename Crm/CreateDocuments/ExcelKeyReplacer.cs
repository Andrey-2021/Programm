using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Entities;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO.Packaging;
namespace CreateDocuments;

/// <summary>
/// Замена ключей в Excel-файле
/// </summary>
internal class ExcelKeyReplacer
{
    private const string tableKey = "!301!";

    /// <summary>
    /// Заменяет ключи в указанном листе Excel файла (по имени листа).
    /// </summary>
    public static bool ReplaceKeys(string filePath, Dictionary<string, string?> replacements, Contract contract)
    {
        List<string> sheetNames = new List<string> { "Договор", "Перечень", "Акт" };

        if (string.IsNullOrEmpty(filePath))
            throw new ArgumentException("Путь к файлу не указан.", nameof(filePath));
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Файл не найден.", filePath);
        if (!(sheetNames?.Count > 0))
            throw new ArgumentException("Имя листов не указано.", nameof(sheetNames));
        if (replacements == null || replacements.Count == 0)
            return true;

        ExcelPackage.License.SetNonCommercialPersonal("KeyReplacer");


        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            foreach (var item in sheetNames)
            {
                var sheetName = item;
                var worksheet = package.Workbook.Worksheets[sheetName];
                if (worksheet == null)
                    throw new InvalidOperationException($"Лист с именем \"{sheetName}\" не найден.");

                // Далее код замены аналогичен предыдущему методу (дублируется, можно вынести в отдельный метод)
                var dimension = worksheet.Dimension;
                if (dimension == null)
                    return true;

                for (int row = dimension.Start.Row; row <= dimension.End.Row; row++)
                {
                    for (int col = dimension.Start.Column; col <= dimension.End.Column; col++)
                    {
                        var cell = worksheet.Cells[row, col];
                        if (cell.Value is string cellValue && !string.IsNullOrEmpty(cellValue))
                        {
                            string newValue = cellValue;
                            bool changed = false;

                            foreach (var kvp in replacements)
                            {
                                string key = kvp.Key;
                                string? replacement = kvp.Value ?? string.Empty;

                                if (newValue.Contains(key))
                                {
                                    newValue = newValue.Replace(key, replacement);
                                    changed = true;
                                }
                            }

                            if (changed)
                                cell.Value = newValue;
                        }
                    }
                }
            }

            SetTableInExcelListEnumeration(package, "Перечень", contract);
            SetTableInExcelListAct(package, "Акт", contract);
            package.Save();
        }
        return true;
    }

    /// <summary>
    /// Заполнение страницы Перечень
    /// </summary>
    /// <param name="sheetName">Имя страницы</param>
    /// <param name="contract">Данные</param>
    private static void SetTableInExcelListEnumeration(ExcelPackage package, string sheetName, Contract contract)
    {
        var worksheet = package.Workbook.Worksheets[sheetName];
        var dimension = worksheet.Dimension;
        if (dimension == null)
            return;

        for (int row = dimension.Start.Row; row <= dimension.End.Row; row++)
        {
            var cell = worksheet.Cells[row, 1];
            if (cell.Value is string cellValue && !string.IsNullOrEmpty(cellValue))
            {
                string newValue = cellValue;
                if (newValue.Contains(tableKey))
                {
                    if (contract.ContractItems == null || contract.ContractItems.Count == 0)
                    {
                        //Удаляем пустую строку
                        cell.Value = string.Empty;
                        return;
                    }

                    for (int i = 0; i < contract.ContractItems.Count; i++)
                    {
                        var item = contract.ContractItems[i];
                        worksheet.Cells[row+i, 1].Value = i + 1;
                        worksheet.Cells[row + i, 2].Value = item.MedicalService?.ServiceName;
                        worksheet.Cells[row + i, 3].Value = item.Quantity;
                        worksheet.Cells[row + i, 4].Value = item.Price;
                        worksheet.Cells[row + i, 5].Value = item.NdsPercent;
                        worksheet.Cells[row + i, 6].Value = item.PriceWithNds;
                        worksheet.Cells[row + i, 7].Value = item.Discount;
                        worksheet.Cells[row + i, 8].Value = item.ItemTotal;

                        // задаём границы
                        SetBorder(worksheet.Cells[row + i, 1, row + i, 9]);
                        // Число с двумя десятичными знаками
                        worksheet.Cells[row + i, 4, row + i, 8].Style.Numberformat.Format = "0.00";


                        worksheet.Cells[row + i, 9].Value = contract.StartDate.ToShortDateString()
                            +" - "+ contract.EndDate.ToShortDateString();

                        if (i != contract.ContractItems.Count - 1)
                            worksheet.InsertRow(row + i + 1, 1); // сдвигает строку 4 и ниже вниз
                    }
                    worksheet.Cells[row+ contract.ContractItems.Count, 8].Value = contract.ContractItems.Sum(x=>x.ItemTotal);
                }
            }
        }
    }

    /// <summary>
    /// Заполнение страницы Акт
    /// </summary>
    private static void SetTableInExcelListAct(ExcelPackage package, string sheetName, Contract contract)
    {
        var worksheet = package.Workbook.Worksheets[sheetName];
        var dimension = worksheet.Dimension;
        if (dimension == null)
            return;

        for (int row = dimension.Start.Row; row <= dimension.End.Row; row++)
        {
            var cell = worksheet.Cells[row, 1];
            if (cell.Value is string cellValue && !string.IsNullOrEmpty(cellValue))
            {
                string newValue = cellValue;
                if (newValue.Contains(tableKey))
                {
                    if (contract.ContractItems == null || contract.ContractItems.Count == 0)
                    {
                        //Удаляем пустую строку
                        cell.Value = string.Empty;
                        return;
                    }

                    for (int i = 0; i < contract.ContractItems.Count; i++)
                    {
                        var item = contract.ContractItems[i];
                        worksheet.Cells[row + i, 1].Value = i + 1;
                        worksheet.Cells[row + i, 2].Value = item.MedicalService?.ServiceName;
                        worksheet.Cells[row + i, 6].Value = item.Quantity;
                        worksheet.Cells[row + i, 7].Value = item.Price;
                        worksheet.Cells[row + i, 8].Value = item.PriceWithNds;
                        worksheet.Cells[row + i, 9].Value = item.Discount;
                        worksheet.Cells[row + i, 10].Value = item.ItemTotal;

                        // задаём границы
                        SetBorder(worksheet.Cells[row + i, 2, row + i, 5], true, true, false, false);
                        SetBorder(worksheet.Cells[row + i, 1]);
                        SetBorder(worksheet.Cells[row + i, 6, row + i, 10]);
                        // Число с двумя десятичными знаками
                        worksheet.Cells[row + i, 7, row + i, 10].Style.Numberformat.Format = "0.00";

                        if (i != contract.ContractItems.Count - 1)
                            worksheet.InsertRow(row + i + 1, 1); // сдвигает строку ниже вниз
                    }
                    worksheet.Cells[row + contract.ContractItems.Count, 10].Value = contract.ContractItems.Sum(x => x.ItemTotal);
                }
            }
        }
    }

    /// <summary>
    /// Установить границы ячеек
    /// </summary>
    private static void SetBorder(ExcelRange cells, bool isTop=true, bool isBottom=true, bool isLeft=true, bool isRight=true)
    {
        if(isTop) cells.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        if (isBottom) cells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        if (isLeft) cells.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        if (isRight) cells.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        // задать цвет границы
        //cell.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
    }
}
