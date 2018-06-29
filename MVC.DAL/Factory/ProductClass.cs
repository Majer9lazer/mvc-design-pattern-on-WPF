using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.Factory
{
    public class ProductClass : IProduct
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double PriceForHundredGrams { get; set; }
    }
}
