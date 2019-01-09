using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SkieurMVVML.Model;

namespace SkieurMVVML.Services
{
    public class SkieurService : ISkieurService
    {
        private const string urlBase = "http://demo5711899.mockable.io/skieur";
        public async Task<IEnumerable<Skieur>> Refresh()
        {
            var client = new HttpClient();
            var uri = new Uri(urlBase);

            var json = await client.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<ListOfSkieur>(json);

            return result.Skieurs;
        }
    }
}
