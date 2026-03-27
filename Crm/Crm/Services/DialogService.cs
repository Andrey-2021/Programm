using Microsoft.Win32;
namespace Crm.Services;

public class DialogService : IDialogService
{
    public void ShowInfo(string message, string title = "Информация")
    {
        MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
    }

    public bool Confirm(string message, string title = "Подтверждение")
    {
        return MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
    }

    public string? OpenFile(string filter, string title = "Открыть файл")
    {
        var dialog = new OpenFileDialog
        {
            Title = title,
            Filter = filter,
            Multiselect = false
        };

        return dialog.ShowDialog() == true ? dialog.FileName : null;
    }

    public string? SaveFile(string filter, string title = "Сохранить файл", string defaultFileName = "")
    {
        var dialog = new SaveFileDialog
        {
            Title = title,
            Filter = filter,
            FileName = defaultFileName
        };

        return dialog.ShowDialog() == true ? dialog.FileName : null;
    }

    public string? SelectFolder(string title = "Выбрать папку", string? path=null)
    {
        if (path is null)
            path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        var dialog = new OpenFolderDialog()
        {
            Title = title,
            InitialDirectory = path,
            Multiselect = false
        };

        
        if (dialog.ShowDialog() == true)
            return dialog.FolderName;
        return null;
    }
}