using Entities.Enums;

namespace InitDb;

/// <summary>
/// Отдельный класс для создания 20 экземпляров Contract с конкретными данными.
/// Поле ContractId не заполняется (будет задано базой данных).
/// </summary>
public static class ContractSeeder
{
    /// <summary>
    /// Возвращает список из 20 договоров с заранее определёнными данными.
    /// </summary>
    public static List<Contract> GetSampleContracts(List<Patient> patients, List<Employee> employees)
    {
        var contracts = new List<Contract>();

        // Добавляем 20 договоров, передавая данные непосредственно в конструктор.
        // ContractId остаётся равным 0 (значение по умолчанию).
        contracts.Add(new Contract(
            patient: patients[0],
            contractDate: new DateTime(2023, 1, 15),
            contractNumber: "Д-2023-001",
            startDate: new DateTime(2023, 1, 15),
            endDate: new DateTime(2023, 12, 31),
            totalAmount: 15000.00m,
            paymentStatus: PaymentStatusEnum.Оплачен,
            contractStatus: ContractStatusEnum.Действует,
            notes: "Ежегодное обслуживание",
            responsibleEmployee: employees[0]
        ));

        contracts.Add(new Contract(
           patient: patients[1],
           contractDate: new DateTime(2023, 2, 10),
           contractNumber: "Д-2023-002",
           startDate: new DateTime(2023, 2, 10),
           endDate: new DateTime(2023, 5, 10),
           totalAmount: 8500.00m,
           paymentStatus: PaymentStatusEnum.Оплачен_частично,
           contractStatus: ContractStatusEnum.Действует,
           notes: "Лечебный курс",
           responsibleEmployee: employees[1]
       ));

        contracts.Add(new Contract(
            patient: patients[2],
            contractDate: new DateTime(2023, 3, 5),
            contractNumber: "Д-2023-003",
            startDate: new DateTime(2023, 3, 5),
            endDate: new DateTime(2023, 4, 5),
            totalAmount: 3200.00m,
            paymentStatus: PaymentStatusEnum.Не_оплачен,
            contractStatus: ContractStatusEnum.Расторгнут,
            notes: "Отказ пациента",
            responsibleEmployee: employees[2]
        ));

        contracts.Add(new Contract(
            patient: patients[3],
            contractDate: new DateTime(2023, 4, 12),
            contractNumber: "Д-2023-004",
            startDate: new DateTime(2023, 4, 12),
            endDate: new DateTime(2024, 4, 11),
            totalAmount: 45000.00m,
            paymentStatus: PaymentStatusEnum.Оплачен,
            contractStatus: ContractStatusEnum.Действует,
            notes: "Годовой абонемент",
            responsibleEmployee: employees[3]
        ));

        contracts.Add(new Contract(
            patient: patients[4],
            contractDate: new DateTime(2023, 5, 20),
            contractNumber: "Д-2023-005",
            startDate: new DateTime(2023, 5, 20),
            endDate: new DateTime(2023, 8, 20),
            totalAmount: 12400.00m,
            paymentStatus: PaymentStatusEnum.Оплачен,
            contractStatus: ContractStatusEnum.Действует,
            notes: "Комплексное обследование",
            responsibleEmployee: employees[4]
        ));




        contracts.Add(new Contract(
            patient: patients[4],
            contractDate: new DateTime(2023, 6, 1),
            contractNumber: "Д-2023-006",
            startDate: new DateTime(2023, 6, 1),
            endDate: new DateTime(2023, 7, 1),
            totalAmount: 5600.00m,
            paymentStatus: PaymentStatusEnum.Оплачен,
            contractStatus: ContractStatusEnum.Завершён,
            notes: "Физиотерапия",
            responsibleEmployee: employees[5]
        ));

        contracts.Add(new Contract(
            patient: patients[5],
            contractDate: new DateTime(2023, 7, 8),
            contractNumber: "Д-2023-007",
            startDate: new DateTime(2023, 7, 8),
            endDate: new DateTime(2023, 10, 8),
            totalAmount: 21000.00m,
            paymentStatus: PaymentStatusEnum.Не_оплачен,
            contractStatus: ContractStatusEnum.Действует,
            notes: "Стоматология",
            responsibleEmployee: employees[5]
        ));

        contracts.Add(new Contract(
            patient: patients[5],
            contractDate: new DateTime(2023, 8, 15),
            contractNumber: "Д-2023-008",
            startDate: new DateTime(2023, 8, 15),
            endDate: new DateTime(2024, 2, 15),
            totalAmount: 37500.00m,
            paymentStatus: PaymentStatusEnum.Оплачен_частично,
            contractStatus: ContractStatusEnum.Действует,
            notes: "Ортодонтия",
            responsibleEmployee: employees[6]
        ));

        contracts.Add(new Contract(
            patient: patients[5],
            contractDate: new DateTime(2023, 9, 5),
            contractNumber: "Д-2023-009",
            startDate: new DateTime(2023, 9, 5),
            endDate: new DateTime(2023, 12, 5),
            totalAmount: 9300.00m,
            paymentStatus: PaymentStatusEnum.Оплачен,
            contractStatus: ContractStatusEnum.Действует,
            notes: "Массаж",
            responsibleEmployee: employees[7]
        ));

        contracts.Add(new Contract(
            patient: patients[6],
            contractDate: new DateTime(2023, 10, 1),
            contractNumber: "Д-2023-010",
            startDate: new DateTime(2023, 10, 1),
            endDate: new DateTime(2024, 10, 1),
            totalAmount: 60000.00m,
            paymentStatus: PaymentStatusEnum.Оплачен,
            contractStatus: ContractStatusEnum.Действует,
            notes: "Ведение беременности",
            responsibleEmployee: employees[7]
        ));

        contracts.Add(new Contract(
            patient: patients[7],
            contractDate: new DateTime(2023, 11, 12),
            contractNumber: "Д-2023-011",
            startDate: new DateTime(2023, 11, 12),
            endDate: new DateTime(2024, 5, 12),
            totalAmount: 28000.00m,
            paymentStatus: PaymentStatusEnum.Не_оплачен,
            contractStatus: ContractStatusEnum.Действует,
            notes: "Реабилитация",
            responsibleEmployee: employees[8]
        ));

        contracts.Add(new Contract(
            patient: patients[7],
            contractDate: new DateTime(2023, 12, 3),
            contractNumber: "Д-2023-012",
            startDate: new DateTime(2023, 12, 3),
            endDate: new DateTime(2024, 3, 3),
            totalAmount: 7400.00m,
            paymentStatus: PaymentStatusEnum.Оплачен,
            contractStatus: ContractStatusEnum.Действует,
            notes: "Лабораторные анализы",
            responsibleEmployee: employees[8]
        ));

        contracts.Add(new Contract(
            patient: patients[8],
            contractDate: new DateTime(2024, 1, 20),
            contractNumber: "Д-2024-001",
            startDate: new DateTime(2024, 1, 20),
            endDate: new DateTime(2024, 4, 20),
            totalAmount: 15200.00m,
            paymentStatus: PaymentStatusEnum.Оплачен_частично,
            contractStatus: ContractStatusEnum.Действует,
            notes: "Кардиологическое обследование",
            responsibleEmployee: employees[9]
        ));

        contracts.Add(new Contract(
            patient: patients[8],
            contractDate: new DateTime(2024, 2, 14),
            contractNumber: "Д-2024-002",
            startDate: new DateTime(2024, 2, 14),
            endDate: new DateTime(2024, 5, 14),
            totalAmount: 6300.00m,
            paymentStatus: PaymentStatusEnum.Оплачен,
            contractStatus: ContractStatusEnum.Действует,
            notes: "Дерматология",
            responsibleEmployee: employees[10]
        ));

        contracts.Add(new Contract(
            patient: patients[8],
            contractDate: new DateTime(2024, 3, 1),
            contractNumber: "Д-2024-003",
            startDate: new DateTime(2024, 3, 1),
            endDate: new DateTime(2024, 9, 1),
            totalAmount: 44000.00m,
            paymentStatus: PaymentStatusEnum.Не_оплачен,
            contractStatus: ContractStatusEnum.Действует,
            notes: "Хирургическое вмешательство",
            responsibleEmployee: employees[10]
        ));

        contracts.Add(new Contract(
            patient: patients[9],
            contractDate: new DateTime(2024, 3, 10),
            contractNumber: "Д-2024-004",
            startDate: new DateTime(2024, 3, 10),
            endDate: new DateTime(2024, 4, 10),
            totalAmount: 2900.00m,
            paymentStatus: PaymentStatusEnum.Оплачен,
            contractStatus: ContractStatusEnum.Завершён,
            notes: "Приём офтальмолога",
            responsibleEmployee: employees[11]
        ));

        contracts.Add(new Contract(
            patient: patients[10],
            contractDate: new DateTime(2024, 4, 5),
            contractNumber: "Д-2024-005",
            startDate: new DateTime(2024, 4, 5),
            endDate: new DateTime(2024, 7, 5),
            totalAmount: 18500.00m,
            paymentStatus: PaymentStatusEnum.Оплачен,
            contractStatus: ContractStatusEnum.Действует,
            notes: "Курс физиотерапии",
            responsibleEmployee: employees[12]
        ));

        contracts.Add(new Contract(
            patient: patients[10],
            contractDate: new DateTime(2024, 5, 15),
            contractNumber: "Д-2024-006",
            startDate: new DateTime(2024, 5, 15),
            endDate: new DateTime(2024, 8, 15),
            totalAmount: 9700.00m,
            paymentStatus: PaymentStatusEnum.Не_оплачен,
            contractStatus: ContractStatusEnum.Действует,
            notes: "УЗИ-диагностика",
            responsibleEmployee: employees[12]
        ));

        contracts.Add(new Contract(
            patient: patients[11],
            contractDate: new DateTime(2024, 6, 1),
            contractNumber: "Д-2024-007",
            startDate: new DateTime(2024, 6, 1),
            endDate: new DateTime(2025, 6, 1),
            totalAmount: 120000.00m,
            paymentStatus: PaymentStatusEnum.Оплачен_частично,
            contractStatus: ContractStatusEnum.Действует,
            notes: "Имплантация зубов",
            responsibleEmployee: employees[12]
        ));

        contracts.Add(new Contract(
            patient: patients[12],
            contractDate: new DateTime(2024, 6, 15),
            contractNumber: "Д-2024-008",
            startDate: new DateTime(2024, 6, 15),
            endDate: new DateTime(2024, 9, 15),
            totalAmount: 5100.00m,
            paymentStatus: PaymentStatusEnum.Оплачен,
            contractStatus: ContractStatusEnum.Действует,
            notes: "Вакцинация",
            responsibleEmployee: employees[13]
        ));
        return contracts;
    }
}