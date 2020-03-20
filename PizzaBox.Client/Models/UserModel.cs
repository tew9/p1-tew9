using System.ComponentModel.DataAnnotations;
using PizzaBox.ORMData.Repositories;
using PizzaBox.Domain.Models;
using System.Collections.Generic;

namespace PizzaBox.Client.Models 
{
    public class UserModel
    {
        /*
        Login Model: will create the user input and output properties tighted to Login view
        Check: method that'll check if the user's information are matched the db.
        params: un is username, pw is the password.
        */
        private static readonly StoreRepository _sr = new StoreRepository();


        [Required(ErrorMessage = "Pleas fill in the username")]
        public string UserName { get; set;}

        [Required(ErrorMessage = "Pleas fill in the username")]
        public string Password { get; set; }

        public string Type { get; set; }
        public int UserId { get; set; }

        public List<Store> Stores { get; set; }

        //check if Login is successful.
        public bool Login(string password, User dbuserinfo)
        {
            var pass = password;
            if (dbuserinfo != null) // check if username is correct and pulled any user.
            {
                if(dbuserinfo.password.Equals(pass)) //check if password is correct
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            else
            {
                return false;
            } 
        }

        public UserModel()
        {
            Stores = _sr.Get();
        }
    }
}