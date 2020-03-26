
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
        private readonly UserRepository _ur = new UserRepository(); 
        private static readonly StoreRepository _sr = new StoreRepository();

        // public AccountController(UserRepository user_repo)
        // {
        //     _ur = user_repo;
        // }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new AccountViewModel());
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountViewModel account)
        {
            User dbuser = _ur.Get(account.UserName);
            
            if(!ModelState.IsValid)
            {
                ViewData["Error"] = "Wrong Username or Password";
                return View(account);
            }
            if(account.Login(account.Password, dbuser))
            {   
                string usertype = dbuser.type;
                TempData["userid"] = dbuser.Id.ToString();
                TempData["username"] = account.UserName;
                if(usertype == "user")
                {
                    
                    return View("User", new UserModel());
                }
                         
                return View("Store", new UserModel());
            }
            else
            {
                ViewData["Error"] = "Wrong Username or Password";
                return View(account);
            }  
        }
    }
}
