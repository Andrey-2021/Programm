using System.Runtime.CompilerServices;
namespace Entities;

/// <summary>
/// Класс, содержащий реквизиты организации для использования в документах (договоры, счета, платёжные поручения и т.п.)
/// </summary>
public class OrganizationInfo : BaseINotifyDataErrorInfo, IHaveId
{
    /// <summary>
    /// Id (ключевое поле)
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Полное официальное наименование организации.
    /// </summary>
    public string FullName
    {
        get => fullName;
        set { fullName = value; OnPropertyChanged(); }
    }
    private string fullName;

    /// <summary>
    /// Сокращённое наименование организации.
    /// </summary>
    public string ShortName
    {
        get => shortName;
        set { shortName = value; OnPropertyChanged(); }
    }
    private string shortName;

    /// <summary>
    /// Банк получателя платежа (для платёжных поручений).
    /// </summary>
    public string Bank
    {
        get => bank;
        set { bank = value; OnPropertyChanged(); }
    }
    private string bank;

    /// <summary>
    /// Адрес организации (юридический/фактический).
    /// </summary>
    public string Address
    {
        get => address;
        set { address = value; OnPropertyChanged(); }
    }
    private string address;

    /// <summary>
    /// Телефон организации.
    /// </summary>
    public string Phone
    {
        get => phone;
        set { phone = value; OnPropertyChanged(); }
    }
    private string phone;

    /// <summary>
    /// Факс организации.
    /// </summary>
    public string Fax
    {
        get => fax;
        set { fax = value; OnPropertyChanged(); }
    }
    private string fax;

    /// <summary>
    /// Электронный адрес (e-mail) организации.
    /// </summary>
    public string Email
    {
        get => email;
        set { email = value; OnPropertyChanged(); }
    }
    private string email;

    /// <summary>
    /// Свидетельство о внесении записи в ЕГРЮЛ (название документа).
    /// </summary>
    public string EgryulCertificate
    {
        get => egryulCertificate;
        set { egryulCertificate = value; OnPropertyChanged(); }
    }
    private string egryulCertificate;

    /// <summary>
    /// Орган, выдавший свидетельство (МИФНС России № ...).
    /// </summary>
    public string IssuedBy
    {
        get => issuedBy;
        set { issuedBy = value; OnPropertyChanged(); }
    }
    private string issuedBy;

    /// <summary>
    /// Серия свидетельства.
    /// </summary>
    public string CertificateSeries
    {
        get => certificateSeries;
        set { certificateSeries = value; OnPropertyChanged(); }
    }
    private string certificateSeries;

    /// <summary>
    /// Номер свидетельства.
    /// </summary>
    public string CertificateNumber
    {
        get => certificateNumber;
        set { certificateNumber = value; OnPropertyChanged(); }
    }
    private string certificateNumber;

    /// <summary>
    /// ИНН организации.
    /// </summary>
    public string Inn
    {
        get => inn;
        set { inn = value; OnPropertyChanged(); }
    }
    private string inn;

    /// <summary>
    /// Расчётный счёт организации.
    /// </summary>
    public string CheckingAccount
    {
        get => checkingAccount;
        set { checkingAccount = value; OnPropertyChanged(); }
    }
    private string checkingAccount;

    /// <summary>
    /// БИК банка организации.
    /// </summary>
    public string Bik
    {
        get => bik;
        set { bik = value; OnPropertyChanged(); }
    }
    private string bik;

    /// <summary>
    /// ОГРН организации.
    /// </summary>
    public string Ogrn
    {
        get => ogrn;
        set { ogrn = value; OnPropertyChanged(); }
    }
    private string ogrn;

    /// <summary>
    /// Должность руководителя (например, Генеральный директор).
    /// </summary>
    public string HeadPosition
    {
        get => headPosition;
        set { headPosition = value; OnPropertyChanged(); }
    }
    private string headPosition;

    /// <summary>
    /// Фамилия, Имя, Отчество руководителя в формате "Фамилия И.О.".
    /// </summary>
    public string HeadFullName
    {
        get => headFullName;
        set { headFullName = value; OnPropertyChanged(); }
    }
    private string headFullName;
}