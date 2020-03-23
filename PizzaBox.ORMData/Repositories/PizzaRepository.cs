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
      return _db.Pizzas.ToList();
    }

   public List<Size> GetSize(string name)
    {
      return _db.Sizes.ToList();
    }
    public List<Size> GetSize()
    {
      return _db.Sizes.ToList();
    }

    public Pizza Get(string name)
    {
      return _db.Pizzas.SingleOrDefault(p => p.Name == name);
    }

    public List<Pizza>  GetPizza(long id)
    {
      List<Pizza> lp = new List<Pizza>();

      var Pizzas = _db.Pizzas.Include(ps => ps.PizzaStores); //get all the pizzas
      foreach(var pizza in Pizzas){ 
        foreach(var ps in pizza.PizzaStores) //filter the pizzastore
        {
          if(ps.StoreId == id)
          {
            lp.Add(pizza);
          }
        }
      }                   
      return lp;                                                                //join Pizzastore as p on p.Id = store.Id
    }

    // public bool Post(int inventory)
    // {
    //   // _db.Pizzas.Add(inventory);
    //   return _db.SaveChanges() == 1;
    // }
  }
}