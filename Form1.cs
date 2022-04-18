using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;

using Routines = MS539___2021_07_07.Routines;

namespace MS539___2021_07_07
{
    public partial class StockPrice : Form
    {

        // variable location
        ScottPlot.FormsPlot plt;

        public StockPrice()
        {

            InitializeComponent();
            this.plt = formsPlot1;
        }

        private void add_stock_Click(object sender, EventArgs e)
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

        private void update_Click(object sender, EventArgs e) { }

        private void add_box_input_TextChanged(object sender, EventArgs e) { }

        private void comboCollection_Change(object sender, EventArgs e)
        {
            // this should go load the stocks and ticker change should just plot the data.
            // iter load should be able to handle this, then we can cross reference the index of the
            // ticker/list item to get the correct list from the loaded data.
            ComboBox cBox = (ComboBox)sender;

            int colNum = cBox.SelectedIndex + 1;

            // C:\Users\dowright\source\repos\MS-SE\Collections\Collection1\
            string collection_list = String.Format(@"../../../Collections/Collection{0}/collectionList.txt", colNum);

            using var streamReader = File.OpenText(collection_list);

            string[] tickerList = streamReader.ReadToEnd().Split('\n');

            comboTicker.DataSource = tickerList;
        }

        private void comboTicker_Change(object sender, EventArgs e)
        {
            int collectionNum = comboCollections.SelectedIndex + 1;
            ComboBox cBox = (ComboBox)sender;

            string tk = cBox.Text.Trim();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void referenceRadio1(object sender, EventArgs e)
        {
            // S&P 500 reference chart
        }
    }
    public class StockPlot
    {

        public void plotAndRender()
        {
            Routines.StockLoader sL = new Routines.StockLoader();
            List<Routines.StockEntry> ticker_points = sL.load(collectionNum, tk);

            double[] dates = new double[ticker_points.Count];
            double[] low = new double[ticker_points.Count];
            double[] high = new double[ticker_points.Count];
            double[] current = new double[ticker_points.Count];
            for (int i = 0; i < ticker_points.Count; i++)
            {
                dates[i] = DateTime.Parse(ticker_points[i].date).ToOADate();
                low[i] = float.Parse(ticker_points[i].dailyLow, CultureInfo.InvariantCulture.NumberFormat);
                high[i] = float.Parse(ticker_points[i].dailyHigh, CultureInfo.InvariantCulture.NumberFormat);
                current[i] = float.Parse(ticker_points[i].current);
                Debug.WriteLine(ticker_points[i].toString());
            }

            plt.Plot.AddScatter(dates, low);
            plt.Plot.AddScatter(dates, high);
            plt.Plot.AddScatter(dates, current);
            //plt.Plot.GetPlottables();
            plt.Plot.XAxis.DateTimeFormat(true);

            // define tick spacing as 1 day (every day will be shown)
            //plt.Plot.XAxis.ManualTickSpacing(1, ScottPlot.Ticks.DateTimeUnit.Day);
            //plt.Plot.XAxis.TickLabelStyle(rotation: 45);

            // add some extra space for rotated ticks
            plt.Plot.XAxis.SetSizeLimit(min: 50);

            plt.Render();
        }

    }
}
