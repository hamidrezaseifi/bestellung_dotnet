using bestellung_wpf.enums;
using bestellung_wpf.forms;
using bestellung_wpf.models;
using bestellung_wpf.utils;
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
        private ContextMenu mnuItems;

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

        private void miBestellen_Click(object sender, RoutedEventArgs e)
        {
            Object o = mnuItems.Tag;
            BestellungItemUi item = (BestellungItemUi)o;

            BestellungChangeForm form = new BestellungChangeForm(view, this, new BestellungItemUi(item.ToItem()), BestellungChangeType.Bestellen);
            form.ShowDialog();

            if (form.IsSelected)
            {
                BestellungItemUi selcted = form.BestellungItem;

                view.UpdateBestellung(form.BestellungItem);
            }
        }

        private void miLiefern_Click(object sender, RoutedEventArgs e)
        {
            Object o = mnuItems.Tag;
            BestellungItemUi item = (BestellungItemUi)o;

            BestellungChangeForm form = new BestellungChangeForm(view, this, new BestellungItemUi(item.ToItem()), BestellungChangeType.Liefern);
            form.ShowDialog();

            if (form.IsSelected)
            {
                BestellungItemUi selcted = form.BestellungItem;

                view.UpdateBestellung(form.BestellungItem);
            }

        }

        private void miRueckgabe_Click(object sender, RoutedEventArgs e)
        {
            Object o = mnuItems.Tag;
            BestellungItemUi item = (BestellungItemUi)o;

            BestellungChangeForm form = new BestellungChangeForm(view, this, new BestellungItemUi(item.ToItem()), BestellungChangeType.Rueckgabe);
            form.ShowDialog();

            if (form.IsSelected)
            {
                BestellungItemUi selcted = form.BestellungItem;

                view.UpdateBestellung(form.BestellungItem);
            }

        }

        private void miLoeschen_Click(object sender, RoutedEventArgs e)
        {
            Object o = mnuItems.Tag;
            BestellungItemUi item = (BestellungItemUi)o;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BestellungItemUi item = (BestellungItemUi)sender;

            ShowContextMenu((Button)sender, item);
        }

        private void ShowContextMenu(Control ctrl, BestellungItemUi item) {
            if (mnuItems == null) {
                mnuItems = new ContextMenu();

            }

            mnuItems.Items.Clear();

            if (item.status == BestellungStatus.Anfrage)
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Header = "Bestellen";
                menuItem.Click += miBestellen_Click;

                mnuItems.Items.Add(menuItem);
                mnuItems.Items.Add(new Separator());

                menuItem = new MenuItem();
                menuItem.Header = "Löschen";
                menuItem.Click += miLoeschen_Click;

                mnuItems.Items.Add(menuItem);
            }

            if (item.status == BestellungStatus.Bestellt)
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Header = "Liefern";
                menuItem.Click += miLiefern_Click;

                mnuItems.Items.Add(menuItem);
            }

            if (item.status == BestellungStatus.Liefert)
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Header = "Rückgabe";
                menuItem.Click += miRueckgabe_Click;

                mnuItems.Items.Add(menuItem);
            }

            mnuItems.PlacementTarget = ctrl;
            mnuItems.Tag = item;
            mnuItems.IsOpen = true; ;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void lstItems_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if(lstItems.SelectedItem == null){
                return;
            }

            BestellungItemUi item = (BestellungItemUi)lstItems.SelectedItem;
            if (item != null) {
                ShowContextMenu(lstItems, item);
            }
        }
    }
}
