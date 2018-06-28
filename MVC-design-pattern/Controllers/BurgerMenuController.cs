using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.DAL.Model;

namespace MVC_design_pattern.Controllers
{
    public class BurgerMenuController
    {
        private static BurgerCafeDb _db = new BurgerCafeDb();
        public List<Burger> GetBurgers() => _db.Burgers.ToList();
    }
}
