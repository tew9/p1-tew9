using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Size : AComponents
  {
    public decimal Price { get; set; }

    #region Navigational Properties
      public List<PizzaOrder> PizzaOrder { get; set; }
    #endregion
    public Size(){}
  }
}