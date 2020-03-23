using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class PizzaStore
  { 
   
   public long PizzaStoreId { get; set; }
   #region Navigational Properties.
   public long Id { get; set;}
   public Pizza pizza {get; set; } //list of orders referenced using the Id in line 12
   public Store Store { get; set; }
   public long StoreId { get; set; }
   public int Inventory { get; set; }
   #endregion
  }
}