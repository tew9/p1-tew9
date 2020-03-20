using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
  public class PizzaController : Controller
  {
    [HttpGet]
    public IActionResult Order(List<Store> store)
    { 
      // ViewData["pizza"] =pm.Pizz();
      string name = "";
      PizzaViewModel pm = new PizzaViewModel();
      foreach(var s in store){
        name = s.Name;
      }
      ViewData["user"] = name;
      
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