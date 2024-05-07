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

        private BestellungItemMongoHlper bestellungItemMongoHlper = new BestellungItemMongoHlper();

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<String> _customerList;

        public NewAnfrageView(MainWindowView view) {
            mainView = view;
            _bestellungItem = new BestellungItemUi(new BestellungItem());

            _customerList = bestellungItemMongoHlper.GetDistinct<String>("customer");
        }

        public BestellungItemUi BestellungItem { get { return _bestellungItem; } set { _bestellungItem = value; NotifyPropertyChanged(); } }

        public List<String> CustomerList { get { return _customerList; }}


    }
}
