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

namespace bestellung_wpf.utils
{
    /// <summary>
    /// Interaction logic for TestPrintForm.xaml
    /// </summary>
    public partial class TestPrintForm : Window
    {
        private BestellungItemUi _bestellungItem;

        private PrintDocumentGrid printDocumentGrid;
        public TestPrintForm(BestellungItemUi bestellungItem)
        {
            _bestellungItem = bestellungItem;
            InitializeComponent();

            printDocumentGrid = new PrintDocumentGrid(_bestellungItem);
            Grid.SetColumn(printDocumentGrid, 0);
            Grid.SetRow(printDocumentGrid, 0);
            printDocumentGrid.VerticalAlignment = VerticalAlignment.Stretch;
            printDocumentGrid.HorizontalAlignment = HorizontalAlignment.Stretch;

            grmMain.Children.Add(printDocumentGrid);

        }

        public BestellungItemUi BestellungItem { get => _bestellungItem; set => _bestellungItem = value; }
    }
}
