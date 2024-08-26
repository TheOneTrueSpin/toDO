using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Services
{
    public class UserManagerService
    {
        private readonly AppData _appData;
        public UserManagerService(AppData appData)
        {
            _appData = appData;
        }
        
        public void CreateUser(string username, string password)
        {
            User user = new User() 
            {
                Username = username,
                Password = password
            };

        }
        public void DelUser(string username, string password) 
        {
            
        }
        public User GetUserById (int id)
        {
            throw new NotImplementedException();
        }

    }
}
