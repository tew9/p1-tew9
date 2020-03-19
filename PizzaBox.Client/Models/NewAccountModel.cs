using System.ComponentModel.DataAnnotations;
using PizzaBox.ORMData.Repositories;
using PizzaBox.Domain.Models;
using System;

namespace PizzaBox.Client.Models 
{
    public class NewAccountModel
    {
        /*
        Login Model: will create the user input and output properties tighted to Login view
        Check: method that'll check if the user's information are matched the db.
        params: un is username, pw is the password.
        */
        private static readonly UserRepository _ur = new UserRepository();

        [Required(ErrorMessage = "Pleas fill in the username")]
        public string FirstName { get; set;}
        
        [Required(ErrorMessage = "Pleas fill in the username")]
        public string LastName { get; set;}

        [EmailAddress(ErrorMessage = "Pleas fill in the username")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pleas fill in the username")]
        public string Password { get; set;}  

        [Required(ErrorMessage = "Pleas fill in the username")]
        public string UserName { get; set;}

        public long Id {get; set;}

        [Required(ErrorMessage = "Please choose if you are user or store manager")]
        public string Type { get; set;}

        public NewAccountModel()
        {
          Id = DateTime.Now.Ticks;
        }
    }
}