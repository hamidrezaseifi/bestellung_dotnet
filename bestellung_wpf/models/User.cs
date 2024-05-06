using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Windows.Media;

namespace bestellung_wpf.models
{
    public class User
    {
        private SolidColorBrush _brush;

        [BsonId]
        public ObjectId _id { get; set; }

        public string name { get; set; }

        public string color { get; set; }

        public SolidColorBrush Brush{
            get {
                if (_brush == null) {
                    String[] colors = color.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    byte r = Byte.Parse(colors[0]);
                    byte g = Byte.Parse(colors[1]);
                    byte b = Byte.Parse(colors[2]);
                    this._brush = new SolidColorBrush(Color.FromRgb(r, g, b));
                }
                

                return this._brush;
            }
        }
    }
}
