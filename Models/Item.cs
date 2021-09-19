using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace code_maze_cosmosdb.Models
{
    public class Item
    {
        [JsonProperty(PropertyName ="id")]
        //NB NB id is with SMALL CAPITILIZATION - (otherwise it wont work!!!) - NOTE the ref to Newtonsoft instead of .Core json serializer
        public string id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

    }
}
