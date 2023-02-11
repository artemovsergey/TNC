using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using TNC.WPF.Models;

namespace TNC.WPF.Converters
{
    public class TitleConverter : IValueConverter
    {

        // source to binding
        // от источника к чему привязываемся (свойствоа VM) к приемнику (xaml)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"Компания:{(string)value}";
        }

        // binding to source
        // от интерфейса(xaml) к свойству VM
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value;
        }

    }
}
