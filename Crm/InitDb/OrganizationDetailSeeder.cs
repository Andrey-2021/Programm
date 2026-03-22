namespace InitDb;

public class OrganizationDetailSeeder
{
    /// <summary>
    /// Метод для заполнения данных об одной медицинской организации города Москвы.
    /// </summary>
    public static OrganizationInfo GetMoscowMedicalOrganization()
    {
        return new OrganizationInfo
        {
            FullName = "Государственное бюджетное учреждение здравоохранения города Москвы «Городская поликлиника № 68 Департамента здравоохранения города Москвы»",
            ShortName = "ГБУЗ «ГП № 68 ДЗМ»",
            Bank = "ГУ Банка России по ЦФО г. Москва",
            Address = "г. Москва, ул. Академика Варги, д. 12, стр. 1",
            Phone = "+7 (495) 123-45-67",
            Fax = "+7 (495) 123-45-68",
            Email = "gp68@zdrav.mos.ru",
            EgryulCertificate = "Свидетельство о внесении записи в Единый государственный реестр юридических лиц",
            IssuedBy = "МИФНС России № 46 по г. Москве",
            CertificateSeries = "77",
            CertificateNumber = "0123456789",
            Inn = "772345678901",
            CheckingAccount = "40702810900000012345",
            Bik = "044525987",
            Ogrn = "1037700123456",
            HeadPosition = "Главный врач",
            HeadFullName = "Соколова М.И."
        };
    }
}
