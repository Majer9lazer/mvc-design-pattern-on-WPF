namespace MVC.DAL.Factory.Prototype
{
    public class CheeseSlice : Clonable
    {
        public CheeseSlice(string name, double weight, double priceForHundredGrams)
        {
            Name = name;
            Weight = weight;
            PriceForHundredGrams = priceForHundredGrams;
        }

        public override Clonable Clone(object obj)
        {
            return (Clonable)obj;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public double PriceForHundredGrams { get; set; }
    }
}
