using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.ORMData.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PizzaBox.Client.Models
{
  public class PizzaViewModel
  {
    //Display Properties
    static readonly PizzaRepository _ps =  new PizzaRepository();
    public List<Pizza> Pizzas { get; set; }
    public List<Size> Sizes { get; set; }
    public int Quantity { get; set; }

    //Returning properties after user's choice
    public Pizza SelectedPizza { get; set; }
    public Size SelectedSize { get; set; }

    public int SelectedQnty { get; set; }
     
    public PizzaViewModel(long id)
    {
      Pizzas = _ps.GetPizza(1); //Get List of Pizza associated with the store id.
      Sizes = _ps.GetSize();
    }

    public List<Pizza> Pizz()
    {
      return _ps.GetPizza(1);
    }
  }
}