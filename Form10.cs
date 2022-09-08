using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuctionProject
{
    public partial class Form10 : Form
        
    {
        private List<Selection> _selection;
        public Form10()
        {
            InitializeComponent();
            _selection = new List<Selection>();
        }

        public void DisplaySelection()
        {
            listView1.Items.Clear();
            

            foreach (Selection selection in _selection)
            {
                var listViewItem = new ListViewItem(selection.Expected);
                listViewItem.SubItems.Add(selection.Improve);
                listViewItem.SubItems.Add(selection.Value);
                listViewItem.SubItems.Add(selection.Preference);

                listViewItem.Tag = selection;

                listView1.Items.Add(listViewItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!ValidateChildren())
            {
                MessageBox.Show(
                    "The form contains validation errors!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            } 

            string expected = txtExpect.Text;
            string improve = txtImprove.Text;
            string value = txtValue.Text;
            string preference = comboBox1.Text;

            try
            {
                var selection = new Selection(expected, improve, value, preference);
                _selection.Add(selection);
                DisplaySelection();
            }
            catch (InvalidEx ex)
            {
                MessageBox.Show("The data is not valid!", ex.Expected);
            }
            catch (Exception)
            {
                MessageBox.Show("An exception has been encountered! Please contact the technical support.");
            }
            finally
            {
                Debug.WriteLine("Always executed");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
