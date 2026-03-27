using OfficeOpenXml;
namespace CreateDocuments;

internal class ExcelKeyReplacer
{
    /// <summary>
    /// Заменяет ключи в указанном листе Excel файла (по имени листа).
    /// </summary>
    public static bool ReplaceKeys(string filePath, List<string> sheetNames, Dictionary<string, string?> replacements)
    {
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
            package.Save();
        }
        return true;
    }
}
