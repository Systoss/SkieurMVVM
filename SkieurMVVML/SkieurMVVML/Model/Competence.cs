using Newtonsoft.Json;

namespace SkieurMVVML.Model
{
    public class Competence
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("libelle")]
        public string Libelle { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("moniteur")]
        public string Moniteur { get; set; }
        [JsonProperty("categorie")]
        public Categorie Categorie { get; set; }
    }
}