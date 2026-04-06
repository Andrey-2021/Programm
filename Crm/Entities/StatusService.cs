namespace Entities;

/// <summary>
/// Сервис статусной строки
/// </summary>
public class StatusService: BaseNotifyPropertyChanged
{
    /// <summary>
    /// Сообщение в строку статуса
    /// </summary>
    public string? StatusMessage
    {
        get => statusMessage;
        set
        {
            statusMessage = value;
            OnPropertyChanged();
        }
    }
    private string? statusMessage;

    /// <summary>
    /// Установить сообщение
    /// </summary>
    public void SetMessage(string message)
    {
        StatusMessage = message + " " + DateTime.Now; ;
    }

    /// <summary>
    /// Добавить сообщение
    /// </summary>
    public void AddMessage(string message)
    {
        StatusMessage = (StatusMessage==null?string.Empty : StatusMessage+". ") + message + " " + DateTime.Now; ;
    }

    /// <summary>
    /// Удалить сообщения
    /// </summary>
    public void Clea()
    {
        StatusMessage = null;
    }
}
