using Newtonsoft.Json;

namespace SkieurMVVML.Model
{
    public class Categorie
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("libelle")]
        public string Libelle { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}