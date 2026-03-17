namespace InitDb;

/// <summary>
/// Отдельный класс для создания 20 экземпляров Employee с конкретными данными.
/// Поле EmployeeId не заполняется (предполагается, что будет сгенерировано БД).
/// </summary>
public static class EmployeeSeeder
{
    /// <summary>
    /// Возвращает список из 20 сотрудников с заранее определёнными данными.
    /// </summary>
    public static List<Employee> GetSampleEmployees()
    {
        var employees = new List<Employee>();

        // Добавляем 20 сотрудников, передавая данные непосредственно в конструктор.
        // EmployeeId не задаётся.
        employees.Add(new Employee(
            lastName: "Иванов",
            firstName: "Пётр",
            middleName: "Сергеевич",
            position: "Врач-терапевт",
            phoneNumber: "+7 (123) 111-22-33",
            email: "ivanov@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Петрова",
            firstName: "Мария",
            middleName: "Ивановна",
            position: "Медицинская сестра",
            phoneNumber: "+7 (123) 222-33-44",
            email: "petrova@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Сидоров",
            firstName: "Алексей",
            middleName: "Викторович",
            position: "Хирург",
            phoneNumber: "+7 (123) 333-44-55",
            email: "sidorov@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Кузнецова",
            firstName: "Елена",
            middleName: "Владимировна",
            position: "Регистратор",
            phoneNumber: "+7 (123) 444-55-66",
            email: "kuznetsova@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Смирнов",
            firstName: "Дмитрий",
            middleName: "Николаевич",
            position: "Заведующий отделением",
            phoneNumber: "+7 (123) 555-66-77",
            email: "smirnov@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Михайлова",
            firstName: "Анна",
            middleName: "Олеговна",
            position: "Врач-педиатр",
            phoneNumber: "+7 (123) 666-77-88",
            email: "mikhailova@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Фёдоров",
            firstName: "Андрей",
            middleName: "Павлович",
            position: "Врач-кардиолог",
            phoneNumber: "+7 (123) 777-88-99",
            email: "fedorov@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Морозова",
            firstName: "Ольга",
            middleName: "Игоревна",
            position: "Медицинская сестра",
            phoneNumber: "+7 (123) 888-99-00",
            email: "morozova@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Волков",
            firstName: "Иван",
            middleName: "Алексеевич",
            position: "Врач-невролог",
            phoneNumber: "+7 (123) 999-00-11",
            email: "volkov@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Соколова",
            firstName: "Татьяна",
            middleName: "Дмитриевна",
            position: "Физиотерапевт",
            phoneNumber: "+7 (123) 000-11-22",
            email: "sokolova@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Лебедев",
            firstName: "Максим",
            middleName: "Сергеевич",
            position: "Врач-офтальмолог",
            phoneNumber: "+7 (124) 111-22-33",
            email: "lebedev@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Козлова",
            firstName: "Наталья",
            middleName: "Викторовна",
            position: "Лаборант",
            phoneNumber: "+7 (124) 222-33-44",
            email: "kozlova@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Новиков",
            firstName: "Александр",
            middleName: "Иванович",
            position: "Врач-уролог",
            phoneNumber: "+7 (124) 333-44-55",
            email: "novikov@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Зайцева",
            firstName: "Ирина",
            middleName: "Петровна",
            position: "Медицинская сестра",
            phoneNumber: "+7 (124) 444-55-66",
            email: "zaytseva@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Павлов",
            firstName: "Михаил",
            middleName: "Геннадьевич",
            position: "Врач-стоматолог",
            phoneNumber: "+7 (124) 555-66-77",
            email: "pavlov@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Борисова",
            firstName: "Екатерина",
            middleName: "Анатольевна",
            position: "Гинеколог",
            phoneNumber: "+7 (124) 666-77-88",
            email: "borisova@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Соловьёв",
            firstName: "Владимир",
            middleName: "Андреевич",
            position: "Врач-дерматолог",
            phoneNumber: "+7 (124) 777-88-99",
            email: "soloviev@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Васильева",
            firstName: "Светлана",
            middleName: "Максимовна",
            position: "Психолог",
            phoneNumber: "+7 (124) 888-99-00",
            email: "vasilieva@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Попов",
            firstName: "Артём",
            middleName: "Валерьевич",
            position: "Врач-эндоскопист",
            phoneNumber: "+7 (124) 999-00-11",
            email: "popov@clinic.ru"
        ));

        employees.Add(new Employee(
            lastName: "Алексеева",
            firstName: "Дарья",
            middleName: "Сергеевна",
            position: "Администратор",
            phoneNumber: "+7 (124) 000-11-22",
            email: "alekseeva@clinic.ru"
        ));

        return employees;
    }
}
