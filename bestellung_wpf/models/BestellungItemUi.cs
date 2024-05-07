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
    public class BestellungItemUi: INotifyPropertyChanged
    {
        private BestellungItem _item;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string id { get { return _item.id; } set { _item.id = value; NotifyPropertyChanged(); } }

        public string customer { get { return _item.customer; } set { _item.customer = value; NotifyPropertyChanged(); } }

        public string user { get { return _item.user; } set { _item.user = value; NotifyPropertyChanged(); } }

        public string fahrzeug { get { return _item.fahrzeug; } set { _item.fahrzeug = value; NotifyPropertyChanged(); } }

        public string fahrgestellnummer { get { return _item.fahrgestellnummer; } set { _item.fahrgestellnummer = value; NotifyPropertyChanged(); } }

        public string hsnTsn { get { return _item.hsnTsn; } set { _item.hsnTsn = value; NotifyPropertyChanged(); } }

        public double betrag { get { return _item.betrag; } set { _item.betrag = value; NotifyPropertyChanged(); } }

        public double endBetrag { get { return _item.endBetrag; } set { _item.endBetrag = value; NotifyPropertyChanged(); } }

        public double anzahlung { get { return _item.anzahlung; } set { _item.anzahlung = value; NotifyPropertyChanged(); } }

        public BestellungStatus status { get { return _item.status; } set { _item.status = value; NotifyPropertyChanged(); } }

        public double offeneBetrag { get { return endBetrag - anzahlung; } }

        public BestellungItemUi(BestellungItem item) {
            this._item = item;
        }
        public string articleNames {
            get {
                String val = "";
                foreach (ArticleItem item in _item.articles){
                    val += item.ToString() + "\r\n";
                }
                return val; 
            } 
        }

        public string dates
        {
            get {
                String val = "";

                val += "Anfrage: " + GetDateString(_item.anfrageDate) + "\r\n";
                val += "Bestellung: " + GetDateString(_item.bestellungDate) + "\r\n";
                val += "Lieferung: " + GetDateString(_item.lieferungDate) + "\r\n";
                val += "Rückgabe: " + GetDateString(_item.rueckgabeDate) + "\r\n";

                return val;
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
