namespace _11_Files
{
    internal interface IFileRepository
    {
        string StockFileName(long id);
        string StockFileName(Stock stock);

        void SaveStock(Stock stock);
    }
}