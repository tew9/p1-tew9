using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.ORMData.Interfaces;
using PizzaBox.ORMData.Database;

namespace PizzaBox.ORMData.Repositories
{
    public class UserRepository: IOperations<User>
    {
        public static readonly PizzaBoxDBContext _db = new PizzaBoxDBContext();
        
        #region Read All Stores
        public List<User>  Get()
        {
            return _db.Users.ToList();
        }
        #endregion
        #region Read one Store
        public User  Get(string username)
        {
            return _db.Users.SingleOrDefault(s => s.username == username);
        }
        #endregion

        #region Write
        public bool Post(User user)
        {
            _db.Users.Add(user);
            return _db.SaveChanges() == 1;
        }
        #endregion

        #region Remove
        public bool Remove(string username)
        {
            var user = _db.Users.SingleOrDefault(un => un.username == username);
            _db.Users.Remove(user);
            return _db.SaveChanges() == 1; //will send the query to the database when the context is being updated.
        }
        #endregion

        #region Update
        public bool Update(User user)
        {
            var st = Get(user.username);
            st = user;
            return _db.SaveChanges() == 1;
        }
        #endregion

    }
}