using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Configuration;
using System;

namespace bestellung_wpf.DataLayer
{
    public abstract class MongoHelper<T> : IMongoHelper<T>
    {
        private readonly string connectionString; // = "mongodb://127.0.0.1:27017";

        public MongoHelper() { 
            this.connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MongoDB"].ToString();
        }

        protected abstract string GetDatabaseName();

        protected abstract string GetCollectionName();

        private IMongoDatabase GetDatabase() {
            MongoClient mongoClient = new MongoClient(this.connectionString);
            return mongoClient.GetDatabase(GetDatabaseName());
        }

        private IMongoCollection<T> GetCollection() {
            IMongoDatabase database = GetDatabase();

            return database.GetCollection<T>(GetCollectionName());
        }

        public void InsertDocument(T document)
        {
            IMongoDatabase database = GetDatabase();
            database.GetCollection<T>(GetCollectionName()).InsertOne(document);
           
        }

        public void DeleteDocuments(FilterDefinition<T> filter)
        {
            IMongoDatabase database = GetDatabase();
            database.GetCollection<T>(GetCollectionName()).DeleteOne(filter);
        }

        public List<T> GetAllDocuments()
        {
            IMongoCollection<T> collection = GetCollection();
            return collection.Find(x => true).ToList();
        }

        public List<T> GetAllDocuments(SortDefinition<T> sort)
        {
            IMongoCollection<T> collection = GetCollection();
            return collection.Find(x => true).Sort(sort).ToList();
        }

        public List<T> GetFilteredDocuments(FilterDefinition<T> filter)
        {
            return GetFilteredDocuments(filter, null);
        }

        public List<T> GetFilteredDocuments(FilterDefinition<T> filter, SortDefinition<T> sort)
        {
            IMongoDatabase database = GetDatabase();
            IFindFluent<T, T> find = database.GetCollection<T>(GetCollectionName()).Find(filter);
            if (sort != null) {
                find = find.Sort(sort);
            }
            return find.ToList();
        }

        public void UpdateDocument(FilterDefinition<T> filter, UpdateDefinition<T> document)
        {
            IMongoDatabase database = GetDatabase();
            database.GetCollection<T>(GetCollectionName()).UpdateOne(filter, document);
        }

        public void UpdateDocument(FilterDefinition<T> filter, T document)
        {
            IMongoDatabase database = GetDatabase();
            ReplaceOneResult res = database.GetCollection<T>(GetCollectionName()).ReplaceOne(filter, document);
            long l = res.MatchedCount;
        }

        public List<S> GetDistinct<S>(String column)
        {
            IMongoDatabase database = GetDatabase();
            return database.GetCollection<T>(GetCollectionName()).Distinct<S>(column, FilterDefinition<T>.Empty).ToList();
        }
    }
}
