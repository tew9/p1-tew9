using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.ORMData.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

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
    public string SelectedPizza { get; set; }
    public string SelectedSize { get; set; }

    public long Id {get; set;}
    public decimal Price { get; set; }
    // public int SelectedQnty { get; set; }
     
    public PizzaViewModel()
    {
      Id = DateTime.Now.Ticks;
      //Get List of Pizza associated with the store id.
      Pizzas = _ps.GetPizza(3); 
      
      Sizes = _ps.GetSize();
    }
  }
}