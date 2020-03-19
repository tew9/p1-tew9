using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class StoreController : Controller
  {
    [HttpGet]
    public IActionResult Store()
    { 
      // ViewData["pizza"] =pm.Pizz();
      return View();
    }

   
  }
}