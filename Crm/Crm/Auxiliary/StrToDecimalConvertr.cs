using System.Globalization;
using System.Windows.Data;
namespace Crm;

/// <summary>
/// Преобразование строки в decimal число. Если возникает ошибка, возвращаем 0
/// </summary>
public class StrToDecimalConvertr : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var str = value.ToString();
        if (str!=null && str.Length - 1>=0 && str[str.Length - 1] == ',')
            str += '0';


        if (!decimal.TryParse(str, out decimal d))
            return 0; //Binding.DoNothing;
        return d;
    }
}

