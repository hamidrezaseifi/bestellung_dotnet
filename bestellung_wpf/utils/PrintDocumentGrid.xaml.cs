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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bestellung_wpf.utils
{
    /// <summary>
    /// Interaction logic for PrintDocumentGrid.xaml
    /// </summary>
    public partial class PrintDocumentGrid : UserControl
    {
        private BestellungItemUi _bestellungItem;

        public PrintDocumentGrid(BestellungItemUi bestellungItem)
        {
            _bestellungItem = bestellungItem;
            for (int i = 0; i < _bestellungItem.articles.Count; i++) {
                _bestellungItem.articles[i].index = i + 1;
            }
            InitializeComponent();
        }

        public BestellungItemUi BestellungItem { get => _bestellungItem; set => _bestellungItem = value; }
    }
}
