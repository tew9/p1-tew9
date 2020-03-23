using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.ORMData.Database;
using PizzaBox.ORMData.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class PizzaController : Controller
  {

    private static List<PizzaViewModel> _selection = new List<PizzaViewModel>();
    private static readonly OrderRepository _or = new OrderRepository();
    private static readonly PizzaRepository _pr = new PizzaRepository();
    private static readonly PizzaBoxDBContext _db = new PizzaBoxDBContext();
    
    

    [HttpGet]
    public IActionResult Order()
    { 
      return View(new PizzaViewModel());
    }

    [HttpPost]
    public IActionResult Order(PizzaViewModel model)
    {
      model.Id++;
      foreach(var m in _selection)
      {
        if(m.SelectedSize.Equals(model.SelectedSize) && m.SelectedPizza.Equals(model.SelectedPizza))
        {
          m.Quantity += model.Quantity;
          return View("OrderDetails", _selection);
        }
      }
      _selection.Add(model);
      return View("OrderDetails", _selection);
    }

    [HttpGet]
    public IActionResult OrderDetails(int Id)
    {
      if(Id >= 0){
        _selection.RemoveAt(Id);
      }else
      {
        _selection.RemoveAt(0);
      }
      
      return View("OrderDetails", _selection);
    }

    public IActionResult Checkout(string id)
    {
      
      decimal total;
      total = System.Convert.ToDecimal(id);
      long userId = System.Convert.ToInt64(TempData["userid"]);
    
      Order order = new Order();
      order.UserId = userId;
      order.StoreId = 3;
      order.totPrice = total;

      foreach(var pizza in _selection)
      {
        PizzaOrder po = new PizzaOrder();
        po.Quantity = pizza.Quantity;
        po.OrderId = order.OrderId;
        Pizza p = _pr.Get(pizza.SelectedPizza);
        po.Id = p.Id;
        order.PizzaOrders.Add(po);
        _db.Orders.Add(order);
        var save = _db.SaveChanges() == 1;
      }
      _selection.Clear();
       return View("OrderDetails");
    }
  }
}