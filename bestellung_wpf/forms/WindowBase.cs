using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace bestellung_wpf.forms
{
    public class WindowHelper
    {
        public static void Initialize(Window window) {
            window.Background = ((App)Application.Current).GlobalValues.CurrentUserBrush;
        }
    }
}
