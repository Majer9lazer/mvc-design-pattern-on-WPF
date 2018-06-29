using System.Collections.Generic;

namespace MVC.DAL.Factory.Singleton
{
    public class MoneyCounter
    {
        private static readonly List<ProductClass> Products = new List<ProductClass>();
        private static MoneyCounter _counter;
        private MoneyCounter() { }

        public static MoneyCounter GetMoneyCounter()
        {
            if (_counter == null)
                // ReSharper disable once InconsistentlySynchronizedField
                _counter = new MoneyCounter();
            lock (_counter)
                return _counter;
        }
        
        public static void LogBuyes(ProductClass product) => Products.Add(product);

        public string ShowLoggedData()
        {
            string str = "Купили : \n";
            foreach (ProductClass product in Products)
            {
                str += $"{product.Name} , цена за 100 грам = {product.PriceForHundredGrams} , вес = {product.Weight}\n";
            }

            return str;
        }

    }
}
