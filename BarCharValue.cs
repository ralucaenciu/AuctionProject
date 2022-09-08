using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionProject
{
    public class BarCharValue
    {
        public string  Label { get; set; }
        public float Value { get; set; }

        public BarCharValue(string label, float value)
        {
            Label = label;
            Value = value;
        }
    }
}
