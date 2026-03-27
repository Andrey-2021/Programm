namespace WindowsInterfaces;

public interface IDialogService
{
    void ShowInfo(string message, string title = "Информация");
    bool Confirm(string message, string title = "Подтверждение");
    string? OpenFile(string filter, string title = "Открыть файл");
    string? SaveFile(string filter, string title = "Сохранить файл", string defaultFileName = "");
    public string? SelectFolder(string title = "Выбрать папку", string? path = null);
}