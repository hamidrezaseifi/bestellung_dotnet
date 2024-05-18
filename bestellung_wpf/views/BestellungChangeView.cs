using bestellung_wpf.DataLayer;
using bestellung_wpf.enums;
using bestellung_wpf.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace bestellung_wpf.views
{
    public class BestellungChangeView : INotifyPropertyChanged
    {
        private MainWindowView mainView;

        private BestellungItemUi _bestellungItem;

        private readonly BestellungChangeType bestellungChangeType;

        private BestellungItemMongoHelper bestellungItemMongoHlper = new BestellungItemMongoHelper();

        public event PropertyChangedEventHandler PropertyChanged;


        private bool CanUserAdd => _bestellungItem.articles.Count < 100;
        private bool _CanUserAddRow;
        public bool CanUserAddRow { get => _CanUserAddRow; set { 
                _CanUserAddRow = value;
                NotifyPropertyChanged(nameof(CanUserAddRow));
            } 
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (bestellungChangeType == BestellungChangeType.NewAnfrage || bestellungChangeType == BestellungChangeType.Bestellen)
            {
                if (!_bestellungItem.HasLastEmpty())
                {
                    _bestellungItem.AddArticle(new ArticleItemUi(new ArticleItem(true)));
                }
            }

           
        }

        private List<string> _customerList;

        private List<string> _fahrzeugList;

        public BestellungChangeView(MainWindowView view, BestellungItemUi itemUi, BestellungChangeType _bestellungChangeType) {
            bestellungChangeType = _bestellungChangeType;
            mainView = view;
            _bestellungItem = itemUi;

            foreach(ArticleItemUi articleItemUi in itemUi.articles) { 
                if (_bestellungChangeType == BestellungChangeType.NewAnfrage)
                {
                    articleItemUi.IsEnable = true;
                }
                if (_bestellungChangeType == BestellungChangeType.Bestellen)
                {
                    articleItemUi.IsEnable = true;
                }
                if (_bestellungChangeType == BestellungChangeType.Liefern)
                {
                    articleItemUi.IsEnable = articleItemUi.status == BestellungStatus.Bestellt;
                }
                if (_bestellungChangeType == BestellungChangeType.Rueckgabe)
                {
                    articleItemUi.IsEnable = articleItemUi.status == BestellungStatus.Liefert;
                }
                //articleItemUi.IsEnable = false;
            }
            //_bestellungItem.articles.Add(new ArticleItemUi(new ArticleItem(true)));

            _customerList = bestellungItemMongoHlper.GetDistinct<string>("customer");
            _fahrzeugList = bestellungItemMongoHlper.GetDistinct<string>("fahrzeug");

            _bestellungItem.PropertyChanged += _bestellungItem_PropertyChanged;
            if (_bestellungChangeType == BestellungChangeType.NewAnfrage || _bestellungChangeType == BestellungChangeType.Bestellen) {
                if (!_bestellungItem.HasLastEmpty())
                {
                    _bestellungItem.AddArticle(new ArticleItemUi(new ArticleItem(true)));
                }
            }
                
            itemUi.IsValid = true;
        }

        public bool IsArticleSelected
        {
            get
            {
                return _bestellungItem.articles.AsParallel().Where(a => a.Selected).Count() > 0;
            }

        }

        public bool CanClose
        {
            get
            {
                return IsArticleSelected && BestellungItemValidator.IsValid(_bestellungItem);
            }

        }

        public void prepareItem()
        {
            BestellungStatus status = BestellungStatus.Anfrage;
            if (bestellungChangeType == BestellungChangeType.Bestellen)
            {
                status = BestellungStatus.Bestellt;
            }
            if (bestellungChangeType == BestellungChangeType.Liefern)
            {
                status = BestellungStatus.Liefert;
            }
            if (bestellungChangeType == BestellungChangeType.Rueckgabe)
            {
                status = BestellungStatus.Rueckgabe;
            }

            foreach (ArticleItemUi articleItemUi in _bestellungItem.articles) {
                if (articleItemUi.Selected) {
                    articleItemUi.status = status;
                }
            }
            _bestellungItem.status = status;
        }

        private void _bestellungItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged();
        }

        public BestellungItemUi BestellungItem { get { return _bestellungItem; } set { _bestellungItem = value; NotifyPropertyChanged(); } }

        public List<String> CustomerList { get { return _customerList; }}

        public List<string> FahrzeugList { get => _fahrzeugList; set => _fahrzeugList = value; }

        public string Title { 
            get {
                if (bestellungChangeType == BestellungChangeType.Bestellen)
                {
                    return "Anfrage Bestellen ...";
                }
                if (bestellungChangeType == BestellungChangeType.Liefern)
                {
                    return "Bestellung liefern ...";
                }
                if (bestellungChangeType == BestellungChangeType.Rueckgabe)
                {
                    return "Bestellung Rückgeben ...";
                }

                return " üngultig!!!!!! ";
            }
        }
    }
}
