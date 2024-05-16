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

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int index { get; set; }
        public string name { get { return _item.name; } set { _item.name = value; NotifyPropertyChanged(); } }
        public string manufacturer { get { return _item.manufacturer; } set { _item.manufacturer = value; NotifyPropertyChanged(); } }
        public string articleNumber { get { return _item.articleNumber; } set { _item.articleNumber = value; NotifyPropertyChanged(); } }
        public string partNumber { get { return _item.partNumber; } set { _item.partNumber = value; NotifyPropertyChanged(); } }
        public string status { get { return _item.status; } set { _item.status = value; NotifyPropertyChanged(); } }
        public ArticleItem Item { get => _item; set => _item = value; }

        public ArticleItemUi(ArticleItem item) {
            _item = item;
        }
        public override string ToString()
        {
            return name + " Marke(" + manufacturer + ") Artikelnummer(" + articleNumber + ") Partnummer(" + partNumber + ") Status(" + status + ")";
        }

        internal bool IsEmpty()
        {
            return name.Trim().Equals("") && manufacturer.Trim().Equals("") && articleNumber.Trim().Equals("") && partNumber.Trim().Equals("");
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

        public string getPartNumber()
        {
            return partNumber;
        }

        public string getStatus()
        {
            return status;
        }

    }

}
