using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bestellung_wpf.models
{
    public class BestellungItemUi
    {
        private BestellungItem _item;

        public string id { get { return _item.id; } }

        public string customer { get { return _item.customer; } }

        public string user { get { return _item.user; } }

        public string fahrzeug { get { return _item.fahrzeug; } }

        public string fahrgestellnummer { get { return _item.fahrgestellnummer; } }

        public string hsnTsn { get { return _item.hsnTsn; } }

        public double betrag { get { return _item.betrag; } }

        public double endBetrag { get { return _item.endBetrag; } }

        public double anzahlung { get { return _item.anzahlung; } }

        public string status { get { return _item.status; } }

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
