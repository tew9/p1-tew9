using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class StoreController : Controller
  {
    [HttpGet]
    public IActionResult add()
    { 
      return View();
    }

    public IActionResult Inventory()
    {
      return View();
    }

  }
}