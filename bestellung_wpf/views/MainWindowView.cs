using bestellung_wpf.DataLayer;
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
        private BestellungItemMongoHlper bestellungItemMongoHlper = new BestellungItemMongoHlper();

        private GlobalValues globalValues;

        public BestellungItemCollection bestellungItemObservable { get; set; }

        public MainWindowView() {
            globalValues = ((App)Application.Current).GlobalValues;
            if (globalValues.UserList.Count == 0) {
                return;
            }

            bestellungItemObservable = new BestellungItemCollection();

           

            /*int userIndex = 0;

            for (int i = 1; i < 11; i++)
            {
                BestellungItem item = new BestellungItem();
                item.id = "id-" + i;
                item.customer = "Kunde: " + i;
                item.betrag = i;
                item.endBetrag = 1 * 2;
                item.anzahlung = 3;
                item.anfrageDate = DateTime.Now;
                item.bestellungDate = DateTime.Now.AddDays(2 * i);
                item.fahrgestellnummer = "fahrgestellnummer: " + i;
                item.fahrzeug = "fahrzeug: " + i;
                item.hsnTsn = "hsn-tsn: " + i;
                item.lieferungDate = DateTime.Now.AddDays(4 * i);
                item.rueckgabeDate = DateTime.Now.AddDays(6 * i);
                item.status = "Anfrage";
                item.user = globalValues.UserList[userIndex].name;
                userIndex++;
                if (userIndex >= globalValues.UserList.Count) {
                    userIndex = 0;
                }
                for (int a = 1; a < 4; a++) {
                    ArticleItem articleItem = new ArticleItem();
                    articleItem.name = "name " + i + ":" + a;
                    articleItem.articleNumber = "articleNumber " + i + ":" + a;
                    articleItem.manufacturer = "manufacturer " + i + ":" + a;
                    articleItem.partNumber = "partNumber " + i + ":" + a;
                    item.articles.Add(articleItem);
                }
                

                bestellungItemObservable.List.Add(item);
                bestellungItemMongoHlper.CreateDocument(item);
            }*/
        }

        public void insertNewBestellung(BestellungItemUi bestellungItem)
        {
            bestellungItemMongoHlper.CreateDocument(bestellungItem.Item);
            
            ReloadData();
        }

        public void ReloadData() {
            List<BestellungItem> documentList = bestellungItemMongoHlper.GetAllDocuments();
            bestellungItemObservable.List.Clear();
            for (int i = 0; i < documentList.Count; i++)
            {
                bestellungItemObservable.List.Add(new BestellungItemUi(documentList[i]));

            }
            
        }
    }
}
