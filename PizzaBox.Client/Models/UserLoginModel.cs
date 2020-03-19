using System.ComponentModel.DataAnnotations;
using PizzaBox.ORMData.Repositories;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models 
{
    public class UserLoginModel
    {
        /*
        Login Model: will create the user input and output properties tighted to Login view
        Check: method that'll check if the user's information are matched the db.
        params: un is username, pw is the password.
        */
        private static readonly UserRepository _ur = new UserRepository();

        [Required(ErrorMessage = "Pleas fill in the username")]
        public string UserName { get; set;}

        [Required(ErrorMessage = "Pleas fill in the username")]
        public string Password { get; set; }

        public string Type { get; set;}

        //check if Login is successful.
        public bool Login(UserLoginModel  userinfo)
        {
            var dbUserInfo = GetUserInfo(userinfo.UserName);
            if (dbUserInfo != null) // check if username is correct and pulled any user.
            {
                if(dbUserInfo.password.Equals(userinfo.Password)) //check if password is correct
                {
                    SesstionVariables.UserId = dbUserInfo.Id;
                    SesstionVariables.LogFlag = true;
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
        
        public User GetUserInfo(string username)
        {
            return _ur.Get(username);
        }
    }
}