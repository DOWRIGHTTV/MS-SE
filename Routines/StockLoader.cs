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
        public string ticker;
        public string collection;
        public string date;
        public string time;
        public string dailyHigh; // this will be implemented later if there is time.

        public StockEntry(string ticker, string collection, string date, string time, string dailyHigh)
        {
            this.ticker = ticker;
            this.collection = collection;
            this.date = date;
            this.time = time;
            this.dailyHigh = dailyHigh;
        }

        public string toString()
        {
            return String.Format(
                "StockEntry(ticker->{0}, collection->{1}, date->{2}, time->{3}, daily_high->{4})", 
                ticker, collection, date, time, dailyHigh
            );
        }
    }

    class StockLoader
    {
        public StockLoader() {}

        public void load(int collection, string ticker)
        {
            // C:\Users\dowright\source\repos\MS-SE\Collections\Collection1\
            string stock_file = String.Format(@"../../../Collections/Collection{0}/{1}.csv", collection, ticker);

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

                return;
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("Could not find the stock. Does it exist?");

                return;
            }

            foreach (var entry in entries)
            {
                Debug.WriteLine(entry.toString());                
            }
        }
    }
}
