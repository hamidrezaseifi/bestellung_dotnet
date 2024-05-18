using bestellung_wpf.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace bestellung_wpf.models
{
    public class ArticleItemUi : INotifyPropertyChanged, IArticleItem
    {
        private ArticleItem _item;

        private bool _selected = false;
        private bool _isEnable = false;


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int index { get; set; }
        public string name { get { return _item.name; } set { _item.name = value; NotifyPropertyChanged(); } }
        public string manufacturer { get { return _item.manufacturer; } set { _item.manufacturer = value; NotifyPropertyChanged(); } }
        public string articleNumber { get { return _item.articleNumber; } set { _item.articleNumber = value; NotifyPropertyChanged(); } }
        public string purchaseSource { get { return _item.purchaseSource; } set { _item.purchaseSource = value; NotifyPropertyChanged(); } }
        public double price { get { return _item.price; } set { _item.price = value; NotifyPropertyChanged(); } }

        public BestellungStatus status { get { return _item.status; } set { _item.status = value; NotifyPropertyChanged(); } }
        public ArticleItem Item { get => _item; set => _item = value; }
        public bool Selected { get => _selected; set => _selected = value; }
        public bool IsEnable
        {
            get
            {
                return _isEnable;
            }

            set
            {
                _isEnable = value;
            }
        }

        public ArticleItemUi(ArticleItem item) {
            _item = item;
        }

        public override string ToString()
        {
            return name + " Kauf-Q.(" + purchaseSource + ") Marke(" + manufacturer + ") Art-Num.(" + articleNumber + "): " + status;
        }

        internal bool IsEmpty()
        {
            return name.Trim().Equals("") && manufacturer.Trim().Equals("") && articleNumber.Trim().Equals("") && purchaseSource.Trim().Equals("");
        }


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

        public double getPrice()
        {
            return price;
        }

        public BestellungStatus getStatus()
        {
            return status;
        }

    }

}
