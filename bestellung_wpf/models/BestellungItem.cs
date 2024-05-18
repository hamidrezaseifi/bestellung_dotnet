using bestellung_wpf.enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bestellung_wpf.models
{
    public class BestellungItem
    {
        private List<ArticleItem> _articles = new List<ArticleItem>();

        public BestellungItem(string id, String _user) {
            status = BestellungStatus.Anfrage;
            anfrageDate = DateTime.Now;
            this.user = _user;
            this.id = id;
        }

        public BestellungItem(BestellungItemUi itemUi)
        {
            status = itemUi.status;
            anfrageDate = itemUi.AnfrageDate;
            user = itemUi.user;
            id = itemUi.id;
            _id = itemUi.GetDbId();

            bestellungDate = itemUi.BestellungDate;

            lieferungDate = itemUi.LieferungDate;

            rueckgabeDate = itemUi.RueckgabeDate;

            customer = itemUi.customer;

            user = itemUi.user;

            fahrzeug = itemUi.fahrzeug;

            fahrgestellnummer = itemUi.fahrgestellnummer;

            hsnTsn = itemUi.hsnTsn;

            betrag = itemUi.betrag;

            endBetrag = itemUi.endBetrag;

            anzahlung = itemUi.anzahlung;

            itemUi.articles.AsParallel().Where(a => ArticleItemValidator.IsValid(a)).ForAll(a => articles.Add(ArticleItem.fromUi(a)));

        }

        [BsonId]
        public ObjectId _id { get; set; }

        public string id { get; set; }

        public DateTime anfrageDate{ get; set; }

        public DateTime bestellungDate{ get; set; }

        public DateTime lieferungDate{ get; set; }

        public DateTime rueckgabeDate{ get; set; }

        public string customer { get; set; }

        public string user { get; set; }

        public string fahrzeug{ get; set; }

        public string fahrgestellnummer{ get; set; }

        public string hsnTsn{ get; set; }

        public double betrag{ get; set; }

        public double endBetrag{ get; set; }

        public double anzahlung{ get; set; }

        public BestellungStatus status { get; set; }

        public List<ArticleItem> articles { get { return _articles; } set{ _articles = value; } }


        public static string CreateNewId(DateTime date, int iItem)
        {
            return date.ToString("yyyyMMdd") + "-" + iItem.ToString();
        }

    }

}
