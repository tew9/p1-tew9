using System.ComponentModel.DataAnnotations;
using PizzaBox.ORMData.Repositories;
using PizzaBox.Domain.Models;
using System.Collections.Generic;

namespace PizzaBox.Client.Models 
{
    public class UserModel
    {
        private static readonly StoreRepository _sr = new StoreRepository();

        public string Id { get; set; }

        public List<Store> Stores { get; set; }
    
        public UserModel()
        {
            Stores = _sr.Get();
        }
    }
}