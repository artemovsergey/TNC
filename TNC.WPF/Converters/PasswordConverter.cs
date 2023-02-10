using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TNC.WPF.Models;

namespace TNC.WPF.Converters
{
    public class PasswordConverter
    {

        // source to binding
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //using(UserContext db = new UserContext())
            //{
            //    Role r = db.Roles.Where(r => r.Id == (int)value) as Role;
            //    return r;
            //}

            return value;


        }

        // binding to source
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

    }
}
