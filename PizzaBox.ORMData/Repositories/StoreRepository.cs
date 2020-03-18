using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.ORMData.Database;
using Microsoft.EntityFrameworkCore;
using PizzaBox.ORMData.Interfaces;

namespace PizzaBox.ORMData.Repositories
{
    public class StoreRepository: IOperations<Store>
    {
        public static readonly PizzaBoxDBContext _db = new PizzaBoxDBContext();
        
        #region Read All Stores
        public List<Store>  Get()
        {
            return _db.Stores.ToList();
        }
        #endregion

        public List<Store>  GetStorePizzas(long id)
        {
            var store = _db.Stores.SingleOrDefault(s => s.Id == id);
            return _db.Stores.Include(s => s.PizzaStore).Where(s => s.Id == store.Id).ToList(); //select from store where id = id
                                                                                                //join Pizzastore as p on p.Id = store.Id
        }

        #region Read one Store
        public Store  Get(long id)
        {
            return _db.Stores.SingleOrDefault(s => s.Id == id);
        }
        #endregion

        #region Write
        public bool Post(Store store)
        {
            _db.Stores.Add(store);
            return _db.SaveChanges() == 1;
        }
        #endregion

        #region Remove
        public bool Remove(long id)
        {
           var store = _db.Stores.SingleOrDefault(s => s.Id == id);
            _db.Stores.Remove(store);
            return _db.SaveChanges() == 1; //will send the query to the database when the context is being updated.
        }
        #endregion

        #region Update
        public bool Put(Store store)
        {
            var st = Get(store.Id);
            st = store;
            return _db.SaveChanges() == 1;
        }
        #endregion

    }
}