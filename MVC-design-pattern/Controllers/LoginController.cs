﻿using System;
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

        public LoginController()
        {

        }
        public string Login(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                try
                {
                    User findedUser = _users.FirstOrDefault(f => f.UserName == userName);
                    if (findedUser == null)
                    {
                        Db.Users.Add(new User()
                        {
                            UserName = userName,
                            UserDateSignIn = DateTime.Now,
                            UserWindowsAccountName = Environment.UserName
                        });
                        Db.SaveChanges();
                        return 0.ToString();
                    }
                    findedUser.UserDateSignIn = DateTime.Now;
                    findedUser.UserWindowsAccountName = Environment.UserName;
                    Db.Entry(findedUser).State = EntityState.Modified;
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
    }
}
