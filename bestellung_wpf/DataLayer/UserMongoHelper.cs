using bestellung_wpf.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bestellung_wpf.DataLayer
{
    class UserMongoHelper : MongoHelper<User>
    {
        protected override string GetCollectionName()
        {
            return "users";
        }

        protected override string GetDatabaseName()
        {
            return "bestellung";
        }
    }
}
