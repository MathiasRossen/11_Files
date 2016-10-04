using System.Collections.Generic;

namespace _11_Files
{
    internal interface IStockRepository
    {
        long NextId();
        void SaveStock(Stock asset);
        Stock LoadStock(long id);
        List<Stock> FindAllStocks();
        void Clear();
    }
}