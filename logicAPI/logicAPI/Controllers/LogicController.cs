using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace logicAPI.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class LogicController : Controller
    {
        [Route("getallAsync")]
        [HttpGet]
        public async Task<List<Stock>> getallAsync()
        { 
        string URI = "http://localhost:49976/api/stocks";
        var templist=await GetStockInformation(URI);
        return templist;
        }


        public async Task<List<Stock>> GetStockInformation(string url)
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
                        return stockList;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}