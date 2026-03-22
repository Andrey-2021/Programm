using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CreateDocuments;

public class WordReplacer
{
    /// <summary>
    /// Заменяет в документе Word маркеры вида !N! на указанные строки.
    /// </summary>
    /// <param name="filePath">Путь к файлу .docx</param>
    /// <param name="replacements">Словарь: ключ — маркер (например "!1!"), значение — текст для замены</param>
    public static void ReplacePlaceholders(string filePath, Dictionary<string, string> replacements)
    {
        using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, true))
        {
            // Находим все текстовые элементы в документе
            var texts = doc.MainDocumentPart.Document.Descendants<Text>().ToList();

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

            // Опционально: обработать колонтитулы
            //var headerParts = doc.MainDocumentPart.HeaderParts;
            //foreach (var header in headerParts)
            //{
            //    ReplaceInHeaderFooter(header.Header, replacements);
            //}

            //var footerParts = doc.MainDocumentPart.FooterParts;
            //foreach (var footer in footerParts)
            //{
            //    ReplaceInHeaderFooter(footer.Footer, replacements);
            //}
        }
    }

    private static void ReplaceInHeaderFooter(OpenXmlElement element, Dictionary<string, string> replacements)
    {
        if (element == null) return;
        var texts = element.Descendants<Text>().ToList();
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
    }
}
