namespace InitDb;

/// <summary>
/// Отдельный класс для создания 20 экземпляров ContractItem с конкретными данными.
/// Поле ContractItemId не заполняется (будет задано базой данных).
/// </summary>
public static class ContractItemSeeder
{
    // <summary>
    /// Возвращает список из 20 строк договора с заранее определёнными данными.
    /// </summary>
    public static List<ContractItem> GetSampleContractItems(List<Contract> contracts, List<MedicalService> medicalServices)
    {
        var items = new List<ContractItem>();

        // Добавляем 20 строк договора, передавая данные непосредственно в конструктор.
        // ContractItemId остаётся равным 0 (значение по умолчанию).
        items.Add(new ContractItem(
            contract: contracts[0],
            service: medicalServices[0],
            quantity: 1,
            price: 1500.00m,
            discount: 0.00m
        ));

        items.Add(new ContractItem(
            contract: contracts[1],
            service: medicalServices[1],
            quantity: 2,
            price: 800.00m,
            discount: 5.00m
        ));

        items.Add(new ContractItem(
            contract: contracts[2],
            service: medicalServices[2],
            quantity: 1,
            price: 1000.00m,
            discount: 0.00m
        ));

        items.Add(new ContractItem(
            contract: contracts[2],
            service: medicalServices[3],
            quantity: 1,
            price: 600.00m,
            discount: 10.00m
        ));

        items.Add(new ContractItem(
            contract: contracts[2],
            service: medicalServices[4],
            quantity: 1,
            price: 500.00m,
            discount: 0.00m
        ));

        items.Add(new ContractItem(
            contract: contracts[3],
            service: medicalServices[5],
            quantity: 1,
            price: 1200.00m,
            discount: 15.00m
        ));
        return items;
    }
}
