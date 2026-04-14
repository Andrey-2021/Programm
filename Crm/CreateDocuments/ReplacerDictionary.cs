using Entities;

namespace CreateDocuments;

/// <summary>
/// Создание словаря ключей
/// </summary>
internal static class ReplacerDictionary
{
    /// <summary>
    /// Создать словарь соответствия ключей данным
    /// </summary>
    internal static Dictionary<string, string?> CreateTable(Contract contract, OrganizationInfo organization)
    {
        var replacements = new Dictionary<string, string?>
    {
        { "!1!", contract.Patient.FIO },
        { "!2!", contract.Patient.FullFIO },
        { "!3!", contract.Patient.BirthDate.Year.ToString() },
        { "!4!", contract.Patient.Address },
        { "!5!", contract.Patient.Gender.ToString() },
        { "!6!", contract.Patient.PhoneNumber },
        { "!7!", contract.Patient.Email },
        { "!10!", contract.Patient.PassportSeries },
        { "!11!", contract.Patient.PassportNumber },
        { "!12!", contract.Patient.PassportIssueDate.ToShortDateString() },
        { "!13!", contract.Patient.PassportIssuingAuthority },

        { "!101!", contract.ContractNumber },
        { "!102!", contract.ContractDate.ToShortDateString() },
        { "!103!", contract.StartDate.ToShortDateString() },
        { "!104!", contract.EndDate.ToShortDateString() },
        { "!105!", contract.TotalAmount.ToString() },
        { "!106!", contract.TotalAmountText },
        { "!107!", contract.PaymentStatus.ToString() },
        { "!108!", contract.ContractStatus.ToString() },
        { "!109!", contract.Notes },

        { "!201!", organization.FullName },                 // Полное наименование
        { "!202!", organization.ShortName },                // Сокращённое наименование
        { "!203!", organization.Bank },                     // Банк получателя
        { "!204!", organization.Address },                  // Адрес организации
        { "!205!", organization.Phone },                    // Телефон
        { "!206!", organization.Fax },                      // Факс
        { "!207!", organization.Email },                    // Электронная почта
        { "!208!", organization.EgryulCertificate },        // Свидетельство ЕГРЮЛ
        { "!209!", organization.IssuedBy },                 // Кем выдано
        { "!210!", organization.CertificateSeries },        // Серия свидетельства
        { "!211!", organization.CertificateNumber },        // Номер свидетельства
        { "!212!", organization.Inn },                      // ИНН
        { "!213!", organization.CheckingAccount },          // Расчётный счёт
        { "!214!", organization.Bik },                      // БИК
        { "!215!", organization.Ogrn },                     // ОГРН
        { "!216!", organization.HeadPosition },             // Должность руководителя
        { "!217!", organization.HeadFullName }              // ФИО руководителя
    };

        return replacements;
    }
}
