using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkieurMVVML.Model
{
    public class ListOfSkieur
    {
        [JsonProperty("Skieurs")]
        public List<Skieur> Skieurs { get; set; }

        public ListOfSkieur()
        {
            this.Skieurs = new List<Skieur>();
        }
    }
}
