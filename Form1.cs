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

            // formatting to show dates on x axis
            formsPlot1.Plot.XAxis.DateTimeFormat(true);
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

            // swap out current collection list with the newly selected
            comboTicker.DataSource = this.plotHandler.loadCollection(colNum);

            // 30 days will be default so we need to ensure it is checked appropriately
            view30.Checked = true;

            // all plots shown in default view
            low_price.Checked = true;
            current_price.Checked = true;
            high_price.Checked = true;

            // all refs hidden in default view
            SP500.Checked = false;
        }

        private void comboTicker_Change(object sender, EventArgs e)
        {
            int collectionNum = comboCollections.SelectedIndex + 1;

            ComboBox cBox = (ComboBox)sender;

            int tkIndex = cBox.SelectedIndex;

            bool[] enabledPlots = new bool[] { low_price.Checked, current_price.Checked, high_price.Checked };

            this.plotHandler.clear(true);
            this.plotHandler.loadTicker(tkIndex, enabledPlots);
            this.plotHandler.render();
        }

        private void view_Clicked(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;

            // this will protect the app from trying to load tickers for an unused/empty collection
            if (comboTicker.DataSource == null)
            {
                radio.Checked = false;
                return; 
            }

            // hijacking this property to quick assign values based on sender object
            int offset = radio.ImageIndex;

            bool[] enabledPlots = new bool[] { low_price.Checked, current_price.Checked, high_price.Checked };

            this.plotHandler.timeLimit = offset;

            this.plotHandler.clear();
            this.plotHandler.loadTicker(comboTicker.SelectedIndex, enabledPlots);
            this.plotHandler.render();
        }

        private void ref1_Clicked(object sender, EventArgs e)
        {
            CheckBox cBox = (CheckBox)sender;

            // if collection isnt loaded, force uncheck (default) and return
            if (comboTicker.DataSource == null)
            {
                cBox.Checked = false;
                return;
            }

            Debug.WriteLine("ref clicked");

            if (cBox.Checked) { this.plotHandler.addRef(0); }

            else { this.plotHandler.removeRef(0); }
        }

        private void price_Clicked(object sender, EventArgs e)
        {
            CheckBox cBox = (CheckBox)sender;

            // if collection isnt loaded, force check (default) and return
            if (comboTicker.DataSource == null)
            {
                cBox.Checked = false;
                return;
            }

            // hijacking this property to quick assign values based on sender object
            int plotIndex = cBox.ImageIndex;

            if (cBox.Checked) { this.plotHandler.add(plotIndex); }

            else { this.plotHandler.remove(plotIndex); }
        }
    }
    public class StockPlot
    {
        private ScottPlot.FormsPlot formPlot;
        private List<List<Routines.StockEntry>> currentCollection;
        private Routines.StockLoader stockLoader;

        private List<ScottPlot.Plottable.ScatterPlot> stockPlots = new() { };

        private List<ScottPlot.Plottable.ScatterPlot> stockReferencePlots = new() { };
        private List<List<Routines.StockReference>> stockReferenceData = new() { };
        private String[] refMap = new String[] { "sp500" };

        private double priceNormalizer { get; set; } = 0;

        public int timeLimit { get; set; } = 30;


        // plt is an instance to the forms graph/plotter.
        public StockPlot(ScottPlot.FormsPlot plt)
        {
            this.formPlot = plt;

            plt.Plot.XAxis.Label("Time (Days)");
            plt.Plot.YAxis.Label("Price (Dollars)");

            this.stockLoader = new Routines.StockLoader();

            // SP500
            this.stockReferenceData.Insert(0, this.stockLoader.loadReference("sp500"));
        }

        public void clear(bool skipRefs=false)
        {
            if (this.stockPlots.Count == 0) { return; }

            this.formPlot.Plot.Remove(this.stockPlots[0]);
            this.formPlot.Plot.Remove(this.stockPlots[1]);
            this.formPlot.Plot.Remove(this.stockPlots[2]);

            if (!skipRefs)
            {
                this.formPlot.Plot.Remove(this.stockReferencePlots[0]);
            }
        }

        public void render()
        {
            this.formPlot.Render();
        }

        public void add(int plotIdx)
        {
            this.formPlot.Plot.Add(stockPlots[plotIdx]);

            this.render();
        }

        public void remove(int plotIdx)
        {
            this.formPlot.Plot.Remove(stockPlots[plotIdx]);

            this.render();
        }

        public string[] loadCollection(int collectionNum)
        {
            // C:\Users\dowright\source\repos\MS-SE\Collections\Collection1\
            string collection_list = String.Format(@"../../../Collections/Collection{0}/collectionList.txt", collectionNum);

            string[] tickerList;
            try
            {
                using var streamReader = File.OpenText(collection_list);

                tickerList = streamReader.ReadToEnd().Split('\n');
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Could not find the collection. Does it exist?");

                return null;
            }

            this.currentCollection = this.stockLoader.iterload(collectionNum, tickerList);

            return tickerList;
        }

        public void loadTicker(int tkIndex, bool[] enabledPlots)
        {
            List<Routines.StockEntry> prices = this.currentCollection[tkIndex];

            int ITER_PTR;
            int time = this.timeLimit;
            if (time > prices.Count) { ITER_PTR = 0; time = prices.Count; }
            else { ITER_PTR = prices.Count - time; }

            double[] dates = new double[time];
            double[] current = new double[time];
            double[] low = new double[time];
            double[] high = new double[time];
            for (int i = 0; i < time; i++)
            {
                dates[i] = DateTime.Parse(prices[ITER_PTR].date).ToOADate();
                low[i] = float.Parse(prices[ITER_PTR].dailyLow, CultureInfo.InvariantCulture.NumberFormat);
                current[i] = float.Parse(prices[ITER_PTR].current);
                high[i] = float.Parse(prices[ITER_PTR].dailyHigh, CultureInfo.InvariantCulture.NumberFormat);
                //Debug.WriteLine(prices[i].toString());
                ITER_PTR++;
            }
            // setting normalizer value to current prices first index of selected time range
            this.priceNormalizer = current[0];

            Debug.WriteLine("PRICE NORMALIZER");
            Debug.WriteLine(this.priceNormalizer);

            // low
            var scatterLow = new ScottPlot.Plottable.ScatterPlot(dates, low)
            {
                Color = Color.Red,
                MarkerSize = 10
            };

            stockPlots.Insert(0, scatterLow);
            if (enabledPlots[0]) { this.formPlot.Plot.Add(scatterLow); }

            // current
            var scatterCurrent = new ScottPlot.Plottable.ScatterPlot(dates, current)
            {
                Color = Color.Black,
                MarkerSize = 10
            };

            stockPlots.Insert(1, scatterCurrent);
            if (enabledPlots[1]) { this.formPlot.Plot.Add(scatterCurrent); }

            // high
            var scatterHigh = new ScottPlot.Plottable.ScatterPlot(dates, high)
            {
                Color = Color.Green,
                MarkerSize = 10
            };

            stockPlots.Insert(2, scatterHigh);
            if (enabledPlots[2]) { this.formPlot.Plot.Add(scatterHigh); }

            // SP500 - deferred so we can normalize the values
            this.loadReference(0);
        }

        private void loadReference(int refIndex)
        {
            List<Routines.StockReference> prices = this.stockReferenceData[refIndex];

            int ITER_PTR;
            int time = this.timeLimit;
            if (time > prices.Count) { ITER_PTR = 0; time = prices.Count; }
            else { ITER_PTR = prices.Count - time; }

            Debug.WriteLine(float.Parse(prices[ITER_PTR].price, CultureInfo.InvariantCulture.NumberFormat));
            // this value is used to keep reference data values closer to the selected tickers values
            double priceModifier = this.priceNormalizer / float.Parse(prices[ITER_PTR].price, CultureInfo.InvariantCulture.NumberFormat);

            Debug.WriteLine("PRICE MODIFIER");
            Debug.WriteLine(priceModifier);

            double[] dates = new double[time];
            double[] price = new double[time];
            for (int i = 0; i < time; i++)
            {
                dates[i] = DateTime.Parse(prices[ITER_PTR].date).ToOADate();
                price[i] = float.Parse(prices[ITER_PTR].price, CultureInfo.InvariantCulture.NumberFormat) * priceModifier;

                Debug.WriteLine(price[i]);
                ITER_PTR++;
            }

            var scatterRef = new ScottPlot.Plottable.ScatterPlot(dates, price)
            {
                Color = Color.Blue,
                MarkerSize = 5
            };

            this.stockReferencePlots.Insert(0, scatterRef);
        }

        public void addRef(int refIndex)
        {
            this.formPlot.Plot.Add(this.stockReferencePlots[refIndex]);
            this.render();
        }

        public void removeRef(int refIndex)
        {
            this.formPlot.Plot.Remove(this.stockReferencePlots[refIndex]);
            this.render();
        }
    }
}
