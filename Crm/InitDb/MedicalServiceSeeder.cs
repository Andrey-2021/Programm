namespace InitDb;

/// <summary>
/// Отдельный класс для создания 20 экземпляров MedicalService с конкретными данными.
/// Поле ServiceId не заполняется (будет задано базой данных).
/// </summary>
public static class MedicalServiceSeeder
{
    /// <summary>
    /// Возвращает список из 20 медицинских услуг с заранее определёнными данными.
    /// </summary>
    public static List<MedicalService> GetSampleServices()
    {
        var services = new List<MedicalService>();

        // Добавляем 20 услуг, передавая данные непосредственно в конструктор.
        // ServiceId остаётся равным 0 (значение по умолчанию).
        services.Add(new MedicalService(
            serviceName: "Приём терапевта первичный",
            serviceType: "Консультация",
            serviceCode: "CONS_THER_01",
            servicePrice: 1500.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Приём терапевта повторный",
            serviceType: "Консультация",
            serviceCode: "CONS_THER_02",
            servicePrice: 1000.00m
        ));

        services.Add(new MedicalService(
            serviceName: "ЭКГ",
            serviceType: "Диагностика",
            serviceCode: "DIAG_CARD_01",
            servicePrice: 800.00m
        ));

        services.Add(new MedicalService(
            serviceName: "УЗИ брюшной полости",
            serviceType: "Диагностика",
            serviceCode: "DIAG_US_01",
            servicePrice: 2500.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Флюорография",
            serviceType: "Диагностика",
            serviceCode: "DIAG_XRAY_01",
            servicePrice: 600.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Анализ крови общий",
            serviceType: "Лаборатория",
            serviceCode: "LAB_BLOOD_01",
            servicePrice: 500.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Анализ крови биохимический",
            serviceType: "Лаборатория",
            serviceCode: "LAB_BLOOD_02",
            servicePrice: 1200.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Вакцинация от гриппа",
            serviceType: "Процедура",
            serviceCode: "PROC_VACC_01",
            servicePrice: 900.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Массаж спины (1 сеанс)",
            serviceType: "Процедура",
            serviceCode: "PROC_MASS_01",
            servicePrice: 1300.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Консультация хирурга",
            serviceType: "Консультация",
            serviceCode: "CONS_SURG_01",
            servicePrice: 1600.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Снятие швов",
            serviceType: "Процедура",
            serviceCode: "PROC_SUT_01",
            servicePrice: 700.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Физиотерапия (1 сеанс)",
            serviceType: "Процедура",
            serviceCode: "PROC_PHYS_01",
            servicePrice: 850.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Приём офтальмолога",
            serviceType: "Консультация",
            serviceCode: "CONS_OPHT_01",
            servicePrice: 1400.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Подбор очков",
            serviceType: "Консультация",
            serviceCode: "CONS_OPHT_02",
            servicePrice: 1100.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Стоматология: пломба световая",
            serviceType: "Стоматология",
            serviceCode: "DENT_FILL_01",
            servicePrice: 3500.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Стоматология: удаление зуба",
            serviceType: "Стоматология",
            serviceCode: "DENT_EXTR_01",
            servicePrice: 2800.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Кардиограмма с нагрузкой",
            serviceType: "Диагностика",
            serviceCode: "DIAG_CARD_02",
            servicePrice: 2000.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Рентген грудной клетки",
            serviceType: "Диагностика",
            serviceCode: "DIAG_XRAY_02",
            servicePrice: 1100.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Гастроскопия",
            serviceType: "Диагностика",
            serviceCode: "DIAG_END_01",
            servicePrice: 4000.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Кольпоскопия",
            serviceType: "Диагностика",
            serviceCode: "DIAG_GYN_01",
            servicePrice: 2200.00m
        ));

        return services;
    }
}