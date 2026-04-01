using Entities;
namespace CreateDocuments;

/// <summary>
/// Документы на согласие мед.процедур
/// </summary>
public class MegicalApprovalDocument
{
    private const string soglasieFileName = "forma_soglasiia.docx";
    private const string dogovorFileName = "Dogovor_i_prilozheniia.xlsx";

    public static (bool result, Exception? ex) CreateDoc(Contract contract, OrganizationInfo organizationInfo, string folder)
    {
        try
        {
            CopyDocument(folder); // Копируем документ в папку
            var dic = ReplacerDictionary.CreateTable(contract, organizationInfo);

            DocKeyReplacer.ReplaceKeys(Path.Combine(folder, soglasieFileName), dic, contract); // Модифицируем Word-документ
            ExcelKeyReplacer.ReplaceKeys(Path.Combine(folder, dogovorFileName),  dic, contract); // Модифицируем Excel-документ
            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex);
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
