
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.ORMData.Repositories;

namespace PizzaBox.Client.Controllers
{
    public class AccountController : Controller
    {
        //creating account object.
        private static readonly UserLoginModel userInfo = new UserLoginModel();
        private UserRepository _ur;

        public AccountController(UserRepository user_repo)
        {
            _ur = user_repo;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel account)
        {
            User dbuser = _ur.Get(account.UserName);

            if(!ModelState.IsValid)
            {
                return View(account);
            }
            if(account.Login(account.Password, dbuser))
            {   
                string dbtype = dbuser.type;
                
                if(dbtype == "user")
                {
                    return View("User", account);
                }
                
                return View("Store");
                
                // else
                // {
                //     ViewData["Error"] = "You're a "+dbtype+ ", you can't login as \n"+account.Type
                //     +" Please choose the right user type";
                //     return View(account);
                // }
            }
            else
            {
                ViewData["Error"] = "Wrong Username or Password";
                return View(account);
            }  
        }

        public IActionResult Logout()
        {
            return  View();
        }

        public IActionResult Stores()
        {
            return View();
        }
    }
}
