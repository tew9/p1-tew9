using System.ComponentModel.DataAnnotations;
using PizzaBox.ORMData.Repositories;
using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models 
{
    public class AccountViewModel
    {
        /*
        Login Model: will create the user input and output properties tighted to Login view
        Check: method that'll check if the user's information are matched the db.
        params: un is username, pw is the password.
        */
        private static readonly UserRepository _ur = new UserRepository();
        private static readonly StoreRepository _sr = new StoreRepository();

        //[Required(ErrorMessage = "Pleas fill in the username")]
        public string FirstName { get; set;}
        
        //[Required(ErrorMessage = "Pleas fill in the username")]
        public string LastName { get; set;}

        //[EmailAddress(ErrorMessage = "Pleas fill in the username")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pleas fill in the Password")]
        public string Password { get; set;}  

        [Required(ErrorMessage = "Pleas fill in the Username")]
        public string UserName { get; set;}

        public List<Store> ListOfStores { get; set; }
        public long Id {get; set;}

        // [Required(ErrorMessage = "Please choose if you are user or store manager")]
        public string Type { get; set;}

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

        public AccountViewModel()
        {
          Id = DateTime.Now.Ticks;
          ListOfStores = _sr.Get();
        }
    }
}