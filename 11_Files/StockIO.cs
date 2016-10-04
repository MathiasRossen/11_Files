using System;
using System.IO;

namespace _11_Files
{
    internal class StockIO
    {
        public void WriteStock(StringWriter stringWriter, Stock stock)
        {
            stringWriter.WriteLine(stock.Symbol);
            stringWriter.WriteLine(stock.PricePerShare);
            stringWriter.WriteLine(stock.NumShares);
        }

        public void WriteStock(FileInfo fileInfo, Stock stock)
        {
            string path = fileInfo.ToString();

            StreamWriter streamWriter = new StreamWriter(path);

            streamWriter.WriteLine(stock.Symbol);
            streamWriter.WriteLine(stock.PricePerShare);
            streamWriter.WriteLine(stock.NumShares);

            streamWriter.Close();
        }

        public Stock ReadStock(StringReader stringReader)
        {
            Stock stock = new Stock();

            stock.Symbol = stringReader.ReadLine();
            stock.PricePerShare = double.Parse(stringReader.ReadLine());
            stock.NumShares = double.Parse(stringReader.ReadLine());

            return stock;
        }

        public Stock ReadStock(FileInfo fileInfo)
        {
            Stock stock = new Stock();
            string path = fileInfo.ToString();

            StreamReader streamReader = new StreamReader(path);

            stock.Symbol = streamReader.ReadLine();
            stock.PricePerShare = double.Parse(streamReader.ReadLine());
            stock.NumShares = double.Parse(streamReader.ReadLine());

            streamReader.Close();

            return stock;
        }
    }
}