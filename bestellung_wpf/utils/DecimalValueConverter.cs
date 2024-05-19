using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Reflection;

namespace bestellung_wpf.utils
{
    public class DecimalValueConverter : IValueConverter
    {
        private CultureInfo[] cultures;
        private CultureInfo deCultureInfo = null;

        public DecimalValueConverter()
        {
            cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);

            List< CultureInfo> lst = cultures.AsParallel().Where(c => c.Name.Equals("de")).ToList();
            deCultureInfo = lst[0];

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(decimal))
            {
                return System.Convert.ToDecimal(value, deCultureInfo.NumberFormat); 
            }
            if (targetType == typeof(double))
            {
                return System.Convert.ToDouble(value, deCultureInfo.NumberFormat);
            }
            if (targetType == typeof(string))
            {
                return System.Convert.ToString(value, deCultureInfo.NumberFormat);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(decimal))
            {
                return System.Convert.ToDecimal(value, deCultureInfo.NumberFormat);
            }
            if (targetType == typeof(double))
            {
                return System.Convert.ToDouble(value, deCultureInfo.NumberFormat);
            }
            if (targetType == typeof(string))
            {
                return System.Convert.ToString(value, deCultureInfo.NumberFormat);
            }
            return value;
        }
    }
}
