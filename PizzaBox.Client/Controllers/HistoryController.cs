using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class HistoryController : Controller
  {
    [HttpGet]
    public IActionResult OrderHistory()
    { 
      return View("History");
    }
  }
}