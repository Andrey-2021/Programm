namespace Entities;

/// <summary>
/// Простой класс, представляющий запись таблицы "Строки договора"
/// </summary>
public class ContractItem
{
    /// <summary>
    /// ID строки договора (ключевое поле)
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// ID договора
    /// </summary>
    public int ContractId { get; set; }
    public Contract? Contract { get; set; }


    /// <summary>
    /// ID услуги
    /// </summary>
    public int MedicalServiceId { get; set; }
    public MedicalService? MedicalService { get; set; }


    /// <summary>
    /// Количество услуг
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Цена услуги на момент заключения договора (DECIMAL(10,2))
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Скидка (DECIMAL(5,2))
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Сумма по данной строке (DECIMAL(12,2))
    /// </summary>
    public decimal ItemTotal { get; set; }

    public ContractItem()
    { }

    /// <summary>
    /// Конструктор для инициализации всех свойств, кроме ContractItemId.
    /// </summary>
    public ContractItem(Contract contract, MedicalService service, int quantity, decimal price, decimal discount, decimal itemTotal)
    {
        Contract = contract;
        MedicalService = service;
        Quantity = quantity;
        Price = price;
        Discount = discount;
        ItemTotal = itemTotal;
    }
}