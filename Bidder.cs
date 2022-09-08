using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionProject
{
    public class Bidder
    {
        public long? Id2 { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Price { get; set; }
        
       

        public Bidder(string first, string last,string email, int price)
        {
            FirstName = first;
            LastName = last;
            Email = email;
            Price = price;
            
            
        }

        public Bidder(long id, string first, string last, string email, int price)
        :this(first,last,email,price)
        {
            Id2 = id;
        }
    }
}
