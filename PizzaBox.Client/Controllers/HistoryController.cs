using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.ORMData.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class HistoryController : Controller
  {
    private static readonly OrderRepository _or = new OrderRepository();
    [HttpGet]
    public IActionResult OrderHistory()
    { 
      
      return View("History");
    }
  }
}