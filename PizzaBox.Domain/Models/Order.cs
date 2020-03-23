using System;
using System.Collections.Generic;
using System.Linq;


namespace PizzaBox.Domain.Models
{
  public class Order
  {
   
   public long OrderId { get; set; }
  
   public DateTime OrderDate { get; set; }
   public Store Store { get; set; }
   public long StoreId {get; set; }

  //Get the total price of the Order.
   public decimal totPrice {get; set; }
   
   #region Navigational Properties.
    public List<PizzaOrder> PizzaOrders {get; set; }
    public User User { get; set; }
    public long Id { get; set; }
   #endregion

    public Order()
    {
      OrderDate = DateTime.Now;
      PizzaOrders = new List<PizzaOrder>();
    }
  }
}