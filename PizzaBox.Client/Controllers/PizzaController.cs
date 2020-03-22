using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
  public class PizzaController : Controller
  {

    private static List<PizzaViewModel> selection = new List<PizzaViewModel>();
    [HttpGet]
    public IActionResult Order(string store)
    {       
      return View(new PizzaViewModel());
    }

    [HttpPost]
    public IActionResult Order(PizzaViewModel model)
    {
      selection.Add(model);
      return View("OrderDetails", selection);
    }

    public IActionResult OrderDetails(int Id)
    {
      selection.RemoveAt(Id);
      return View("OrderDetails", selection);
    }
  }
}