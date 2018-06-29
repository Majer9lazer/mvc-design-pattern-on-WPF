using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MVC.DAL.Factory.Prototype;

namespace MVC.DAL.Factory
{
    public class LocalBurger
    {
        private static readonly Random Rnd = new Random();
        private readonly CheeseSlice _cheeseSlice = new CheeseSlice(weight: Rnd.NextDouble() * Rnd.Next(5, 10), name: "Кусочек сыра", priceForHundredGrams: 4);
        private readonly List<ProductClass> _products = new List<ProductClass>();
        private readonly List<CheeseSlice> _cheeseSlices= new List<CheeseSlice>(); 
        public void AddProduct(ProductClass product)
        {
            _products.Add(product);
        }

        public CheeseSlice AddCheeseSlice()
        {
            CheeseSlice cheese = (CheeseSlice)_cheeseSlice.Clone(_cheeseSlice);
            _cheeseSlices.Add(cheese);
            Console.WriteLine("Добавили сыра");
            return cheese;
        }

        public List<ProductClass> GetProducts() => _products;
        public double GetPriceForProducts()
        {
            double price = 0.00;
            for (int i = 0; i < _products.Count; i++)
                price += _products[i].PriceForHundredGrams * _products[i].Weight;
            for (int i = 0; i < _cheeseSlices.Count; i++)
                price += _cheeseSlices[i].PriceForHundredGrams * _cheeseSlices[i].Weight;
            return price;
        }


    }
}
