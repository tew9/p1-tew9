using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Pizza: AComponents
  {
   #region Navigational Properties
    public List<PizzaOrder> PizzaOrders { get; set; } 
    public List<PizzaStore> PizzaStores { get; set; } 
    public decimal Price { get; set; }
   #endregion
    public Pizza(){}
  }
}