namespace _11_Files
{
    internal class Stock : IAsset
    {
        string symbol;
        double pricePerShare, numShares;
        long id = 0;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public double PricePerShare
        {
            get { return pricePerShare; }
            set { pricePerShare = value; }
        }

        public double NumShares
        {
            get { return numShares; }
            set { numShares = value; }
        }

        public Stock() { }

        public Stock(string symbol, double pricePerShare, double numShares)
        {
            Symbol = symbol;
            PricePerShare = pricePerShare;
            NumShares = numShares;
        }

        public void NextId()
        {
            id++;
        }

        public double GetValue()
        {
            return PricePerShare * NumShares;
        }

        public static double TotalValue(IAsset[] stocks)
        {
            double value = 0;

            foreach(IAsset stock in stocks)
            {
                value += stock.GetValue();
            }

            return value;
        }

        public override string ToString()
        {
            return "Stock[symbol=" + Symbol + ",pricePerShare=" + PricePerShare.ToString().Replace(',', '.') + ",numShares=" + NumShares + "]";
        }

        public override bool Equals(object obj)
        {
            Stock stock = (Stock)obj;
            if (stock.Symbol == Symbol && stock.PricePerShare == PricePerShare && stock.NumShares == NumShares)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string GetName()
        {
            return symbol;
        }
    }
}