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
    public static List<MedicalService> GetSampleServices(List<MedicalServiceType> medicalServiceTypes)
    {
        var services = new List<MedicalService>();

        // Добавляем 20 услуг, передавая данные непосредственно в конструктор.
        // ServiceId остаётся равным 0 (значение по умолчанию).
        services.Add(new MedicalService(
            serviceName: "Приём терапевта первичный",
            serviceType: medicalServiceTypes[0],
            serviceCode: "CONS_THER_01",
            servicePrice: 1500.00m,
            10
        ));

        services.Add(new MedicalService(
            serviceName: "Приём терапевта повторный",
            serviceType: medicalServiceTypes[1],
            serviceCode: "CONS_THER_02",
            servicePrice: 1000.00m,
            10
        ));

        services.Add(new MedicalService(
            serviceName: "ЭКГ",
            serviceType: medicalServiceTypes[2],
            serviceCode: "DIAG_CARD_01",
            servicePrice: 800.00m,
            22
        ));

        services.Add(new MedicalService(
            serviceName: "УЗИ брюшной полости",
            serviceType: medicalServiceTypes[3],
            serviceCode: "DIAG_US_01",
            servicePrice: 2500.00m,
            22
        ));

        services.Add(new MedicalService(
            serviceName: "Флюорография",
            serviceType: medicalServiceTypes[4],
            serviceCode: "DIAG_XRAY_01",
            servicePrice: 600.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Анализ крови общий",
            serviceType: medicalServiceTypes[5],
            serviceCode: "LAB_BLOOD_01",
            servicePrice: 500.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Анализ крови биохимический",
            serviceType: medicalServiceTypes[6],
            serviceCode: "LAB_BLOOD_02",
            servicePrice: 1200.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Вакцинация от гриппа",
            serviceType: medicalServiceTypes[7],
            serviceCode: "PROC_VACC_01",
            servicePrice: 900.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Массаж спины (1 сеанс)",
            serviceType: medicalServiceTypes[8],
            serviceCode: "PROC_MASS_01",
            servicePrice: 1300.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Консультация хирурга",
            serviceType: medicalServiceTypes[9],
            serviceCode: "CONS_SURG_01",
            servicePrice: 1600.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Снятие швов",
            serviceType: medicalServiceTypes[0],
            serviceCode: "PROC_SUT_01",
            servicePrice: 700.00m,10
        ));

        services.Add(new MedicalService(
            serviceName: "Физиотерапия (1 сеанс)",
            serviceType: medicalServiceTypes[1],
            serviceCode: "PROC_PHYS_01",
            servicePrice: 850.00m,
            10
        ));

        services.Add(new MedicalService(
            serviceName: "Приём офтальмолога",
            serviceType: medicalServiceTypes[2],
            serviceCode: "CONS_OPHT_01",
            servicePrice: 1400.00m,
            22
        ));

        services.Add(new MedicalService(
            serviceName: "Подбор очков",
            serviceType: medicalServiceTypes[3],
            serviceCode: "CONS_OPHT_02",
            servicePrice: 1100.00m,
            22
        ));

        services.Add(new MedicalService(
            serviceName: "Стоматология: пломба световая",
            serviceType: medicalServiceTypes[4],
            serviceCode: "DENT_FILL_01",
            servicePrice: 3500.00m
        ));

        services.Add(new MedicalService(
            serviceName: "Стоматология: удаление зуба",
            serviceType: medicalServiceTypes[5],
            serviceCode: "DENT_EXTR_01",
            servicePrice: 2800.00m,
            10
        ));

        services.Add(new MedicalService(
            serviceName: "Кардиограмма с нагрузкой",
            serviceType: medicalServiceTypes[6],
            serviceCode: "DIAG_CARD_02",
            servicePrice: 2000.00m,
            10
        ));

        services.Add(new MedicalService(
            serviceName: "Рентген грудной клетки",
            serviceType: medicalServiceTypes[7],
            serviceCode: "DIAG_XRAY_02",
            servicePrice: 1100.00m,
            22
        ));

        services.Add(new MedicalService(
            serviceName: "Гастроскопия",
            serviceType: medicalServiceTypes[8],
            serviceCode: "DIAG_END_01",
            servicePrice: 4000.00m,
            22
        ));

        services.Add(new MedicalService(
            serviceName: "Кольпоскопия",
            serviceType: medicalServiceTypes[9],
            serviceCode: "DIAG_GYN_01",
            servicePrice: 2200.00m
        ));

        return services;
    }
}