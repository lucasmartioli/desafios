using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace API.Model
{
    public class Ad
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId), JsonIgnore]
        public string Id;

        [BsonElement("Name"), JsonProperty] 
        public string Name;

        [BsonElement("Value"), JsonProperty] 
        public decimal? Value;
        
        [BsonElement("Link"), JsonProperty]
        public string Link;

    }
}