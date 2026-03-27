using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
namespace CreateDocuments;

internal class DocKeyReplacer
{
    internal static void ReplaceKeys(string docFile, Dictionary<string, string?> replacements)
    {
        using (WordprocessingDocument doc = WordprocessingDocument.Open(docFile, true))
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
            doc.Save();
        }
    }
}
