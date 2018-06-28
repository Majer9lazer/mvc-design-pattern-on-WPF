using System;
using System.Collections.Generic;
using System.Linq;
using MVC.DAL.Factory.Prototype;

namespace MVC.DAL.Factory
{
    public class LocalBurger
    {
        private static readonly Random Rnd = new Random();
        private readonly CheeseSlice _cheeseSlice = new CheeseSlice(weight: Rnd.NextDouble() * Rnd.Next(5, 10), name: "Кусочек сыра", priceForHundredGrams: 4);
        private readonly List<IProduct> _products = new List<IProduct>();
        public void AddProduct(IProduct product)
        {
            _products.Add(product);
        }

        public CheeseSlice AddCheeseSlice()
        {
            CheeseSlice cheese = (CheeseSlice)_cheeseSlice.Clone(_cheeseSlice);
            _products.Add(cheese);
            Console.WriteLine("Добавили сыра");
            return cheese;
        }

        public List<IProduct> GetProducts() => _products;
        public double GetPriceForProducts()
        {
            double price = 0.00;
            for (int i = 0; i < _products.Count; i++)
                price += _products[i].PriceForHundredGrams * _products[i].Weight;
            return price;
        }


    }
}
