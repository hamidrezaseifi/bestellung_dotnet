using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace bestellung_wpf.DataLayer
{
    public interface IMongoHelper<T>
    {
        List<T> GetAllDocuments();

        List<T> GetAllDocuments(SortDefinition<T> sort);

        List<T> GetFilteredDocuments(FilterDefinition<T> filter);

        List<T> GetFilteredDocuments(FilterDefinition<T> filter, SortDefinition<T> sort);

        void InsertDocument(T document);

        void UpdateDocument(FilterDefinition<T> filter, UpdateDefinition<T> document);

        void DeleteDocuments(FilterDefinition<T> filter);

        List<S> GetDistinct<S>(String column);


    }
}
