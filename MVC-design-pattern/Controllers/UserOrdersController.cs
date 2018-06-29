using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.DAL.Factory;
using MVC.DAL.Model;
using Newtonsoft.Json;

namespace MVC_design_pattern.Controllers
{
    public class UserOrdersController
    {
        private static BurgerCafeDb Db = new BurgerCafeDb();

        public List<Order> GetUserOrders(int userId)
        {
            return Db.Orders.Where(w => w.UserId == userId).ToList();
        }

        public double GetTotalPriceForBurger(int burgerId)
        {
            return JsonConvert.DeserializeObject<List<ProductClass>>
                 (Db.Burgers.Find(burgerId)?.BurgerComonents)
                .Select(s => new { TotalPrice = s.PriceForHundredGrams * s.Weight })
                .Sum(f => f.TotalPrice);
        }
    }
}
