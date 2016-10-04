using System.IO;
using System.Collections.Generic;

namespace _11_Files
{
    internal class FileStockRepository : IStockRepository, IFileRepository
    {
        private long id = 1;
        StockIO stockIO;
        string dir;
        public FileStockRepository(DirectoryInfo dirInfo)
        {
            if(!dirInfo.Exists)
                dirInfo.Create();
            dir = dirInfo.ToString();
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public long NextId()
        {
            Id++;
            return Id;
        }

        public void SaveStock(Stock stock)
        {
            stock.Id = id;
            Id++;

            stockIO = new StockIO();
            FileInfo fileInfo = new FileInfo(dir + StockFileName(stock));
            stockIO.WriteStock(fileInfo, stock);
        }

        public Stock LoadStock(long id)
        {
            stockIO = new StockIO();
            FileInfo fileInfo = new FileInfo(dir + StockFileName(id));
            return stockIO.ReadStock(fileInfo);
        }

        public List<Stock> FindAllStocks()
        {
            string[] files = Directory.GetFiles(dir);
            List<Stock> stocks = new List<Stock>();
            FileInfo fileInfo;
            stockIO = new StockIO();

            foreach(string file in files)
            {
                fileInfo = new FileInfo(file);
                stocks.Add(stockIO.ReadStock(fileInfo));
            }

            return stocks;
        }

        public void Clear()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);

            foreach(FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
        }

        public string StockFileName(long id)
        {
            return "stock" + id + ".txt";
        }

        public string StockFileName(Stock stock)
        {
            return "stock" + stock.Id + ".txt";
        }
        
    }
}