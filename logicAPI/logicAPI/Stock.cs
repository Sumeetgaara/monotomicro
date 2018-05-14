using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logicAPI
{
    public class Stock
    {
        public int ID { get; set; }
        public System.DateTime StockDate { get; set; }
        public string Symbol { get; set; }
        public string OpenStock { get; set; }
        public string CloseStock { get; set; }
        public string LowStock { get; set; }
        public string HighStock { get; set; }
        public string Volume { get; set; }
    }
}
