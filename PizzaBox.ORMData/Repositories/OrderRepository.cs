using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.ORMData.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.ORMData.Repositories
{
  public class OrderRepository
  {
    private static readonly PizzaBoxDBContext _db = new PizzaBoxDBContext();
    private static readonly PizzaRepository _pr = new PizzaRepository();

    public List<Order> Get()
    {
      return _db.Orders.Include(p => p.PizzaOrders).ToList();
    }

    public Order Get(long id)
    {
      return _db.Orders.SingleOrDefault(p => p.orderId == id);
    }

    #region Add order
    public bool Put(Order order)
    {
      //_db.Add(po);
      _db.Orders.Add(order);
      return _db.SaveChanges() == 1;
    }
    #endregion

    // public List<Pizza> GetPizzaInfo(long pizzaId)
    // {
    //     return _pr.Get(pizzaId);
    // }
  }
}