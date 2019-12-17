using System.Collections.Generic;
using API.Model;
using MongoDB.Driver;

namespace API.Service
{
    public class AdService
    {
        private readonly IMongoCollection<Ad> _ads;

        public AdService(IAdDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _ads = database.GetCollection<Ad>(settings.AdsCollectionName);
        }

        public List<Ad> Get() =>
            _ads.Find(ad => true).ToList();

        public Ad Get(string id) =>
            _ads.Find<Ad>(ad => ad.Id == id).FirstOrDefault();

        public Ad Create(Ad ad)
        {
            _ads.InsertOne(ad);
            return ad;
        }

        public void Update(string id, Ad adIn) =>
            _ads.ReplaceOne(ad => ad.Id == id, adIn);

        public void Remove(Ad adIn) =>
            _ads.DeleteOne(ad => ad.Id == adIn.Id);

        public void Remove(string id) => 
            _ads.DeleteOne(ad => ad.Id == id);
    }        
}