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
    public class NewAnfrageView : INotifyPropertyChanged
    {
        private MainWindowView mainView;

        private BestellungItemUi _bestellungItem;

        private BestellungItemMongoHelper bestellungItemMongoHlper = new BestellungItemMongoHelper();

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<string> _customerList;

        private List<string> _fahrzeugList;

        public NewAnfrageView(MainWindowView view) {
            mainView = view;
            _bestellungItem = new BestellungItemUi(bestellungItemMongoHlper.CreateNew(mainView.CurrentUser.name));

            _customerList = bestellungItemMongoHlper.GetDistinct<string>("customer");
            _fahrzeugList = bestellungItemMongoHlper.GetDistinct<string>("fahrzeug");


            for (int i = 1; i < 6; i++)
            {
                ArticleItem articleItem = new ArticleItem(true);

                ArticleItemUi articleItemUi = new ArticleItemUi(articleItem);
                articleItemUi.index = i;
                this.BestellungItem.AddArticle(articleItemUi);
            }

        }

        public BestellungItemUi BestellungItem { get { return _bestellungItem; } set { _bestellungItem = value; NotifyPropertyChanged(); } }

        public List<String> CustomerList { get { return _customerList; }}

        public List<string> FahrzeugList { get => _fahrzeugList; set => _fahrzeugList = value; }
    }
}
