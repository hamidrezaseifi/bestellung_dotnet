using bestellung_wpf.DataLayer;
using bestellung_wpf.enums;
using bestellung_wpf.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace bestellung_wpf.views
{
    public class MainWindowView
    {
        private BestellungItemMongoHelper bestellungItemMongoHlper = new BestellungItemMongoHelper();

        private GlobalValues globalValues;

        public BestellungItemCollection bestellungItemObservable { get; set; }

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
        public void InsertNewBestellung(BestellungItemUi bestellungItem)
        {
            bestellungItemMongoHlper.InsertDocument(bestellungItem.prepare());
            
            ReloadData();
        }

        public void ReloadData() {
            List<BestellungItem> documentList = bestellungItemMongoHlper.GetAllDocumentsSorted("anfrageDate");
            bestellungItemObservable.List.Clear();
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
