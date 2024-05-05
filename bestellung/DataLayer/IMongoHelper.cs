using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace bestellung.DataLayer
{
    public interface IMongoHelper<T>
    {
        List<T> GetAllDocuments();

        List<T> GetFilteredDocuments(FilterDefinition<T> filter);

        void CreateDocument(T document);

        void UpdateDocument(FilterDefinition<T> filter, UpdateDefinition<T> document);

        void DeleteDocuments(FilterDefinition<T> filter);

    }
}
