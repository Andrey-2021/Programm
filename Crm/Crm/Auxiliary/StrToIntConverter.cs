using System.Globalization;
using System.Windows.Data;

namespace Crm;

/// <summary>
/// Преобразование строки в целое число. Если возникает ошибка, возвращаем 0
/// </summary>
public class StrToIntConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (!int.TryParse(value.ToString(), out int d))
            return 0; //Binding.DoNothing;
        return d;
    }
}

