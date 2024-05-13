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

        public BestellungItem prepare()
        {

            BestellungItem item = (BestellungItem)this.MemberwiseClone();

            List<ArticleItem> filteredArticles = item.articles.Where(a => ArticleItemValidator.IsValid(a)).ToList();

            if (filteredArticles.Count == 0) {
                return null;
            }

            item.articles = filteredArticles;

            return item;
        }
    }

    public class BestellungItemValidator : ValidatorBase
    {
        public static bool IsValid(BestellungItem bestellungItem)
        {
            List<ArticleItem> filteredArticles = bestellungItem.articles.Where(a => ArticleItemValidator.IsValid(a)).ToList();

            if (filteredArticles.Count == 0)
            {
                return false;
            }


            if (!IsValueValid(bestellungItem.id))
            {
                return false;
            }

            if (!IsValueValid(bestellungItem.customer))
            {
                return false;
            }

            if (!IsValueValid(bestellungItem.user))
            {
                return false;
            }

            if (!IsValueValid(bestellungItem.fahrzeug))
            {
                return false;
            }

            return true;
        }
    }
}
