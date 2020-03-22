using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
  public class PizzaController : Controller
  {

    private static List<PizzaViewModel> _selection = new List<PizzaViewModel>();
    private static decimal _totalPrice = 0;
    

    [HttpGet]
    public IActionResult Order(string store)
    {       
      return View(new PizzaViewModel());
    }

    [HttpPost]
    public IActionResult Order(PizzaViewModel model)
    {
      // _selection.Add(_totalPrice);
      _selection.Add(model);
      return View("OrderDetails", _selection);
    }

    [HttpGet]
    public IActionResult OrderDetails(int Id)
    {
      _selection.RemoveAt(Id);
      return View("OrderDetails", _selection);
    }

    public IActionResult Checkout(PizzaViewModel model)
    {
      TempData["checkout"] = model.SelectedPizza;
      return View("OrderDetails");
    }
  }
}