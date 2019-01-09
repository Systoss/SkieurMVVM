using Newtonsoft.Json;
using System.Collections.Generic;

namespace SkieurMVVML.Model
{
    public class Skieur
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        [JsonProperty("niveau")]
        public string Niveau { get; set; }
        [JsonProperty("competences")]
        public List<Competence> Competences { get; set; }
        public Skieur()
        {
            this.Competences = new List<Competence>();
        }
    }
}