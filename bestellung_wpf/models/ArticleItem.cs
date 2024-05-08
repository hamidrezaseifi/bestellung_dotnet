using bestellung_wpf.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bestellung_wpf.models
{
    public class ArticleItem
    {
        public ArticleItem()
        {
            status = BestellungStatus.Anfrage.ToString();
        }

        public static ArticleItem fromUi(ArticleItemUi uiItem)
        {
            ArticleItem item = new ArticleItem();

            item.name = uiItem.name;
            item.manufacturer = uiItem.manufacturer;
            item.articleNumber = uiItem.articleNumber;
            item.partNumber = uiItem.partNumber;
            item.status = uiItem.status;

            return item;
        }

        public string name { get; set; }
        public string manufacturer { get; set; }
        public string articleNumber { get; set; }
        public string partNumber { get; set; }
        public string status { get; set; }

        

        public override  string ToString() {
            return name + " Marke(" + manufacturer + ") Artikelnummer(" + articleNumber + ") Partnummer(" + partNumber + ") Status(" + status + ")";
        }
    }
}
