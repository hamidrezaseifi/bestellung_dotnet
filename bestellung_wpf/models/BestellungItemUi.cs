using bestellung_wpf.enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace bestellung_wpf.models
{
    public class BestellungItemUi: INotifyPropertyChanged
    {
        private BestellungItem _item;
        private ObservableCollection<ArticleItemUi> _articles;
        private bool _isValid = false;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            _isValid = BestellungItemValidator.IsValid(_item);
        }

        public string id { get { return Item.id; } set { Item.id = value; NotifyPropertyChanged(); } }

        public string customer { get { return Item.customer; } set { Item.customer = value; NotifyPropertyChanged(); } }

        public string user { get { return Item.user; } set { Item.user = value; NotifyPropertyChanged(); } }

        public string fahrzeug { get { return Item.fahrzeug; } set { Item.fahrzeug = value; NotifyPropertyChanged(); } }

        public string fahrgestellnummer { get { return Item.fahrgestellnummer; } set { Item.fahrgestellnummer = value; NotifyPropertyChanged(); } }

        public string hsnTsn { get { return Item.hsnTsn; } set { Item.hsnTsn = value; NotifyPropertyChanged(); } }

        public double betrag { get { return Item.betrag; } set { Item.betrag = value; NotifyPropertyChanged(); } }

        public double endBetrag { get { return Item.endBetrag; } set { Item.endBetrag = value; NotifyPropertyChanged(); } }

        public double anzahlung { get { return Item.anzahlung; } set { Item.anzahlung = value; NotifyPropertyChanged(); } }

        public BestellungStatus status { get { return Item.status; } set { Item.status = value; NotifyPropertyChanged(); } }

        public double offeneBetrag { get { return endBetrag - anzahlung; } }

       
        public BestellungItemUi(BestellungItem item) {
            this.Item = item;

            _articles = new ObservableCollection<ArticleItemUi>();
            item.articles.ForEach(x => { _articles.Add(new ArticleItemUi(x));});
        }

        public ObservableCollection<ArticleItemUi> articles { get { return _articles; } set { 
                _articles = value;
                Item.articles.Clear();
                _articles.AsParallel().ForAll(x => { Item.articles.Add(ArticleItem.fromUi(x)); });

                NotifyPropertyChanged(); 
            } }

        public string articleNames {
            get {
                String val = "";
                foreach (ArticleItem item in Item.articles){
                    val += item.ToString() + "\r\n";
                }
                return val; 
            } 
        }

        public string dates
        {
            get {
                String val = "";

                val += "Anfrage: " + GetDateString(Item.anfrageDate) + "\r\n";
                val += "Bestellung: " + GetDateString(Item.bestellungDate) + "\r\n";
                val += "Lieferung: " + GetDateString(Item.lieferungDate) + "\r\n";
                val += "Rückgabe: " + GetDateString(Item.rueckgabeDate) + "\r\n";

                return val;
            }
        }

        public BestellungItem Item { get => _item; set => _item = value; }
        public bool IsValid { get { 
                return _isValid; 
            } 
            set
            {
                _isValid = value;
            }
        }

        private string GetDateString(DateTime date) {
            if (date == null) {
                return "";
            }
            return date.ToShortDateString();
        }
    }
}
