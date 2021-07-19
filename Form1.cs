using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

					MessageBox.Show("ticker can only have between 1-4 characters.");

					return;
				}


				if (!char.IsLetter(c))
				{

					MessageBox.Show("ticker should only contain letters.");

					return;
				}

			}

			{
				MessageBox.Show("Grabbing ticker info from web.");
			}

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

        private void collection_1_Click(object sender, EventArgs e)
        {

        }
		private void button3_Click(object sender, EventArgs e)
		{

		}
	}
}
