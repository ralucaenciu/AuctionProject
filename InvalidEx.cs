using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionProject
{
    class InvalidEx : Exception
    {

        public string Expected { get; set; }

        public InvalidEx(string expected1)
        {
            Expected = expected1;
        }

        public override string Message
        {
            get
            {
                return  Expected + " is invalid";
            }
        }
    }
}
