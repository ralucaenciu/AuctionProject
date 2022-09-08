using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuctionProject
{
    public partial class BarChart : Control
    {
        public BarCharValue[] Data { get; set; }
        public BarChart()
        {
            InitializeComponent();

            Data = new BarCharValue[]
            {
                new BarCharValue("ELECTRONICS", 40),
                new BarCharValue("FASHION", 35),
                new BarCharValue("HEALTH&BEAUTY", 67),
                new BarCharValue("SPORTS", 17)
            };
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics graphics = pe.Graphics;
            Rectangle rectangle = pe.ClipRectangle;

            var barWidth = rectangle.Width / Data.Length;
            var maxHeight = rectangle.Height * 0.9;
            var maxValue = Data.Max(x => x.Value);
            var scalingFactor = maxHeight / maxValue;

            for(int i=0; i<Data.Length; i++)
            {
                var barHeight = Data[i].Value * scalingFactor;
                graphics.FillRectangle(
                        Brushes.Green,
                        i * barWidth,
                        (float)(rectangle.Height-barHeight),
                        (float)(barWidth*0.8),
                        (float)barHeight);
            }
             
        }
    }
}
