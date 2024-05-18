using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace bestellung_wpf.utils
{
    class GeneralUtils
    {

        public static void isNumberOrDecimal(object sender, TextCompositionEventArgs e) {
            bool approvedDecimalPoint = false;

            if (e.Text == ",")
            {
                if (!((TextBox)sender).Text.Contains(","))
                    approvedDecimalPoint = true;
            }

            if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
                e.Handled = true;
        }

        public static bool isDateTimeValid(DateTime dateTime) {
            return dateTime > new DateTime(2024, 1, 1);
        }
    }
}
