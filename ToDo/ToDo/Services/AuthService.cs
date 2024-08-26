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

        public void SignUp(string username, string password) 
        {
        
        }
        public void Login(string username, string password)
        {

        }
        public void SignOut(string username, string password)
        {

        }
        public bool IsUserStillSignedIn(int userId)
        {
            throw new NotImplementedException();
        }
        
    }
}
