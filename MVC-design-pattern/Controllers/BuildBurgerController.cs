using System;
using System.Linq;
using MVC.DAL.Factory;
using MVC.DAL.Model;
using Newtonsoft.Json;

namespace MVC_design_pattern.Controllers
{
    public class BuildBurgerController
    {
        private readonly LocalBurger _localBurger = new LocalBurger();
        private static readonly BurgerCafeDb Db = new BurgerCafeDb();
        private int _sausageCount;
        private int _cheeseSliceCount;
        private int _hamCount;
        private int _beefCount;

        public int AddSausage(IProduct product)
        {
            _localBurger.AddProduct(product);
            _sausageCount++;
            return _sausageCount;
        }
        public int AddCheeseSlice(IProduct product)
        {
            _localBurger.AddProduct(product);
            _cheeseSliceCount++;
            return _cheeseSliceCount;
        }
        public int AddHam(IProduct product)
        {
            _localBurger.AddProduct(product);
            _hamCount++;
            return _hamCount;
        }
        public int AddBeef(IProduct product)
        {
            _localBurger.AddProduct(product);
            _beefCount++;
            return _beefCount;
        }

        public string BuiltBurger(string burgerName, string orderName, User u)
        {
            Burger burger = new Burger
            {
                BurgerBuildDate = DateTime.Now,
                BurgerName = burgerName,
                BurgerComonents = JsonConvert.SerializeObject(_localBurger.GetProducts())
            };
            Order order = new Order {OrderName = orderName};
            try
            {
                Db.Burgers.Add(burger);
                Db.SaveChanges();
                order.UserId = Db.Users.FirstOrDefault(f => f.UserName == u.UserName)?.UserId;
                order.BurgerId = Db.Burgers.FirstOrDefault(f => f.BurgerName == burger.BurgerName)?.BurgerId;
                Db.Orders.Add(order);
                Db.SaveChanges();
                return 0.ToString();
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
