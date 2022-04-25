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

            // 30 days will be default so we need to ensure it is checked appropriately
            view30.Checked = true;
        }

        private void comboTicker_Change(object sender, EventArgs e)
        {
            int collectionNum = comboCollections.SelectedIndex + 1;

            ComboBox cBox = (ComboBox)sender;
            //string tk = cBox.Text.Trim();
            int tkIndex = cBox.SelectedIndex;

            this.plotHandler.clear();
            this.plotHandler.loadTicker(tkIndex);
            this.plotHandler.render();
        }

        private void view_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton radio = (RadioButton)sender;

            int offset;

            // this filters out the unchecked radio from executing code.
            if (!radio.Checked) { return; }

            if (view30.Checked) { offset = 30; }
            else if (view60.Checked) { offset = 60; }
            else if (view90.Checked) { offset = 90; }
            else if (view352.Checked) { offset = 352; }
            else { return; }

            this.plotHandler.timeLimit = offset;

            this.plotHandler.clear();
            this.plotHandler.loadTicker(comboTicker.SelectedIndex);
            this.plotHandler.render();
        }

        private void referenceRadio1(object sender, EventArgs e)
        {
            // S&P 500 reference chart
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            Debug.WriteLine(String.Format("setting sp500 to > {0}", checkBox.Checked));

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
        private Routines.StockLoader stockLoader;

        private List<ScottPlot.Plottable.ScatterPlot> stockPlots;
        private List<bool> stockfieldSet;


        private List<List<Routines.StockReference>> stockReferenceData = new List<List<Routines.StockReference>> { };
        private List<ScottPlot.Plottable.ScatterPlot> stockReferencePlots = new List<ScottPlot.Plottable.ScatterPlot> { };
        private List<bool> stockReferenceSet = new List<bool> { };

        public int timeLimit { get; set; } = 30;


        // plt is an instance to the forms graph/plotter.
        public StockPlot(ScottPlot.FormsPlot plt)
        {
            this.formPlot = plt;

            plt.Plot.XAxis.Label("Time (Days)");
            plt.Plot.YAxis.Label("Price (Dollars)");

            this.stockLoader = new Routines.StockLoader();

            // loading reference data
            this.stockReferenceData.Add(this.stockLoader.loadReference("sp500"));

            // this will let show method know to create the plottable.
            this.stockReferenceSet.Add(false);
        }

        public void clear()
        {
            this.formPlot.Plot.Clear();
        }

        public void render()
        {
            this.formPlot.Render();
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

            this.currentCollection = this.stockLoader.iterload(collectionNum, tickerList);

            return tickerList;
        }

        public void loadTicker(int tkIndex)
        {
            List<Routines.StockEntry> prices = this.currentCollection[tkIndex];

            Debug.WriteLine(String.Format("current time limit > {0}", this.timeLimit));

            int ITER_PTR;
            int time = this.timeLimit;
            if (time > prices.Count) { ITER_PTR = 0; time = prices.Count; }
            else { ITER_PTR = prices.Count - time; }

            double[] dates = new double[time];
            double[] low = new double[time];
            double[] high = new double[time];
            double[] current = new double[time];
            for (int i = 0; i < time; i++)
            {
                dates[i] = DateTime.Parse(prices[ITER_PTR].date).ToOADate();
                low[i] = float.Parse(prices[ITER_PTR].dailyLow, CultureInfo.InvariantCulture.NumberFormat);
                high[i] = float.Parse(prices[ITER_PTR].dailyHigh, CultureInfo.InvariantCulture.NumberFormat);
                current[i] = float.Parse(prices[ITER_PTR].current);
                //Debug.WriteLine(prices[i].toString());
                ITER_PTR++;
            }

            this.formPlot.Plot.AddScatter(dates, low);
            this.formPlot.Plot.AddScatter(dates, high);
            this.formPlot.Plot.AddScatter(dates, current);
            //plt.Plot.GetPlottables();
            this.formPlot.Plot.XAxis.DateTimeFormat(true);

            // define tick spacing as 1 day (every day will be shown)
            //this.formPlot.Plot.XAxis.ManualTickSpacing(1, ScottPlot.Ticks.DateTimeUnit.Day);
        }

        private void referencePlot(int refIndex)
        {
            List<Routines.StockReference> prices = this.stockReferenceData[refIndex];

            int ITER_PTR;
            int time = this.timeLimit;
            if (time > prices.Count) { ITER_PTR = 0; time = prices.Count; }
            else { ITER_PTR = prices.Count - time; }

            double[] dates = new double[time];
            double[] price = new double[time];
            for (int i = 0; i < time; i++)
            {
                dates[i] = DateTime.Parse(prices[ITER_PTR].date).ToOADate();
                price[i] = float.Parse(prices[ITER_PTR].price, CultureInfo.InvariantCulture.NumberFormat);
            }

            ScottPlot.Plottable.ScatterPlot refPlot = new ScottPlot.Plottable.ScatterPlot(dates, price);

            //this.formPlot.Plot.Add(refPlot);
            this.formPlot.Plot.AddScatter(dates, price);

            this.stockReferencePlots.Insert(0, refPlot);
            this.stockReferenceSet[0] = true;
        }

        public void setSP500(bool show)
        {
            if (show)
            {
                // lazy build the plot since it has not been done yet.
                if (!this.stockReferenceSet[0])
                {
                    Debug.WriteLine("building reference plot");
                    this.referencePlot(0);
                }

                //Debug.WriteLine("adding plottable");
                //this.clear();
                //this.formPlot.Plot.Add(this.stockReferencePlots[0]);
            }
            else
            {
                if (this.stockReferenceSet[0])
                {
                    Debug.WriteLine("removing plottable");
                    this.formPlot.Plot.Remove(this.stockReferencePlots[0]);
                }
            }

            // re render the change to plots.
            Debug.WriteLine("re rendering ref.");
            this.render();
        }
    }
}
