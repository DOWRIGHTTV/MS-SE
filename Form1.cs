using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Routines = MS539___2021_07_07.Routines;

namespace MS539___2021_07_07 {
    public partial class StockPrice : Form {
        
        // variable location
        int random_int;

        public StockPrice() {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

            MessageBox.Show("something, lol.");
        }

        // add_stock button
        private void button4_Click(object sender, EventArgs e)
        {
            string str = add_box_input.Text;

            foreach (char c in str)
            {

                /* debug print for testing validation
                MessageBox.Show(c.ToString()); */

                if (str.Length <= 0 || str.Length > 4)
                {

                    MessageBox.Show("A stock ticker can only have between 1-4 characters.");

                    return;
                }


                if (!char.IsLetter(c))
                {

                    MessageBox.Show("A stock ticker should only contain letters.");

                    return;
                }

            }
            MessageBox.Show("Grabbing ticker info from web.");
        }

        private void delete_stock_Click(object sender, EventArgs e)
        {

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show("are you sure you want to remove the current ticker from the collection?", "confirm action", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // place holder message for deletion code
                MessageBox.Show("ticker removed.");
            }

        }
        
        private void update_Click(object sender, EventArgs e)
        { }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            int colNum = listBox.SelectedIndex + 1;

            Routines.StockLoader sL = new Routines.StockLoader();

            sL.load(colNum, "amd");
        }

        private void add_box_input_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
