using Newtonsoft.Json;

namespace API.Model
{
    public class Parameters
    {
        [JsonProperty]
        public string ProductName;
     
        [JsonProperty]
        public Region SearchRegion;
    }
}