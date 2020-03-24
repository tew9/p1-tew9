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
    public string SelectedPizza { get; set; }
    public int Id = 0;
    public decimal Price { get; set; }
    // public decimal TotPrice { get; set; }
    public int Quantity { get; set; }
    
    public PizzaViewModel(){}
    public PizzaViewModel(string id)
    {
      //Get List of Pizza associated with the store id.
      Pizzas = _ps.GetPizza(System.Convert.ToInt64(id)); 
      // Sizes = _ps.GetSize();
    }
  }
}