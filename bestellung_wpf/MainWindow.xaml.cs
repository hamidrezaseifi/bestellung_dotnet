using bestellung_wpf.forms;
using bestellung_wpf.models;
using bestellung_wpf.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bestellung_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowView view = new MainWindowView();
        private GlobalValues globalValues = ((App)Application.Current).GlobalValues;
        public MainWindow()
        {
            if (globalValues.UserList.Count == 0)
            {
                return;
            }

            InitializeComponent();

            DataContext = view;
            lstItems.ItemsSource = view.bestellungItemObservable.List;

            GlobalValues_PropertyChanged(null, null);
            ((App)Application.Current).GlobalValues.PropertyChanged += GlobalValues_PropertyChanged;

            WindowHelper.Initialize(this);

        }

        private void GlobalValues_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (((App)Application.Current).GlobalValues.CurrentUser != null) {
                User user = ((App)Application.Current).GlobalValues.CurrentUser;
                WindowHelper.Initialize(this);
                lblBenutzer.Content = user.name;
            }
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            SelectUserDialog dialog = new SelectUserDialog(this);
            dialog.ShowDialog();
        }

        private void btnAnfrage_Click(object sender, RoutedEventArgs e)
        {
            NewAnfrageForm form = new NewAnfrageForm(view, this);
            form.ShowDialog();

            if (form.IsSelected) {
                BestellungItemUi selcted = form.BestellungItem;

                view.InsertNewBestellung(form.BestellungItem);
            }

            
        }
    }
}
