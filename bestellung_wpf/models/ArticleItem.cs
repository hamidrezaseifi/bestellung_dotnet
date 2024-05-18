using bestellung_wpf.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bestellung_wpf.models
{
    public class ArticleItem: IArticleItem
    {
        
        public ArticleItem()
        {
            status = BestellungStatus.Anfrage;
        }

        public ArticleItem(bool initString): this()
        {
            name = "";
            manufacturer = "";
            articleNumber = "";
            purchaseSource = "";
            status = BestellungStatus.Anfrage;
            price = 0;
        }

        public static ArticleItem fromUi(ArticleItemUi uiItem)
        {
            ArticleItem item = new ArticleItem();

            item.name = uiItem.name;
            item.manufacturer = uiItem.manufacturer;
            item.articleNumber = uiItem.articleNumber;
            item.purchaseSource = uiItem.purchaseSource;
            item.status = uiItem.status;
            item.price = uiItem.price;

            return item;
        }

        public string name { get; set; }
        public string manufacturer { get; set; }
        public string articleNumber { get; set; }
        public string purchaseSource { get; set; }
        public double price { get; set; }
        public BestellungStatus status { get; set; }

        public string getName()
        {
            return name;
        }

        public string getManufacturer()
        {
            return manufacturer;
        }

        public string getArticleNumber()
        {
            return articleNumber;
        }

        public string getPurchaseSource()
        {
            return purchaseSource;
        }

        public double getPrice() {
            return price;
        }


        public BestellungStatus getStatus()
        {
            return status;
        }
    }

}
