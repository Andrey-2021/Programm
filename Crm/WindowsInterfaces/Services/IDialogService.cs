namespace WindowsInterfaces;

/// <summary>
/// Сервис диалоговых окон
/// </summary>
public interface IDialogService
{
    public void ShowInfo(string message, string title = "Информация");
    public void ShowError(string message, string title = "Ошибка", Exception? exception = null);
    public void ShowWarning(string message, string title = "Внимание!");

    public bool Confirm(string message, string title = "Подтверждение");
    public string? OpenFile(string filter, string title = "Открыть файл");
    public string? SaveFile(string filter, string title = "Сохранить файл", string defaultFileName = "");
    public string? SelectFolder(string title = "Выбрать папку", string? path = null);
}