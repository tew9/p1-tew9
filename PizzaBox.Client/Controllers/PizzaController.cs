using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.ORMData.Database;
using PizzaBox.ORMData.Repositories;
using System;

namespace PizzaBox.Client.Controllers
{
  public class PizzaController : Controller
  {

    private static readonly List<PizzaViewModel> _selection = new List<PizzaViewModel>();
    private static readonly OrderRepository _or = new OrderRepository();
    private static readonly PizzaRepository _pr = new PizzaRepository();
    private static readonly PizzaBoxDBContext _db = new PizzaBoxDBContext();

    public static long storeId;
    [HttpGet]
    public IActionResult Order(string id)
    { 
      // TempData["storeid"] = id.ToString();
      if(id != null){
        storeId = Int64.Parse(id);
      }
      else
      {
        id = storeId.ToString();
      }
      return View(new PizzaViewModel(id));
    }

    [HttpPost]
    public IActionResult Order(PizzaViewModel model)
    {
      model.Id++;
      if(_selection != null)
      {
        foreach(var m in _selection)
        {
          if(m.SelectedPizza.Equals(model.SelectedPizza))
          {
            m.Quantity += model.Quantity;
            return View("OrderDetails", _selection);
          }
        }
      }
      var p = _pr.Get(model.SelectedPizza);
      model.Price = p.Price;
      _selection.Add(model);
      return View("OrderDetails", _selection);
    }

    [HttpGet]
    public IActionResult OrderDetails(string id)
    {
      var Id = Int16.Parse(id);
      if(Id >= 0){
        _selection.RemoveAt(Id);
      }else
      {
        _selection.RemoveAt(Id+1);
      }
      
      return View("OrderDetails", _selection);
    }

    public IActionResult Checkout(string id)
    {
      
      decimal total;
      total = System.Convert.ToDecimal(id);
      long userId = System.Convert.ToInt64(TempData["userid"]);
     
      if(TempData["userid"] == null)
      {
        return View("OrderDetails");
      }
      Order order = new Order();
      order.UserId = userId;
      order.StoreId = storeId;
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
      new PizzaController();
      foreach(var sel in _selection)
      {
        _selection.Remove(sel);
      }
      
      TempData["checkout"] = "Your Order was succesful";
       return View("Checkout");
    }
  }
}