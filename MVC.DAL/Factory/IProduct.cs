using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.Factory
{
    public interface IProduct
    {
        string Name { get; set; }
        double Weight { get; set; }
        double PriceForHundredGrams { get; set; }
    }
}
