using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreOnret.Models
{
    public class Product
    {
        
        public List<Content> Content { get; set; } = new List<Content>();
        public Currency Currency { get; set; } = new Currency();
        public string CategoryName { get; set; } = string.Empty;
        public List<string> Images { get; set; } = new List<string>();
        public string BrandName { get; set; } = string.Empty;
    }


    public class Currency
    {
        public decimal BuyPrice { get; set; } = 0.0m;
        public decimal ListPrice { get; set; } = 0.0m;
        public decimal SellPrice { get; set; } = 0.0m;
        public currentcyType currentcyType { get; set; } = currentcyType.usd;
    }
    public enum currentcyType
    {
        tl,usd,eur,sar
    }
    public class Content
    {
        string productId = Guid.NewGuid().ToString();
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public LangCode LangCode { get; set; } = LangCode.en;
    }
    public enum LangCode
    {
        tr,en,it,fr,ar,de
    }
}
