using bestellung_wpf.DataLayer;
using bestellung_wpf.models;
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
using System.Windows.Shapes;

namespace bestellung_wpf.forms
{
    /// <summary>
    /// Interaction logic for SelectUserDialog.xaml
    /// </summary>
    public partial class SelectUserDialog : Window
    {
        private bool _selected = false;

        public bool Selected { get {
                return _selected;
            } }

        public SelectUserDialog(Window owner)
        {
            InitializeComponent();

            this.Owner = owner;
            UserMongoHelper userMongo = new UserMongoHelper();
            List<User> documentList = userMongo.GetAllDocuments(); //collection.Find(x => true).ToList();
            int row = 0;
            foreach (User user in documentList)
            {
                Button btn = new Button();
                btn.Content = user.name;
                btn.Background = user.Brush;
                btn.Width = 200;
                btn.Height = 30;
                //btn.Top = top;
                btn.Tag = user;
                Grid.SetRow(btn, row);
                Grid.SetColumn(btn, 0);
                btn.Margin = new Thickness(0, 5, 0, 0);

                btn.Click += UserButton_Click; ;
                grdMain.Children.Add(btn);

                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(40);
                grdMain.RowDefinitions.Add(rowDefinition);

                row += 1;
            }

            this.Height = row * 60;
            if (owner == null)
            {
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            else {
                this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;


            ((App)Application.Current).GlobalValues.CurrentUser = btn.Tag as User;
            _selected = true;

            this.Close();
        }
    }
}
