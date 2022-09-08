using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionProject
{
    public class Selection
    {
        
        public string Expected
        {
            get { return _expected; }
            set
            {
                foreach(char c in value)
                {
                    if(!Char.IsLetterOrDigit(c))
                        throw new InvalidEx(value);
                    _expected = value;
                }
            }
        }
        private string _expected;
        public string Improve { get; set; }
        public string Value { get; set; }

        public string Preference { get; set; }

        public Selection(string expect, string improve, string value, string preference)
        {
            Expected = expect;
            Improve = improve;
            Value = value;
            Preference = preference;
        }
       
    }
}
