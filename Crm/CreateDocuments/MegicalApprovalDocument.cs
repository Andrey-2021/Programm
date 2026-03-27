using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Entities;
namespace CreateDocuments;

public class MegicalApprovalDocument
{
    private const string soglasieFileName = "forma_soglasiia.docx";
    private const string dogovorFileName = "Dogovor_i_prilozheniia.xlsx";

    public static (bool result, Exception? ex) CreateDoc(Contract contract, OrganizationInfo organizationInfo, string folder)
    {

        //        var replacements = new Dictionary<string, string>
        //{
        //    { "!1!", "Иванов Иван Иванович" },
        //    { "!2!", "20.03.2026" },
        //    { "!3!", "№ 123-А" }
        //};
        //        WordReplacer.ReplacePlaceholders(@"d:\1\dogovor.docx", replacements);
        //WordReplacer.ReplacePlaceholders(@"d:\1\dogovor.docx", replacements);


        // 1.Копируем документ в папку
        //var path2 = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        try
        {
            CopyDocument(folder);
            ModifyWordDocument(contract, organizationInfo, folder);
            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex);
        }
    }

    private static void ModifyWordDocument(Contract contract, OrganizationInfo organizationInfo, string folder)
    {
        var filePath = Path.Combine(folder, soglasieFileName);

        var replacements = new Dictionary<string, string?>
        {
            { "!1!", organizationInfo.FullName },
            { "!2!", contract.Patient?.FullFIO},
            { "!3!", contract.Patient?.BirthDate.Year.ToString() },
            { "!4!", contract.Patient?.Address },
            { "!5!", contract.ContractDate.ToShortDateString() }
        };

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
        }
    }


    /// <summary>
    /// Копируем исходные документы
    /// </summary>
    /// <param name="folder">Папка назначения</param>
    private static bool CopyDocument(string folder)
    {
        var basePath = System.AppDomain.CurrentDomain.BaseDirectory;

        var filesPath = Path.Combine(basePath, "TempDoc", soglasieFileName);
        if (!File.Exists(filesPath))
            throw new Exception("Отсутствует исходный документ " + soglasieFileName);
        File.Copy(filesPath, Path.Combine(folder, soglasieFileName), true);

        filesPath = Path.Combine(basePath, "TempDoc", dogovorFileName);
        if (!File.Exists(filesPath))
            throw new Exception("Отсутствует исходный документ " + dogovorFileName);
        File.Copy(filesPath, Path.Combine(folder, dogovorFileName), true);

        return true;
    }
}
