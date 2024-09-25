using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Services
{
    public class AuthService
    {
        private readonly AppData _appData;
        private readonly UserManagerService _userManagerService;

        public AuthService(AppData appData, UserManagerService userManagerService)
        {
            _appData = appData;
            _userManagerService = userManagerService;
        }

        public bool SignUp(string username, string password) 
        {
            if(_userManagerService.GetUserByUsername(username) is not null)
            {
                //Console.WriteLine("user not created");
                return false;
            }
            _userManagerService.CreateUser(username, password);
            //Console.WriteLine("user created");
            return true;
        }
        public void Login(string username, string password)
        {
            User? user = _userManagerService.GetUserByUsername(username);
            if (user is null)
            {
                Console.WriteLine("The user \"" + username + "\" does not exist");
                return;
            }

            if (password == user.Password)
            {
                _appData.CurrentUserId = user.Id;
                Console.Clear();
                Console.WriteLine("You are now logged in as " + username);
                return;
            }
            Console.WriteLine("Password is incorrect");
        }
        public void SignOut()
        {
            if(_appData.CurrentUserId is null)
            {
                Console.WriteLine("Unable to log out due to the fact you are not logged in");
            }
            _appData.CurrentUserId = null;
        }

        public bool IsUserStillSignedIn(int userId)
        {
            if (_appData.CurrentUserId is not null) 
            {
                return true;
            }
            return false;
        }
        
    }
}
