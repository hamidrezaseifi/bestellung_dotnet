using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bestellung_wpf.models
{
    public class ArticleItem
    {
        public string name { get; set; }
        public string manufacturer { get; set; }
        public string articleNumber { get; set; }
        public string partNumber { get; set; }

        public override  string ToString() {
            return name + " Marke(" + manufacturer + ") ArtikelNummer(" + articleNumber + ") PartNummer(" + partNumber + ")";
        }
    }
}
