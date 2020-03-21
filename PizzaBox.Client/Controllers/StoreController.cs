using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class StoreController : Controller
  {
    [HttpGet]
    public IActionResult Add()
    { 
      return View();
    }

    public IActionResult Inventory()
    {
      return View();
    }

  }
}