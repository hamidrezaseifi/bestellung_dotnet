using bestellung_wpf.forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace bestellung_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly GlobalValues globalValues = new GlobalValues();

        public GlobalValues GlobalValues => globalValues;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            SelectUserDialog dialog = new SelectUserDialog(null);
            Nullable<bool> dialogResult = dialog.ShowDialog();
            if (dialog.Selected)
            {
                MainWindow window = new MainWindow();
                window.Show();
            }
            else {
                this.Shutdown();
            }

            
        }
    }
}
