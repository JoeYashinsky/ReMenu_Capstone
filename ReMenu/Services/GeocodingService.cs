using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReMenu.Services
{
    public class GeocodingService
    {
        public GeocodingService()
        {

        }

        public async Task<Geocoding> GetGeocoded(string url)
        {
            HttpClient client = new HttpClient();
            //url += ApiKeys.GetGeocodingKey();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Geocoding>(json);
            }
            return null;
        }
    }
}
