namespace MVC.DAL.Factory
{
 public   class Sausage : IProduct
    {
        public Sausage(double weight, double priceForHundredGrams, string name)
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
