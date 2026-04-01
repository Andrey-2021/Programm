using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Entities;
namespace CreateDocuments;

internal class DocKeyReplacer
{
    /// <summary>
    /// Заменяет в документе Word маркеры вида !N! на указанные строки.
    /// </summary>
    /// <param name="docFile">Путь к файлу .docx</param>
    /// <param name="replacements">Словарь: ключ — маркер (например "!1!"), значение — текст для замены</param>
    internal static void ReplaceKeys(string docFile, Dictionary<string, string?> replacements, Contract contract, string marker = "!301!")
    {
        using (WordprocessingDocument doc = WordprocessingDocument.Open(docFile, true))
        {
            // Находим все текстовые элементы в документе
            var texts = doc.MainDocumentPart.Document.Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>().ToList();

            // Заменяем в каждом текстовом элементе
            foreach (var text in texts)
            {
                if (text.Text != null && replacements.Keys.Any(key => text.Text.Contains(key)))
                {
                    string newText = text.Text;
                    foreach (var kvp in replacements)
                    {
                        newText = newText.Replace(kvp.Key, kvp.Value);
                    }
                    text.Text = newText;
                }
            }

            // Вставляем таблицу
            Body body = doc.MainDocumentPart.Document.Body;
            // Найти параграф с "!301!"
            var mainPart = doc.MainDocumentPart;
            // Ищем абзац, содержащий маркер
            var paragraphs = mainPart.Document.Descendants<Paragraph>().ToList();
            Paragraph? markerParagraph = null;
            foreach (var para in paragraphs)
            {
                if (para.Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>().Any(t => t.Text.Contains(marker)))
                {
                    markerParagraph = para;
                    break;
                }
            }

            if (markerParagraph != null)
            {
                // Получить позицию маркера
                OpenXmlElement markerParent = markerParagraph.Parent;
                // Создать таблицу
                var data = contract.ContractItems?.Select(x => x.MedicalService?.ServiceName).ToList();
                Table table = CreateTable(data);
                // Заменить параграф на таблицу
                markerParent.InsertBefore(table, markerParagraph);
                markerParent.RemoveChild(markerParagraph);
            }
            doc.Save();
        }
    }
    
    private static Table CreateTable(List<string> data)
    {
        Table table = new Table();
        table.Append(new TableProperties(
            new TableBorders(
                new TopBorder() { Val = BorderValues.Single, Size = 6 },
                new LeftBorder() { Val = BorderValues.Single, Size = 6 },
                new RightBorder() { Val = BorderValues.Single, Size = 6 },
                new BottomBorder() { Val = BorderValues.Single, Size = 6 },
                new InsideHorizontalBorder() { Val = BorderValues.Single, Size = 6 },
                new InsideVerticalBorder() { Val = BorderValues.Single, Size = 6 }
            )
        ));
               

        // Заголовок
        TableRow headerRow = new TableRow();
        headerRow.Append(new TableCell(
                                        new Paragraph(new Run(GetStyle(), new DocumentFormat.OpenXml.Wordprocessing.Text("№ п/п") ))
                                        {
                                            ParagraphProperties = new ParagraphProperties(new Justification()
                                                            { 
                                                                Val = JustificationValues.Center 
                                                            }
                                                          )
                                        }
                                    )
                            { 
                                TableCellProperties = new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "1500" }) 
                            }
                        );

        headerRow.Append(new TableCell(
            new Paragraph(new Run(GetStyle(), new DocumentFormat.OpenXml.Wordprocessing.Text("Вид медицинского вмешательства"))) { ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Center }) }
        )
        { TableCellProperties = new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "8000" }) });
        table.Append(headerRow);

        // Строки с данными
        for (int i = 0; i < data.Count; i++)
        {
            TableRow dataRow = new TableRow();
            dataRow.Append(new TableCell(
                new Paragraph(new Run(GetStyle(), new DocumentFormat.OpenXml.Wordprocessing.Text((i + 1).ToString()))) { ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Center }) }
            )
            { TableCellProperties = new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "1500" }) });
            dataRow.Append(new TableCell(
                new Paragraph(new Run(GetStyle(), new DocumentFormat.OpenXml.Wordprocessing.Text(data[i])))
            )
            { TableCellProperties = new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "8000" }) });
            table.Append(dataRow);
        }

        return table;
    }

    private static RunProperties GetStyle()
    {
        // Свойства шрифта и размера
        RunProperties runProperties = new RunProperties();
        runProperties.AppendChild(new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman", EastAsia = "Times New Roman" });
        runProperties.AppendChild(new FontSize() { Val = "18" }); // 12 pt = 24 half-points
        return runProperties;
    }
}
