namespace InitDb;

/// <summary>
/// Отдельный класс для создания 10 экземпляров MedicalServiceType с конкретными данными.
/// </summary>
public static class MedicalServiceTypeSeeder
{
    /// <summary>
    /// Возвращает список из 10 видов услуг с заранее определёнными наименованиями.
    /// </summary>
    public static List<MedicalServiceType> GetSampleMedicalServiceTypes()
    {
        var MedicalServiceTypes = new List<MedicalServiceType>();

        MedicalServiceTypes.Add(new MedicalServiceType("Консультация"));
        MedicalServiceTypes.Add(new MedicalServiceType("Диагностика"));
        MedicalServiceTypes.Add(new MedicalServiceType("Лаборатория"));
        MedicalServiceTypes.Add(new MedicalServiceType("Процедура"));
        MedicalServiceTypes.Add(new MedicalServiceType("Стоматология"));
        MedicalServiceTypes.Add(new MedicalServiceType("Хирургия"));
        MedicalServiceTypes.Add(new MedicalServiceType("Физиотерапия"));
        MedicalServiceTypes.Add(new MedicalServiceType("Вакцинация"));
        MedicalServiceTypes.Add(new MedicalServiceType("Массаж"));
        MedicalServiceTypes.Add(new MedicalServiceType("Реабилитация"));
        return MedicalServiceTypes;
    }
}