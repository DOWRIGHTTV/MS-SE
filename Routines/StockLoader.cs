using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CsvHelper;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace MS539___2021_07_07.Routines
{

    // data class to represent a single stock entry
    class StockEntry
    {
        public string ticker { get; set; }
        public string collection { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string current { get; set; }
        public string dailyLow { get; set; }
        public string dailyHigh { get; set; }

        public string toString()
        {
            return String.Format(
                "StockEntry(ticker->{0}, collection->{1}, date->{2}, time->{3}, current->{4}, daily_low->{5}, daily_high->{6})", 
                this.ticker, this.collection, this.date, this.time, this.current, this.dailyLow, this.dailyHigh
            );
        }
    }

    class StockReference
    {
        public string name { get; set; }
        public string date { get; set; }
        public string price { get; set; }
    }

    class StockLoader
    {
        public StockLoader() {}

        public List<List<StockEntry>> iterload(int collection, string[] tickerList)
        {
            List<List<StockEntry>> tickerListData = new List<List<StockEntry>>();
            foreach (var ticker in tickerList)
            {
                tickerListData.Add(load(collection, ticker));
            }

            return tickerListData;
        }

        public List<StockEntry> load(int collection, string ticker)
        {
            // C:\Users\dowright\source\repos\MS-SE\Collections\Collection1\
            string stock_file = String.Format(@"../../../Collections/Collection{0}/{1}.csv", collection, ticker.Trim());

            List<StockEntry> entries;
            try
            {
                // context managers
                using var streamReader = File.OpenText(stock_file);
                using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);

                entries = csvReader.GetRecords<StockEntry>().ToList();
            }
            catch (DirectoryNotFoundException e)
            {
                MessageBox.Show("Could not find the collection. Does it exist?");

                return null;
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("Could not find the stock. Does it exist?");

                return null;
            }
            catch (IOException e)
            {
                MessageBox.Show(String.Format("[{0}] big bada boom.", ticker));

                return null;
            }


            // debug only, unless some conversion is necessary later.
            //foreach (var entry in entries)
            //{
            //    Debug.WriteLine(entry.toString());                
            //}

            return entries;
        }

        public List<StockReference> loadReference(string name)
        {
            string ref_file = String.Format(@"../../../References/{0}_ref.csv", name);

            List<StockReference> entries;

            using var streamReader = File.OpenText(ref_file);
            using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);

            entries = csvReader.GetRecords<StockReference>().ToList();

            Debug.WriteLine(entries.Count);

            return entries;
        }
    }
}
