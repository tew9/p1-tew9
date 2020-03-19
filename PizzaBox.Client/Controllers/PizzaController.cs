using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class PizzaController : Controller
  {
    [HttpGet]
    public IActionResult Choose(long id)
    {
      var pm = new PizzaViewModel(1);
      
      ViewData["pizza"] =pm.Pizz();
      
      return View(new PizzaViewModel(1));
    }

    [HttpPost]
    public IActionResult Choose(PizzaViewModel model)
    {
      return View();
    }
  }
}