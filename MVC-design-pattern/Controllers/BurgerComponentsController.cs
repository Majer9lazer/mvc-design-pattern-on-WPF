using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.DAL.Factory;
using MVC.DAL.Model;

namespace MVC_design_pattern.Controllers
{
    public class BurgerComponentsController
    {
        private  List<IProduct> _products= new List<IProduct>();
        public  void SetProducts(List<IProduct> products) => _products = products;
        private  Burger _burger;
        public  void SetBurger(Burger burger)
        {
            _burger = burger;
        }

        public  Burger ReturnBurger() => _burger;
    }
}
