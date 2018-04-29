using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace businesslayer
{
   public class BLclass
    {
        public List<Stock> list = new List<Stock>();
        public  async Task<List<Stock>> getstocks()
        {
            
            string URI = "http://localhost:49976/api/stocks";
            await GetStockInformation(URI, true);
            return list;
        }


        public async Task GetStockInformation(string url, Boolean flag)
        {
            List<Stock> stockList = new List<Stock>();
            List<Stock> dupList = new List<Stock>();

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var stockJson = await response.Content.ReadAsStringAsync();

                        stockList = JsonConvert.DeserializeObject<Stock[]>(stockJson).ToList();
                        if (flag == true)
                        {
                            list = stockList;
                        }
                    }
                }
            }
        }
    }
}
