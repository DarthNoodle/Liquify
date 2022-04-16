using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SolidlyPoc
{
    public class DexScrnMarket
    {
        private static readonly HttpClient client = new HttpClient();

        public string schemaVersion { get; set; }
        public Bar[] bars { get; set; }


        public static async Task<DexScrnMarket> GetMarket(string address)
        {

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long epochtime = (long)(DateTime.Now - sTime).TotalMilliseconds;

            string url = $"https://io8.dexscreener.io/u/chart/bars/metis/{address}?from=1648598400000&to={epochtime}&res=1440&cb=7";
            var streamTask = client.GetStreamAsync(url);
            return await JsonSerializer.DeserializeAsync<DexScrnMarket> (await streamTask);
        }
    }


    public class Bar
    {
        public long timestamp { get; set; }
        public string open { get; set; }
        public string openUsd { get; set; }
        public string high { get; set; }
        public string highUsd { get; set; }
        public string low { get; set; }
        public string lowUsd { get; set; }
        public string close { get; set; }
        public string closeUsd { get; set; }
        public string volumeUsd { get; set; }
    }

}
