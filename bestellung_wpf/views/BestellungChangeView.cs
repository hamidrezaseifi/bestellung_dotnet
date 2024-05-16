using bestellung_wpf.DataLayer;
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

        private BestellungItemMongoHlper bestellungItemMongoHlper = new BestellungItemMongoHlper();

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

            if (!_bestellungItem.HasLastEmpty()) {
                _bestellungItem.AddArticle(new ArticleItemUi(new ArticleItem(true)));
            }
        }

        private List<string> _customerList;

        private List<string> _fahrzeugList;

        public BestellungChangeView(MainWindowView view, BestellungItemUi itemUi) {
            mainView = view;
            _bestellungItem = itemUi;
            //_bestellungItem.articles.Add(new ArticleItemUi(new ArticleItem(true)));

            _customerList = bestellungItemMongoHlper.GetDistinct<string>("customer");
            _fahrzeugList = bestellungItemMongoHlper.GetDistinct<string>("fahrzeug");

            _bestellungItem.PropertyChanged += _bestellungItem_PropertyChanged;
            if (!_bestellungItem.HasLastEmpty())
            {
                _bestellungItem.AddArticle(new ArticleItemUi(new ArticleItem(true)));
            }
        }

        private void _bestellungItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged();
        }

        public BestellungItemUi BestellungItem { get { return _bestellungItem; } set { _bestellungItem = value; NotifyPropertyChanged(); } }

        public List<String> CustomerList { get { return _customerList; }}

        public List<string> FahrzeugList { get => _fahrzeugList; set => _fahrzeugList = value; }
        
    }
}
