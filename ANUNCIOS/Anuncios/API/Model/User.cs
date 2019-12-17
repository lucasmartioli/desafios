using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace API.Model
{
    public class User
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId), JsonIgnore]
        public string Id;
        
        [BsonElement("Login"), JsonProperty]
        public string Login;
        
        [BsonElement("Password"), JsonProperty]
        public string Password;
    }
}