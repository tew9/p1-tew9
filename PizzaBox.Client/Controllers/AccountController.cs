
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
    public class AccountController : Controller
    {
        //creating account object.
        private static readonly UserLoginModel userInfo = new UserLoginModel();

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
        public IActionResult Login(UserLoginModel userinfo)
        {
            if(ModelState.IsValid)
            {
                if(userinfo.Login(userinfo))
                {   
                    string dbtype = userinfo.GetUserInfo(userinfo.UserName).type;

                    if(userinfo.Type == "user" && userinfo.Type.Equals(dbtype))
                    {
                        return RedirectToAction("Choose", "Pizza");
                    }
                    else if(userinfo.Type == "store" && userinfo.Type.Equals(dbtype))
                    {
                        return RedirectToAction("Stores", userinfo);
                    }
                    else
                    {
                        ViewData["Error"] = "You're a "+dbtype+ ", you can't login as \n"+userinfo.Type
                        +" Please choose the right user type";
                        return View(userinfo);
                    }
                }
                else
                {
                    ViewData["Error"] = "Wrong Username or Password";
                    return View(userinfo);
                } 
            }  
    
             return View(); 
        }

        public IActionResult Stores()
        {
            return View();
        }
    }
}
