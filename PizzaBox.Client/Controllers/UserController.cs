using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class UserController : Controller
  {
    [HttpGet]
    public IActionResult Order()
    { 
      // ViewData["pizza"] =pm.Pizz();
      return View();
    }

    public IActionResult History(int Id)
    { 
      // ViewData["pizza"] =pm.Pizz();
      return View("User", Id);
    }

   
  }
}