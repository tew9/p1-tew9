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
    public decimal TotalPrice { get; set; }

    public int Id = 0;
    public decimal Price { get; set; }
    // public decimal TotPrice { get; set; }
    // public int SelectedQnty { get; set; }
     
    public PizzaViewModel()
    {
      //Get List of Pizza associated with the store id.
      Pizzas = _ps.GetPizza(3); 
      Sizes = _ps.GetSize();
    }
  }
}