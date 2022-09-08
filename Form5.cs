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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            
              if (txtUsername.Text == "raluca" && txtPassword.Text == "1234")
            {
                Form8 form8 = new Form8();
                this.Hide();
                form8.ShowDialog();
                this.Close();

            }
              else if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                Form7 form7 = new Form7();
                this.Hide();
                form7.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("The username or password you entered is incorrect!");
                txtUsername.Clear();
                txtPassword.Clear();
                //txtUsername.Focus();
            }
             
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            /*
             * 
             */
        }

        private void Form5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                //this.close() inchide doar formularul respectiv
                Application.Exit(); // aplication inchide tot
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                //this.close() inchide doar formularul respectiv
                Application.Exit(); // aplication inchide tot
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) txtPassword.UseSystemPasswordChar = true;
            else txtPassword.UseSystemPasswordChar = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
