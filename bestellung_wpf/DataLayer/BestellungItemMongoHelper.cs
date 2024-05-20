using bestellung_wpf.enums;
using bestellung_wpf.models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bestellung_wpf.DataLayer
{
    public class BestellungItemMongoHelper : MongoHelper<BestellungItem>
    {
        protected override string GetCollectionName()
        {
            return "bestellung";
        }

        protected override string GetDatabaseName()
        {
            return "bestellung";
        }

        public BestellungItem CreateNew(String user) {

            BestellungItem item = new BestellungItem(CreateNewId(), user);

            return item;
        }

        public string CreateNewId() {
            int iItem = 1;
            DateTime date = DateTime.Now;
            BestellungItem lastItem = GetLastItem(date);
            if (lastItem != null)
            {
                string lastItemId = lastItem.id;
                lastItemId = lastItemId.Substring(9, lastItemId.Length - 9);
                iItem = int.Parse(lastItemId) + 1;

            }

            return BestellungItem.CreateNewId(date, iItem);
        }

        public BestellungItem GetLastItem(DateTime date)
        {
            DateTime from = date.Date;
            DateTime to = date.AddDays(1).Date;

            FilterDefinitionBuilder<BestellungItem> builder = Builders<BestellungItem>.Filter;


            FilterDefinition<BestellungItem> filter = builder.Lt(f => f.anfrageDate, to) & builder.Gt(f => f.anfrageDate, from);
            SortDefinition<BestellungItem> sort = Builders<BestellungItem>.Sort.Descending("anfrageDate");

            List<BestellungItem> items = this.GetFilteredDocuments(filter, sort);
            if (items != null && items.Count > 0)
            {
                return items[0];
            }

            return null;
        }

        public void UpdateDocument(BestellungItem bestellungItem)
        {
            FilterDefinitionBuilder<BestellungItem> builder = Builders<BestellungItem>.Filter;

            FilterDefinition<BestellungItem> filter = builder.Eq(f => f._id, bestellungItem._id);
            base.UpdateDocument(filter, bestellungItem);
        }

        public List<BestellungItem> GetAllDocumentsSorted(string column)
        {
            SortDefinition<BestellungItem> sort = Builders<BestellungItem>.Sort.Descending(column);

            List<BestellungItem> items = this.GetAllDocuments(sort);

            return items;
        }

        public List<BestellungItem> GetByStatusDocumentsSorted(BestellungStatus status, string column)
        {
            SortDefinition<BestellungItem> sort = Builders<BestellungItem>.Sort.Descending(column);

            FilterDefinitionBuilder<BestellungItem> builder = Builders<BestellungItem>.Filter;
            ObjectId oId = ObjectId.Empty;
            FilterDefinition<BestellungItem> filter = builder.Gt(f => f._id, ObjectId.Empty);
            if (status != BestellungStatus.All) {
                filter = builder.Eq(f => f.status, status);
            }

            List<BestellungItem> items = this.GetFilteredDocuments(filter, sort);

            return items;
        }
    }
}
