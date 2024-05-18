using bestellung_wpf.enums;
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
using System.Windows.Shapes;

namespace bestellung_wpf.forms
{
    /// <summary>
    /// Interaction logic for BestellungChangeForm.xaml
    /// </summary>
    /// 

    public partial class BestellungChangeForm : Window
    {
        private BestellungChangeView _bestellungView;
        public BestellungChangeView BestellungView { get { return _bestellungView; } set { _bestellungView = value; } }

        public BestellungItemUi BestellungItem { get { return _bestellungView.BestellungItem; } }

        public bool IsSelected { get => _isSelected; set => _isSelected = value; }

        private bool _isSelected = false;

        public BestellungChangeForm(MainWindowView view, Window owner, BestellungItemUi itemUi, BestellungChangeType _bestellungChangeType)
        {
            _bestellungView = new BestellungChangeView(view, itemUi, _bestellungChangeType);

            Owner = owner;

            InitializeComponent();

            WindowHelper.Initialize(this);
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (BestellungItemValidator.IsValid(_bestellungView.BestellungItem))
            {
                _isSelected = true;

                Close();
            }

        }

    }
}
