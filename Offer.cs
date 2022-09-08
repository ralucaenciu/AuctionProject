using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionProject
{
    [Serializable]
    public class Offer
    {

        public long Id { get; set; }
        public string Product { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Details { get; set; }


        public Offer()
        {

        }

        public Offer(string product, string price, string category, string details)
        {
            Product = product;
            Price = price;
            Category = category;
            Details = details;
        }

        public Offer(long id, string product, string price, string category, string details)
            :this(product,price,category,details)
        {
            Id = id;
        }
    }
}
