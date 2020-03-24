using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.ORMData.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PizzaBox.Client.Models
{
  public class HistoryViewModel
  {
    //Display Properties
    static readonly OrderRepository _or =  new OrderRepository();
     static readonly PizzaRepository _pr =  new PizzaRepository();

    public List<Pizza> Pizzas { get; set; }
  
    public int OrderId {get; set;}
    public decimal Price { get; set; }
    // public decimal TotPrice { get; set; }
    public int storeId { get; set; }
    
    public HistoryViewModel(){}
    public HistoryViewModel(string id)
    {
      //Get List of Pizza associated with the store id.
      Pizzas = _pr.GetPizza(System.Convert.ToInt64(id)); 
      // Sizes = _ps.GetSize();
    }
  }
}