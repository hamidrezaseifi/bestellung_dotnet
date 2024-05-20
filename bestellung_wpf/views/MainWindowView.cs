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
using System.Windows.Media;

namespace bestellung_wpf.views
{
    public class MainWindowView : INotifyPropertyChanged
    {
        private BestellungItemMongoHelper bestellungItemMongoHlper = new BestellungItemMongoHelper();

        private GlobalValues globalValues;

        private Color _anfrageBackground = Color.FromRgb(230, 230, 255);
        private Color _bestelltBackground = Color.FromRgb(230, 255, 230);
        private Color _liefertBackground = Color.FromRgb(230, 230, 230);
        private Color _rueckgabeBackground = Color.FromRgb(255, 230, 230);

        private BestellungStatus _filterBy = BestellungStatus.All;

        private DateTime _filterDateFrom = DateTime.Now.AddMonths(-2);
        private DateTime _filterDateTo = DateTime.Now;

        private static readonly KeyValuePair<string, string>[] _filterDateColumnList = {
            new KeyValuePair<string, string>("anfrageDate", "Anfrage-Datum"),
            new KeyValuePair<string, string>("bestellungDate", "Bestellung-Datum"),
            new KeyValuePair<string, string>("lieferungDate", "Lieferung-Datum"),
            new KeyValuePair<string, string>("rueckgabeDate", "Rückgabe-Datum"),
        };

        private string _filterDateColumn = "anfrageDate";


        public BestellungItemCollection bestellungItemObservable { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public MainWindowView() {
            globalValues = ((App)Application.Current).GlobalValues;
            if (globalValues.UserList.Count == 0) {
                return;
            }

            bestellungItemObservable = new BestellungItemCollection();

            ReloadData();

        }
        
        public User CurrentUser {
            get { return globalValues.CurrentUser; }
        }

        public Brush AnfrageBackgroundBrush { get => new SolidColorBrush(_anfrageBackground); }
        public Brush BestelltBackgroundBrush { get => new SolidColorBrush(_bestelltBackground); }
        public Brush LiefertBackgroundBrush { get => new SolidColorBrush(_liefertBackground); }
        public Brush RueckgabeBackgroundBrush{ get => new SolidColorBrush(_rueckgabeBackground); }
        public DateTime FilterDateFrom { get => _filterDateFrom; set => _filterDateFrom = value; }
        public DateTime FilterDateTo { get => _filterDateTo; set => _filterDateTo = value; }

        public static KeyValuePair<string, string>[] FilterDateColumnList => _filterDateColumnList;

        public string FilterDateColumn { get => _filterDateColumn; set => _filterDateColumn = value; }

        public void SetFilter(BestellungStatus newFilter)
        {
            
                if (_filterBy != newFilter)
                {
                    _filterBy = newFilter;
                    ReloadData();
                    NotifyPropertyChanged();
                }

            
        }

        public void InsertNewBestellung(BestellungItemUi bestellungItem)
        {
            bestellungItemMongoHlper.InsertDocument(bestellungItem.prepare());
            
            ReloadData();
        }

        public void ReloadData() {
            List<BestellungItem> documentList = bestellungItemMongoHlper.GetByStatusDocumentsSorted(_filterBy, _filterDateColumn, _filterDateFrom, _filterDateTo);
            bestellungItemObservable.List.Clear();
            //_filterBy
            for (int i = 0; i < documentList.Count; i++)
            {
                bestellungItemObservable.List.Add(new BestellungItemUi(documentList[i]));

            }
            
        }

        internal void UpdateBestellung(BestellungItemUi bestellungItem)
        {
            bestellungItemMongoHlper.UpdateDocument(bestellungItem.prepare());

            ReloadData();
        }
    }
}
