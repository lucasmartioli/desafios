using Newtonsoft.Json;

namespace API.Model
{
    public class Region
    {
        [JsonProperty]
        public string UfState;
        
        [JsonProperty]
        public string City;
    }
}