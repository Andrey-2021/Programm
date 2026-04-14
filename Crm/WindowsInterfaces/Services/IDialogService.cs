namespace WindowsInterfaces;

/// <summary>
/// Сервис диалоговых окон
/// </summary>
public interface IDialogService
{
    /// <summary>
    /// Показать информирующее окно 
    /// </summary>
    /// <param name="message">Сообщение</param>
    /// <param name="title">Заголовок</param>
    public void ShowInfo(string message, string title = "Информация");

    /// <summary>
    /// Показать окно для вывода сообщений об ошибках
    /// </summary>
    /// <param name="message">Сообщение</param>
    /// <param name="title">Заголовок</param>    
    /// <param name="exception">Ошибка</param>
    public void ShowError(string message, string title = "Ошибка", Exception? exception = null);

    /// <summary>
    /// Показать окно с выводом предупреждающих сообщений
    /// </summary>
    /// <param name="message">Сообщение</param>
    /// <param name="title">Заголовок</param>    
    public void ShowWarning(string message, string title = "Внимание!");

    /// <summary>
    /// Окно для подтверждения действия
    /// </summary>
    /// <param name="message"></param>
    /// <param name="title"></param>
    /// <returns></returns>
    public bool Confirm(string message, string title = "Подтверждение");
    
    /// <summary>
    /// Окно выбора файла
    /// </summary>
    /// <param name="filter">Фильтр файлов</param>
    /// <param name="title">Заголовок</param>
    /// <returns>Выбранный файл</returns>
    public string? OpenFile(string filter, string title = "Открыть файл");
    
    /// <summary>
    /// Окно записи файла
    /// </summary>
    /// <param name="filter">Фильтр файлов</param>
    /// <param name="title">Заголовок</param>
    /// <param name="defaultFileName">Имя файла по умолчанию</param>
    public string? SaveFile(string filter, string title = "Сохранить файл", string defaultFileName = "");
    
    /// <summary>
    /// Выбор папки
    /// </summary>
    /// <param name="title">Заголовок</param>
    /// <param name="path">Начальный путь</param>
    /// <returns>Путь к выбранной папке</returns>
    public string? SelectFolder(string title = "Выбрать папку", string? path = null);
}