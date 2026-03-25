using Entities.Enums;

namespace InitDb;

/// <summary>
/// Отдельный класс для создания 30 экземпляров Payment с конкретными данными.
/// Поле PaymentId не заполняется (будет задано базой данных).
/// </summary>
public static class PaymentSeeder
{
    /// <summary>
    /// Возвращает список из 30 платежей с заранее определёнными данными.
    /// </summary>
    public static List<Payment> GetSamplePayments(List<Contract> contracts)
    {
        var payments = new List<Payment>();

        // 30 платежей, данные передаются явно, без массивов.
        payments.Add(new Payment(
            contract: contracts[0],
            paymentDate: new DateTime(2023, 1, 15),
            paymentMethod: PaymentMethodEnum.наличные,
            paymentAmount: 15000.00m,
            transactionId: "TXN1001",
            paymentNotes: "Полная оплата по договору Д-2023-001"
        ));

        payments.Add(new Payment(
            contract: contracts[1],
            paymentDate: new DateTime(2023, 2, 10),
            paymentMethod: PaymentMethodEnum.банковская_карта,
            paymentAmount: 5000.00m,
            transactionId: "TXN1002",
            paymentNotes: "Частичная оплата"
        ));

        payments.Add(new Payment(
            contract: contracts[2],
            paymentDate: new DateTime(2023, 3, 1),
            paymentMethod: PaymentMethodEnum.банковская_карта,
            paymentAmount: 3500.00m,
            transactionId: "TXN1003",
            paymentNotes: "Остаток по договору"
        ));

        payments.Add(new Payment(
            contract: contracts[2],
            paymentDate: new DateTime(2023, 3, 5),
            paymentMethod: PaymentMethodEnum.наличные,
            paymentAmount: 3200.00m,
            transactionId: "TXN1004",
            paymentNotes: "Полная оплата (впоследствии договор расторгнут)"
        ));

        payments.Add(new Payment(
            contract: contracts[2],
            paymentDate: new DateTime(2023, 4, 12),
            paymentMethod: PaymentMethodEnum.банковский_перевод,
            paymentAmount: 45000.00m,
            transactionId: "TXN1005",
            paymentNotes: "Годовой абонемент"
        ));

        payments.Add(new Payment(
            contract: contracts[3],
            paymentDate: new DateTime(2023, 5, 20),
            paymentMethod: PaymentMethodEnum.наличные,
            paymentAmount: 12400.00m,
            transactionId: "TXN1006",
            paymentNotes: ""
        ));

        payments.Add(new Payment(
            contract: contracts[4],
            paymentDate: new DateTime(2023, 6, 1),
            paymentMethod: PaymentMethodEnum.банковская_карта,
            paymentAmount: 5600.00m,
            transactionId: "TXN1007",
            paymentNotes: "Физиотерапия"
        ));

        payments.Add(new Payment(
            contract: contracts[4],
            paymentDate: new DateTime(2023, 7, 8),
            paymentMethod: PaymentMethodEnum.банковский_перевод,
            paymentAmount: 5000.00m,
            transactionId: "TXN1008",
            paymentNotes: "Частичная предоплата"
        ));

        payments.Add(new Payment(
            contract: contracts[5],
            paymentDate: new DateTime(2023, 8, 1),
            paymentMethod: PaymentMethodEnum.наличные,
            paymentAmount: 5000.00m,
            transactionId: "TXN1009",
            paymentNotes: "Вторая часть"
        ));

        payments.Add(new Payment(
            contract: contracts[5],
            paymentDate: new DateTime(2023, 9, 5),
            paymentMethod: PaymentMethodEnum.банковская_карта,
            paymentAmount: 11000.00m,
            transactionId: "TXN1010",
            paymentNotes: "Окончательная оплата"
        ));

        payments.Add(new Payment(
            contract: contracts[6],
            paymentDate: new DateTime(2023, 8, 15),
            paymentMethod: PaymentMethodEnum.банковская_карта,
            paymentAmount: 10000.00m,
            transactionId: "TXN1011",
            paymentNotes: "Аванс"
        ));

        return payments;
    }
}