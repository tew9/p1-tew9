using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class PizzaOrder
  {
   
   #region Navigational Properties.
    public long Id { get; set; } //pizza Id because it's abstracted it's Id.
    public Pizza Pizza {get; set; }
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public int  Quantity { get; set; }
   #endregion
  }
}