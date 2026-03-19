namespace Entities;

internal class LengthConstants
{
    /// <summary>
	/// Минимальная длина фамилии
	/// </summary>
	public const byte lastNameMinLength = 4;
    /// <summary>
    /// Максимальная длина фамилии
    /// </summary>
    public const int lastNameMaxLength = 255;

    /// <summary>
	/// Минимальная длина имени
	/// </summary>
	public const byte firstNameMinLength = 4;
    /// <summary>
    /// Максимальная длина имени
    /// </summary>
    public const int firstNameMaxLength = 255;

    /// <summary>
	/// Минимальная длина отчества
	/// </summary>
	public const byte middleNameMinLength = 4;
    /// <summary>
    /// Максимальная длина отчества
    /// </summary>
    public const int middleNameMaxLength = 255;
        
    /// <summary>
    /// Минимальная длина телефона
    /// </summary>
    public const byte phonetMinLength = 5;
    /// <summary>
    /// Максимальная длина телефона
    /// </summary>
    public const byte phonetMaxLength = 25;

    /// <summary>
    /// Максимальная длина e-mail
    /// </summary>
    public const byte emailMaxLength = 254;
    /// <summary>
    /// Минимальная длина e-mail
    /// </summary>
    public const byte emailMinLength = 5;

    /// <summary>
    /// Максимальная длина e-mail
    /// </summary>
    public const byte addressMaxLength = 254;
    /// <summary>
    /// Минимальная длина e-mail
    /// </summary>
    public const byte addressMinLength = 5;

    /// <summary>
    /// Максимальная длина Серия паспорта
    /// </summary>
    public const byte passportSeriesMaxLength = 254;
    /// <summary>
    /// Минимальная длина Серия паспорта
    /// </summary>
    public const byte passportSeriesMinLength = 5;

    /// <summary>
    /// Максимальная длина - Номер паспорта
    /// </summary>
    public const byte passportNumberMaxLength = 254;
    /// <summary>
    /// Минимальная длина - Номер паспорта
    /// </summary>
    public const byte passportNumberMinLength = 5;

    /// <summary>
    /// Максимальная длина - Орган, выдавший паспорт
    /// </summary>
    public const byte passportIssuingAuthorityMaxLength = 254;
    /// <summary>
    /// Минимальная длина - Орган, выдавший паспорт
    /// </summary>
    public const byte passportIssuingAuthorityMinLength = 5;

    /// <summary>
    /// Максимальная длина - Должность
    /// </summary>
    public const byte positionMaxLength = 254;
    /// <summary>
    /// Минимальная длина - Должность
    /// </summary>
    public const byte positionMinLength = 5;


    // Наименование услуги
    public const int serviceNameMaxLength = 255;
    public const int serviceNameMinLength = 2;

    // Вид услуги
    public const int serviceTypeMaxLength = 255;
    public const int serviceTypeMinLength = 2;

    // Код услуги
    public const int serviceCodeMaxLength = 50;
    public const int serviceCodeMinLength = 1;

    public const int contractNumberMaxLength = 50;
    public const int contractNumberMinLength = 1;

    public const int totalAmountTextMaxLength = 4000; 
    public const int totalAmountTextMinLength = 5;

    public const int paymentStatusMaxLength = 20;
    public const int paymentStatusMinLength = 2;

    public const int contractStatusMaxLength = 20;
    public const int contractStatusMinLength = 2;

    public const int notesMaxLength = 4000;

    /// <summary>
    /// Минимальная длина название должности
    /// </summary>
    public const byte positionNameMinLength = 4;
    /// <summary>
    /// Максимальная длина название должности
    /// </summary>
    public const int positionNameMaxLength = 255;

    /// <summary>
    /// Минимальная длина Login
    /// </summary>
    public const byte loginMinLength = 4;
    /// <summary>
    /// Максимальная длина Login
    /// </summary>
    public const int loginMaxLength = 50;

    /// <summary>
    /// Минимальная длина Пароля
    /// </summary>
    public const byte passwordMinLength = 4;
    /// <summary>
    /// Максимальная длина Пароля
    /// </summary>
    public const int passwordMaxLength = 50;
}
