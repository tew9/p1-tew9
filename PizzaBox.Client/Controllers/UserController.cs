using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class UserController : Controller
  {
    [HttpGet]
    public IActionResult ChooseStore()
    { 
      // ViewData["pizza"] =pm.Pizz();
      return View();
    }

    [HttpPost]
    public IActionResult ChooseStore(int Id)
    { 
      // ViewData["pizza"] =pm.Pizz();
      return View("User", Id);
    }

  }
}