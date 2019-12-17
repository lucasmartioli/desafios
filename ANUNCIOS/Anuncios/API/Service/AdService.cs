using System.Collections.Generic;
using API.Model;
using API.Model.Database;
using MongoDB.Driver;

namespace API.Service
{
    public class AdService
    {
        private readonly IMongoCollection<Ad> _collection;

        public AdService(IAdDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<Ad>(settings.AdsCollectionName);
        }

        public List<Ad> Get() =>
            _collection.Find(ad => true).ToList();

        public Ad Get(string id) =>
            _collection.Find<Ad>(ad => ad.Id == id).FirstOrDefault();

        public Ad Create(Ad ad)
        {
            _collection.InsertOne(ad);
            return ad;
        }

        public void Update(string id, Ad adIn) =>
            _collection.ReplaceOne(ad => ad.Id == id, adIn);

        public void Remove(Ad adIn) =>
            _collection.DeleteOne(ad => ad.Id == adIn.Id);

        public void Remove(string id) => 
            _collection.DeleteOne(ad => ad.Id == id);
    }        
}