namespace MVC.DAL.Factory
{
    public class Sausage : ProductClass
    {
        public Sausage(double weight, double priceForHundredGrams, string name)
        {
            Weight = weight;
            PriceForHundredGrams = priceForHundredGrams;
            Name = name;
        }

    }
}
