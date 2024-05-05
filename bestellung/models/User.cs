using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bestellung.models
{
    public class User
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public string name { get; set; }

        public string color { get; set; }

        public int RGB{
            get {
                int argb = Int32.Parse(color.Replace("#", ""), NumberStyles.HexNumber);
                return argb;
            }
        }
    }
}
