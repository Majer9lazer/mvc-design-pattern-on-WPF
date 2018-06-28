using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.DAL.Model;

namespace MVC_design_pattern.Controllers
{
    class LoginController
    {
        private static BurgerCafeDb _db = new BurgerCafeDb();

        public LoginController()
        {
            
        }
        public string Login(string userName)
        {
            try
            {
                _db.Users.Add(new User()
                {
                    UserName = userName,
                    UserDateSignIn = DateTime.Now,
                    UserWindowsAccountName = Environment.UserName
                });
                _db.SaveChanges();
                return $"Уважаемый (-ая) {userName} добро пожаловать!";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
