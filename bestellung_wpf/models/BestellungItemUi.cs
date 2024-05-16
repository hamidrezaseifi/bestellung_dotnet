using bestellung_wpf.enums;
using MongoDB.Bson;
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
        private BestellungItem _item1;
        private ObservableCollection<ArticleItemUi> _articles;
        private bool _isValid = false;

        private string _id;

        private DateTime _anfrageDate;

        private DateTime _bestellungDate;

        private DateTime _lieferungDate;

        private DateTime _rueckgabeDate;

        private string _customer;

        private string _user;

        private string _fahrzeug;

        private string _fahrgestellnummer;

        private string _hsnTsn;

        private double _betrag;

        private double _endBetrag;

        private double _anzahlung;

        private BestellungStatus _status;



        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            IsValid = BestellungItemValidator.IsValid(this);
        }

        public string id { get { return _id; } set { _id = value; NotifyPropertyChanged(); } }

        public string customer { get { return _customer; } set { _customer = value; NotifyPropertyChanged(); } }

        public void AddArticles(ArticleItemUi articleItemUi)
        {
            articleItemUi.PropertyChanged += ArticleItemUi_PropertyChanged;
            _articles.Add(articleItemUi);
        }

        public string user { get { return _user; } set { _user = value; NotifyPropertyChanged(); } }

        public string fahrzeug { get { return _fahrzeug; } set { _fahrzeug = value; NotifyPropertyChanged(); } }

        public string fahrgestellnummer { get { return _fahrgestellnummer; } set { _fahrgestellnummer = value; NotifyPropertyChanged(); } }

        public string hsnTsn { get { return _hsnTsn; } set { _hsnTsn = value; NotifyPropertyChanged(); } }

        public double betrag { get { return _betrag; } set { _betrag = value; NotifyPropertyChanged(); } }

        public double endBetrag { get { return _endBetrag; } set { _endBetrag = value; NotifyPropertyChanged(); } }

        public double anzahlung { get { return _anzahlung; } set { _anzahlung = value; NotifyPropertyChanged(); } }

        public BestellungStatus status { get { return _status; } set { _status = value; NotifyPropertyChanged(); } }

        public double offeneBetrag { get { return endBetrag - anzahlung; } }

        public DateTime AnfrageDate { get => _anfrageDate; }
        public DateTime BestellungDate { get => _bestellungDate; }
        public DateTime LieferungDate { get => _lieferungDate; }
        public DateTime RueckgabeDate { get => _rueckgabeDate; }


        public BestellungItemUi(BestellungItem item) {
            this._item1 = item;

            this._id = item.id;
            this._bestellungDate = item.bestellungDate;
            this._anfrageDate = item.anfrageDate;
            this._lieferungDate = item.lieferungDate;
            this._rueckgabeDate = item.rueckgabeDate;
            this._customer = item.customer;
            this._user = item.user;
            this._fahrgestellnummer = item.fahrgestellnummer;
            this._fahrzeug = item.fahrzeug;
            this._hsnTsn = item.hsnTsn;
            this._betrag = item.betrag;
            this._endBetrag = item.endBetrag;
            this._anzahlung = item.anzahlung;
            this._status = item.status;

            _articles = new ObservableCollection<ArticleItemUi>();
            item.articles.ForEach(x => {
                ArticleItemUi articleItemUi = new ArticleItemUi(x);
                articleItemUi.PropertyChanged += ArticleItemUi_PropertyChanged;
                _articles.Add(articleItemUi);
            });
        }

        private void ArticleItemUi_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged("articles");
        }

        public ObservableCollection<ArticleItemUi> articles { get { return _articles; } set { 
                _articles = value;

                NotifyPropertyChanged(); 
            } }

        public string articleNames {
            get {
                String val = "";
                foreach (ArticleItemUi item in _articles)
                {
                    val += item.ToString() + "\r\n";
                }
                return val; 
            } 
        }

        public string dates
        {
            get {
                String val = "";

                val += "Anfrage: " + GetDateString(AnfrageDate) + "\r\n";
                val += "Bestellung: " + GetDateString(BestellungDate) + "\r\n";
                val += "Lieferung: " + GetDateString(LieferungDate) + "\r\n";
                val += "Rückgabe: " + GetDateString(RueckgabeDate) + "\r\n";

                return val;
            }
        }

        //public BestellungItem Item { get => _item; set => _item = value; }
        public bool IsValid { get { 
                return _isValid; 
            } 
            set
            {
                bool raiseChange = false;
                if (_isValid != value) {
                    raiseChange = true;
                }
                _isValid = value;
                if (raiseChange) {
                    NotifyPropertyChanged("IsValid");
                }
                
            }
        }

        private string GetDateString(DateTime date) {
            if (date == null) {
                return "";
            }
            return date.ToShortDateString();
        }

        public ObjectId DbId {
            get { return _item1._id; }
        }

        public BestellungItem prepare()
        {

            BestellungItem item = this.ToItem();

            List<ArticleItem> filteredArticles = item.articles.Where(a => ArticleItemValidator.IsValid(a)).ToList();

            if (filteredArticles.Count == 0)
            {
                return null;
            }

            item.articles = filteredArticles;

            return item;
        }

        private BestellungItem ToItem()
        {
            BestellungItem item = new BestellungItem(this);

            return item;
        }
    }


    public class BestellungItemValidator : ValidatorBase
    {
        public static bool IsValid(BestellungItemUi bestellungItem)
        {
            List<ArticleItemUi> filteredArticles = bestellungItem.articles.Where(a => ArticleItemValidator.IsValid(a)).ToList();

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
