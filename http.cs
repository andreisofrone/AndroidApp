using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Json;
using Newtonsoft.Json;

namespace Project
{
    public class NetHttp
    {
		MainActivity ad;
		public NetHttp (MainActivity ad)
		{
			this.ad = ad;
		}
        public static async Task<double> FetchWaitAsync(string URL)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(URL).ConfigureAwait(false);
                return JsonConvert.DeserializeObject<double>(result);
            }
        }
    }
}
