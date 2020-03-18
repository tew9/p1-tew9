using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class PizzaSize
  { 
   
   #region Navigational Properties.
    public long Id { get; set;}
    public Pizza Pizza {get; set; } //list of orders referenced using the Id in line 12
    public Size Size { get; set; }
    public long SizeId { get; set; }
   #endregion
  }
}