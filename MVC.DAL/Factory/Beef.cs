using System;

namespace MVC.DAL.Factory
{
    public class Beef:IProduct
    {
        public Beef(double weight, double priceForHundredGrams, string name)
        {
            Weight = weight;
            PriceForHundredGrams = priceForHundredGrams;
            Name = name;
        }
        public double Weight { get; set; }
        public double PriceForHundredGrams { get; set; }
        public string Name { get; set; }
    }
}
