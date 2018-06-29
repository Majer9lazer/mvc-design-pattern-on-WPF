using System;
using System.Linq;
using MVC.DAL.Factory;
using MVC.DAL.Factory.Prototype;
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
        private int _maxOrderId = Db.Orders.Select(s => s.OrderId).Max();
        public int AddSausage(ProductClass product)
        {
            _localBurger.AddProduct(product);
            _sausageCount++;
            return _sausageCount;
        }
        public int AddCheeseSlice()
        {
            _localBurger.AddCheeseSlice();
            _cheeseSliceCount++;
            return _cheeseSliceCount;
        }
        public int AddHam(ProductClass product)
        {
            _localBurger.AddProduct(product);
            _hamCount++;
            return _hamCount;
        }
        public int AddBeef(ProductClass product)
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
            Order order = new Order { OrderName = orderName + "#_" + _maxOrderId };
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

        public string BuiltBurger(Burger burger, string orderName, User u)
        {
            Order order = new Order { OrderName = orderName + "#_" + _maxOrderId };
            try
            {
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
