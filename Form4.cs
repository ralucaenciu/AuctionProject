using Microsoft.Data.Sqlite;
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
    public partial class Form4 : Form

    {
        private List<Offer> _offers2;
        private string _connectionString2 = "Data Source = databaseOffers.db";

        public Form4()
        {
            InitializeComponent();
            _offers2 = new List<Offer>();
        }

        
         public void DisplayOffers2()
        {
            dgvOffers2.Rows.Clear();

            foreach (Offer offers in _offers2)
            {
                int rowIndex = dgvOffers2.Rows.Add(new object[]
                    {offers.Product,
                    offers.Price,
                    offers.Category,
                    offers.Details
                    });

                DataGridViewRow row = dgvOffers2.Rows[rowIndex];
                row.Tag = offers;
            }
        }
        
         private void LoadOffer2()
        {
            var sql = "SELECT * FROM Offer";
            using (SqliteConnection connection = new SqliteConnection(_connectionString2))
            {
                SqliteCommand command = new SqliteCommand(sql, connection);

                connection.Open();

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = (long)reader["Id"];
                        string product = (string)reader["Product"];
                        string price = (string)reader["Price"];
                        string category = (string)reader["Category"];
                        string details = (string)reader["Details"];

                        Offer offer = new Offer(id,product, price, category, details);
                        _offers2.Add(offer);
                    }
                }
            }
        }
         


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadOffer2();
            DisplayOffers2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
             if (dgvOffers2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Choose a participant!");
                return;
            }

            DataGridViewRow row = dgvOffers2.SelectedRows[0];
            Offer offer = (Offer)row.Tag;
            Form6 form6 = new Form6();
            if (form6.ShowDialog() == DialogResult.OK)
                DisplayOffers2();

        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
