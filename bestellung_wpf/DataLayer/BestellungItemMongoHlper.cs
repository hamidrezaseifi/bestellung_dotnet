using bestellung_wpf.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bestellung_wpf.DataLayer
{
    public class BestellungItemMongoHlper : MongoHelper<BestellungItem>
    {
        protected override string GetCollectionName()
        {
            return "bestellung";
        }

        protected override string GetDatabaseName()
        {
            return "bestellung";
        }
    }
}
