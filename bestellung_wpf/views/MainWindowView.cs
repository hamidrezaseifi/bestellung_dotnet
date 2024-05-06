using bestellung_wpf.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bestellung_wpf.views
{
    public class MainWindowView
    {
        public BestellungItemCollection bestellungItemObservable { get; set; }

        public MainWindowView() {
            bestellungItemObservable = new BestellungItemCollection();

            for (int i = 1; i < 11; i++)
            {
                BestellungItem item = new BestellungItem();
                item.id = "id-" + i;
                item.customer = "Kunde: " + i;
                item.betrag = i;
                item.endBetrag = 1 * 2;
                item.anzahlung = 3;

                bestellungItemObservable.List.Add(item);
            }
        }
    }
}
