namespace InitDb;

/// <summary>
/// Отдельный класс для создания 10 экземпляров Position с конкретными данными.
/// Поле Id не заполняется (будет задано базой данных).
/// </summary>
public static class PositionSeeder
{
    /// <summary>
    /// Возвращает список из 10 должностей с заранее определёнными названиями.
    /// </summary>
    public static List<Position> GetSamplePositions()
    {
        var positions = new List<Position>();

        // Добавляем 10 должностей, передавая название непосредственно в конструктор.
        // Id остаётся равным 0 (значение по умолчанию).
        positions.Add(new Position("Врач-терапевт"));
        positions.Add(new Position("Врач-хирург"));
        positions.Add(new Position("Медицинская сестра"));
        positions.Add(new Position("Заведующий отделением"));
        positions.Add(new Position("Врач-педиатр"));
        positions.Add(new Position("Врач-кардиолог"));
        positions.Add(new Position("Лаборант"));
        positions.Add(new Position("Физиотерапевт"));
        positions.Add(new Position("Регистратор"));
        positions.Add(new Position("Администратор"));

        return positions;
    }
}