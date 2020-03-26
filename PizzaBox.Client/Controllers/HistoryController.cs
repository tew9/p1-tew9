using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.ORMData.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class HistoryController : Controller
  {
    private static readonly OrderRepository _or = new OrderRepository();
    private static readonly StoreRepository _sr = new StoreRepository();
    [HttpPost]
    public IActionResult OrderHistory(HistoryViewModel hm)
    { 
      Order order = new Order();
      long userId = System.Convert.ToInt64(TempData["userid"]);
      order =  _or.Get(userId);
      hm.OrderId = order.OrderId.ToString();
      hm.Price = order.totPrice;
      Store s = _sr.Get(order.StoreId);
      hm.storeName = s.Name;
      return View("History", hm);
      }
    
    [HttpGet]
    public IActionResult OrderHistory()
    { 
      return View("History", new HistoryViewModel());
    }
  }
}