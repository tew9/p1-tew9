using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class PizzaController : Controller
  {
    [HttpGet]
    public IActionResult Order(string UserName, string userId)
    { 
      // ViewData["pizza"] =pm.Pizz();
      PizzaViewModel pm = new PizzaViewModel();
      ViewData["user"] = UserName;
      return View(pm);
    }

    [HttpPost]
    public IActionResult Order(PizzaViewModel model)
    {
      if(model != null){
        ViewData["pizza"] = model;
        return View();
      }
      ViewData["pizza"] = model;
      return View();
    }
  }
}