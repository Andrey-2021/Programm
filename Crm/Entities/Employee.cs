namespace Entities;

/// <summary>
/// Простой класс, представляющий запись таблицы "Сотрудники"
/// </summary>
public class Employee
{
    /// <summary>
    /// ID сотрудника (ключевое поле)
    /// </summary>
    [Key]
    public int EmployeeId { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string MiddleName { get; set; }

    /// <summary>
    /// Должность
    /// </summary>
    public string Position { get; set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Электронная почта
    /// </summary>
    public string Email { get; set; }

    public Employee()
    { 
    }

    /// <summary>
    /// Конструктор для инициализации всех свойств, кроме EmployeeId.
    /// </summary>
    public Employee(string lastName, string firstName, string middleName,
                    string position, string phoneNumber, string email)
    {
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        Position = position;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}