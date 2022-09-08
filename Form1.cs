using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AuctionProject
{
    public partial class Form1 : Form
    {
        private List<Offer> _offers;
        private string _connectionString = "Data Source = databaseOffers.db";
        public Form1()
        {
            InitializeComponent();
            _offers = new List<Offer>();
        }

        public void DisplayOffers()
        {
            dgvOffers.Rows.Clear();

            foreach (Offer offers in _offers)
            {
                int rowIndex = dgvOffers.Rows.Add(new object[]
                    {offers.Product,
                    offers.Price,
                    offers.Category,
                    offers.Details
                    });

                DataGridViewRow row = dgvOffers.Rows[rowIndex];
                row.Tag = offers;
            }
        }

        private void AddOffer(Offer offer)
        {
            var sql = "INSERT INTO Offer(Product,Price,Category,Details) VALUES (@product,@price,@category,@details); SELECT last_insert_rowid();";
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                SqliteCommand command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@product", offer.Product);
                command.Parameters.AddWithValue("@price", offer.Price);
                command.Parameters.AddWithValue("@category", offer.Category);
                command.Parameters.AddWithValue("@details", offer.Details);

                connection.Open();
                long id =(long)command.ExecuteScalar();
                offer.Id = id;

                _offers.Add(offer);


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string product = tbProduct.Text;
            string price = tbPrice.Text;
            string category = cbCategory.Text;
            string details = rtDetails.Text;

            var offers = new Offer(product, price, category, details);
            //_offers.Add(offers);
            AddOffer(offers);

            DisplayOffers();
        }

        

        private void btDelete_Click(object sender, EventArgs e)
        {
            
             if(dgvOffers.SelectedRows.Count == 0)
			{
				MessageBox.Show("Choose a participant!");
				return;
			}

			if(MessageBox.Show(
				"Are you sure you want to permanently delete this participant?",
				"Delete Participant",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning) == DialogResult.Yes)
            {
				
				DataGridViewRow row = dgvOffers.SelectedRows[0];
				
				Offer offers = (Offer)row.Tag;
                //_offers.Remove(offers);
                DeleteOffer(offers);
				DisplayOffers();
            }
        }

        private void DeleteOffer(Offer offer)
        {
            string sql = "DELETE FROM Offer WHERE Id=@id";
            using(SqliteConnection connection = new SqliteConnection(_connectionString)){
                SqliteCommand command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", offer.Id);

                connection.Open();
                command.ExecuteNonQuery();

                _offers.Remove(offer);
            }

        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvOffers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Choose a participant!");
                return;
            }

            DataGridViewRow row = dgvOffers.SelectedRows[0];
            Offer offer = (Offer)row.Tag;
            Form3 form3 = new Form3(offer);
            if (form3.ShowDialog() == DialogResult.OK)
                DisplayOffers();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("serialized.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Offer>));

                using (FileStream stream = File.OpenRead("serialized.xml"))
                {
                    _offers = (List<Offer>)serializer.Deserialize(stream);
                    DisplayOffers();
                }
            
            
            }

            LoadOffer();
            DisplayOffers();
        }

        private void serializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.Create("serialized.bin"))
            {
                formatter.Serialize(stream, _offers);
            }
        }

        private void deserializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenRead("serialized.bin"))
            {
                _offers = (List<Offer>)formatter.Deserialize(stream);
                DisplayOffers();

            }

        }

        private void serializeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Offer>));
            using (FileStream stream = File.Create("serialized.xml"))
            {
                serializer.Serialize(stream, _offers);
            }
        }

        private void deserializeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Offer>));

            using (FileStream stream = File.OpenRead("serialized.xml"))
            {
                _offers = (List<Offer>)serializer.Deserialize(stream);
                DisplayOffers();

            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV File | *.csv";
            saveFileDialog.Title = "Export CSV";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = File.CreateText(saveFileDialog.FileName))
                {
                    writer.WriteLine("Product,Price,Category,Details");
                    foreach (Offer offer in _offers)
                        writer.WriteLine($"{offer.Product},{offer.Price},{offer.Category},{offer.Details}");
                }
            }
        }

        private void LoadOffer()
        {
            var sql = "SELECT * FROM Offer";
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
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
                        _offers.Add(offer);
                    }
                }
            }
        }

        private void serializeToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearFields() // metoda utilitara
        {
            tbProduct.Clear();
            tbPrice.Clear();         
            rtDetails.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void xMLSerializationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}


