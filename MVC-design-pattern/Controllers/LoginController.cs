using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.DAL.Model;

namespace MVC_design_pattern.Controllers
{
    class LoginController
    {
        private static readonly BurgerCafeDb Db = new BurgerCafeDb();
        private static List<User> _users = Db.Users.ToList();
        private static User _user= new User();

        public LoginController()
        {

        }
        public string Login(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                try
                {
                    _user = _users.FirstOrDefault(f => f.UserName == userName);
                    if (_user == null)
                    {
                        _user= new User
                        {
                            UserName = userName,
                            UserDateSignIn = DateTime.Now,
                            UserWindowsAccountName = Environment.UserName
                        };
                        Db.Users.Add(_user);
                        Db.SaveChanges();
                        return 0.ToString();
                    }
                    _user.UserDateSignIn = DateTime.Now;
                    _user.UserWindowsAccountName = Environment.UserName;
                    Db.Entry(_user).State = EntityState.Modified;
                    Db.SaveChanges();
                    return 0.ToString();
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
            return "Вы не заполнили поле.";
        }

        public static User GetCurrentUser() => _user;
    }
}
