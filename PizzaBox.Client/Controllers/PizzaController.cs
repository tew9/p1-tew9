using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class PizzaController : Controller
  {
    [HttpGet]
    public IActionResult Order()
    { 
      // ViewData["pizza"] =pm.Pizz();
      PizzaViewModel pm = new PizzaViewModel();
      ViewData["user"] = SesstionVariables.UserId;
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