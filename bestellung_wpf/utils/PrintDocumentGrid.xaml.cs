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

            InitializeComponent();

            for (int i = 0; i < _bestellungItem.articles.Count; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(40);
                grdArticles.RowDefinitions.Add(rowDefinition);

                
                _bestellungItem.articles[i].index = i + 1;

                ArticleItemUi articleItemUi = _bestellungItem.articles[i];

                grdArticles.Children.Add(getArticleLabel(articleItemUi.index, grdArticles.RowDefinitions.Count - 1, 0));
                grdArticles.Children.Add(getArticleLabel(articleItemUi.name, grdArticles.RowDefinitions.Count - 1, 1));
                grdArticles.Children.Add(getArticleLabel(articleItemUi.purchaseSource, grdArticles.RowDefinitions.Count - 1, 2));
                grdArticles.Children.Add(getArticleLabel(articleItemUi.manufacturer, grdArticles.RowDefinitions.Count - 1, 3));
                grdArticles.Children.Add(getArticleLabel(articleItemUi.articleNumber, grdArticles.RowDefinitions.Count - 1, 4));
                grdArticles.Children.Add(getArticleLabel(articleItemUi.price, grdArticles.RowDefinitions.Count - 1, 5));
                grdArticles.Children.Add(getArticleLabel(articleItemUi.status, grdArticles.RowDefinitions.Count - 1, 6));
            }
        }

        public BestellungItemUi BestellungItem { get => _bestellungItem; set => _bestellungItem = value; }

        private Label getArticleLabel(Object value, int row, int column) {
            Label lbl = new Label();
            lbl.Content = value;
            lbl.HorizontalAlignment = HorizontalAlignment.Stretch;
            lbl.VerticalAlignment = VerticalAlignment.Center;
            lbl.HorizontalContentAlignment = HorizontalAlignment.Center;
            lbl.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            lbl.BorderThickness = new Thickness(0, 0, 0, 1);

            Grid.SetRow(lbl, row);
            Grid.SetColumn(lbl, column);

            return lbl;
        }
    }
}
