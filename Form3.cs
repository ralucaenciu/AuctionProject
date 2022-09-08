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
    public partial class Form3 : Form
    {
        private Offer _offer;

        public Form3(Offer offer)
        {
            InitializeComponent();
            _offer = offer;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            tbProduct.Text = _offer.Product;
            tbPrice.Text = _offer.Price;
            cbCategory.Text = _offer.Category;
            rtDetails.Text = _offer.Details;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _offer.Product= tbProduct.Text;
            _offer.Price= tbPrice.Text;
            _offer.Category= cbCategory.Text;
            _offer.Details= rtDetails.Text;
        }
    }
}
