using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Pizza: AComponents
  {
   #region Navigational Properties
    public List<PizzaOrder> PizzaOrders { get; set; } //many pizzas can be contained in one order and 1 orders can have many piza
    public List<PizzaStore> PizzaStores { get; set; } //Many pizza can be found at the store, and many store can have 1 pizza
    public List<PizzaSize> PizzaSizes { get; set; }
   #endregion
    public Pizza(){}

    public override string ToString()
    {
      return $" {Name ?? "N/A"}";
    }
  }
}