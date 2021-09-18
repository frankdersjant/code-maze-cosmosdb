using System.Text.Json.Serialization;

namespace code_maze_cosmosdb.Models
{
    public class Item
    {
        [JsonPropertyName("id")]
     
        //NB NB id is with SMALL CAPITILIZATION - otherwise it wont work!!!
        public string id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

    }
}
