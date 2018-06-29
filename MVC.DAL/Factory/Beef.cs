using System;

namespace MVC.DAL.Factory
{
    public class Beef : ProductClass
    {
        public Beef(double weight, double priceForHundredGrams, string name)
        {
            Weight = weight;
            PriceForHundredGrams = priceForHundredGrams;
            Name = name;
        }
       
    }
}
