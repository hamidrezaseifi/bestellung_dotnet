using bestellung.forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bestellung
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SelectUserForm selectUserForm = new SelectUserForm();
            selectUserForm.ShowDialog();

            if (Globals.CURRENT_USER == null) {
                return;
            }
            Application.Run(new MainForm());
        }
    }
}
