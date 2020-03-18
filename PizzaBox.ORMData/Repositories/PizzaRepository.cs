using System.Collections.Generic;
using PizzaBox.ORMData.Database;
using PizzaBox.Domain.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.ORMData.Repositories
{
  public class PizzaRepository
  {
    private static readonly PizzaBoxDBContext _db = new PizzaBoxDBContext();

    public List<Pizza> Get()
    {
      return _db.Pizzas.Include(ps => ps.PizzaSizes).ToList();
    }

    public List<Pizza> Get(long id)
    {
      var pizza = _db.Pizzas.SingleOrDefault(p => p.Id == id);
      return _db.Pizzas.Include(ps => ps.PizzaSizes) .Where(ps => ps.Id == pizza.Id).ToList();
    }

    public bool Post(Pizza pizza, PizzaSize ps)
    {
      _db.Pizzas.Add(pizza);
      return _db.SaveChanges() == 1;
    }

    public bool Put(Pizza pizza, Size size)
    {
      List<Pizza> p = Get(pizza.Id);
      foreach(var ps in p)
      {
        ps.Name = pizza.Name;
        ps.Id = pizza.Id;
        foreach(var s in ps.PizzaSizes)
        {
          s.Size = size;
        }
      }
      return _db.SaveChanges() == 1;
    }
  }
}