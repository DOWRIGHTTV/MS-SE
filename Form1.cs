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
        //ScottPlot.FormsPlot plt;
        StockPlot plotHandler;

        public StockPrice()
        {

            InitializeComponent();

            // initializing plot handler
            this.plotHandler = new StockPlot(formsPlot1);
        }

        private void formsPlot1_Load(object sender, EventArgs e) { }

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

            this.plotHandler.clear();

            // ticker list is returned so we can update dropdown
            comboTicker.DataSource = this.plotHandler.loadCollection(colNum);
        }

        private void comboTicker_Change(object sender, EventArgs e)
        {
            int collectionNum = comboCollections.SelectedIndex + 1;

            ComboBox cBox = (ComboBox)sender;
            //string tk = cBox.Text.Trim();
            int tkIndex = cBox.SelectedIndex;

            this.plotHandler.clear();
            this.plotHandler.plotAndRender(tkIndex);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void referenceRadio1(object sender, EventArgs e)
        {
            // S&P 500 reference chart
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                this.plotHandler.setSP500(true);
            } 
            else
            {
                this.plotHandler.setSP500(false);
            }
        }
    }
    public class StockPlot
    {
        private ScottPlot.FormsPlot formPlot;
        private List<List<Routines.StockEntry>> currentCollection;

        // plt is an instance to the forms graph/plotter.
        public StockPlot(ScottPlot.FormsPlot plt)
        {
            this.formPlot = plt;

            plt.Plot.XAxis.Label("Time (Days)");
            plt.Plot.YAxis.Label("Price (Dollars)");

        }

        public void clear()
        {
            this.formPlot.Plot.Clear();
        }

        //public void remove()
        //{
        //    this.formPlot.Plot.Remove();
        //}

        public string[] loadCollection(int collectionNum)
        {
            // C:\Users\dowright\source\repos\MS-SE\Collections\Collection1\
            string collection_list = String.Format(@"../../../Collections/Collection{0}/collectionList.txt", collectionNum);

            using var streamReader = File.OpenText(collection_list);

            string[] tickerList = streamReader.ReadToEnd().Split('\n');

            Routines.StockLoader sL = new Routines.StockLoader();
            this.currentCollection = sL.iterload(collectionNum, tickerList);

            return tickerList;
        }

        public void plotAndRender(int tkIndex)
        {
            List<Routines.StockEntry> prices = this.currentCollection[tkIndex];

            double[] dates = new double[prices.Count];
            double[] low = new double[prices.Count];
            double[] high = new double[prices.Count];
            double[] current = new double[prices.Count];
            for (int i = 0; i < prices.Count; i++)
            {
                dates[i] = DateTime.Parse(prices[i].date).ToOADate();
                //dates[i] = DateTime.ParseExact(prices[i].date, "yyyyMMdd", CultureInfo.InvariantCulture).ToOADate();
                low[i] = float.Parse(prices[i].dailyLow, CultureInfo.InvariantCulture.NumberFormat);
                high[i] = float.Parse(prices[i].dailyHigh, CultureInfo.InvariantCulture.NumberFormat);
                current[i] = float.Parse(prices[i].current);
                //Debug.WriteLine(prices[i].toString());
            }

            this.formPlot.Plot.AddScatter(dates, low);
            this.formPlot.Plot.AddScatter(dates, high);
            this.formPlot.Plot.AddScatter(dates, current);
            //plt.Plot.GetPlottables();
            this.formPlot.Plot.XAxis.DateTimeFormat(true);

            // define tick spacing as 1 day (every day will be shown)
            //this.formPlot.Plot.XAxis.ManualTickSpacing(1, ScottPlot.Ticks.DateTimeUnit.Day);
            //plt.Plot.XAxis.TickLabelStyle(rotation: 45);

            // add some extra space for rotated ticks
            this.formPlot.Plot.XAxis.SetSizeLimit(min: 50);

            this.formPlot.Render();
        }

        public void setSP500(bool show)
        {
            return;
        }
    }
}
