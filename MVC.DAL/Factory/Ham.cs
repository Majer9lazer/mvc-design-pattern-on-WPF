using System;

namespace MVC.DAL.Factory
{
    public class Ham : ProductClass
    {
        public Ham(double weight, double priceForHundredGrams, string name)
        {
            Weight = weight;
            PriceForHundredGrams = priceForHundredGrams;
            Name = name;
        }

    }
}
