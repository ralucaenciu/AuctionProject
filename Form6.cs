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
    public partial class Form6 : Form
    {
       
        private List<Bidder> _bidder;
        private string _connectionString2 = "Data Source = databaseBidder.db";
        public Form6()
        { 
            InitializeComponent();
            
            _bidder = new List<Bidder>();
        }
        private void DisplayBidder()
        {
            lvBidder.Items.Clear();

            foreach(Bidder bidder in _bidder)
            {
                var listViewItem = new ListViewItem(bidder.FirstName);
                listViewItem.SubItems.Add(bidder.LastName);
                listViewItem.SubItems.Add(bidder.Email);
                listViewItem.SubItems.Add(bidder.Price.ToString());


                listViewItem.Tag = bidder;

                lvBidder.Items.Add(listViewItem);
            }
        }

        private void AddBidder(Bidder bidder)
        {
            
             var query = "INSERT INTO Bidder (FirstName,LastName,Email,Price) VALUES (@firstName,@lastName,@email, @price); SELECT last_insert_rowid();";

			using (SqliteConnection connection2 = new SqliteConnection(_connectionString2))
            {
				SqliteCommand command = new SqliteCommand(query, connection2);
				command.Parameters.AddWithValue("@firstName", bidder.FirstName);
				command.Parameters.AddWithValue("@lastName", bidder.LastName);
				
                command.Parameters.AddWithValue("@email", bidder.Email);
                command.Parameters.AddWithValue("@price", bidder.Price);

                connection2.Open();

				long id = (long)command.ExecuteScalar();
				bidder.Id2 = id;

				_bidder.Add(bidder);
            }     
        }

        private void LoadBidder()
        {
            
             var query = "SELECT * FROM Bidder";

			using (SqliteConnection connection2 = new SqliteConnection(_connectionString2))
            {
				SqliteCommand command2 = new SqliteCommand(query, connection2);

				connection2.Open();

				using (SqliteDataReader reader = command2.ExecuteReader())
                {
					while(reader.Read())
                    {
						long id = (long)reader["Id"];
						string firstName = (string)reader["FirstName"];
						string lastName = (string)reader["LastName"];
						
                        string email= (string)reader["Email"];
                        int price = (int)(reader["Price"]);
                       

                        Bidder bidder = new Bidder(id, firstName, lastName, email,price);
						_bidder.Add(bidder);
                    }
                }
            }
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = textFirst.Text;
            string lastName = textLast.Text;
            
            int price = Convert.ToInt32(textBox1.Text);
            string email = textEmail.Text;

            try {
                var bidder = new Bidder(firstName, lastName, email, price);
                //_bidder.Add(bidder);
                AddBidder(bidder);
                DisplayBidder();
            }   
            catch(Exception)
            {
                MessageBox.Show("Please try again");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
            LoadBidder();
            DisplayBidder();
        }
        private bool IsFirstNameValid()
        {
            return !string.IsNullOrWhiteSpace(textFirst.Text.Trim());
        }

        private void textFirst_Validating(object sender, CancelEventArgs e)
        {
            if (!IsFirstNameValid())
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Last Name is empty!");
            }
        }

        private void textFirst_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }

        private bool IsLastValid()
        {
            return !string.IsNullOrWhiteSpace(textLast.Text.Trim());
        }


        private void textLast_Validating(object sender, CancelEventArgs e)
        {
            if (!IsLastValid())
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Last Name is empty!");
            }
        }

        private void textLast_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }
    }
}
