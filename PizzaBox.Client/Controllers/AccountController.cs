
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
        public IActionResult Login(UserModel account)
        {
            User dbuser = _ur.Get(account.UserName);

            if(!ModelState.IsValid)
            {
                return View(account);
            }
            if(account.Login(account.Password, dbuser))
            {   
                string usertype = dbuser.type;
                
                if(usertype == "user")
                {
                    return View("User", account);
                }

                return View("Store", account);
            }
            else
            {
                ViewData["Error"] = "Wrong Username or Password";
                return View(account);
            }  
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return  View();
        }
    }
}
