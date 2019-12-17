using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace API.Model
{
    public class Ad
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string Id;

        [BsonElement("Name"), JsonProperty] 
        public string Name;

        [BsonElement("ImageLink"), JsonProperty]
        public string ImageLink;

        [BsonElement("Value"), JsonProperty] 
        public double Value;
    }
}