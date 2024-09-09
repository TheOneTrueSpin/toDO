using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
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
        
        public User? CreateUser(string username, string password)
        {
            User user = new User() 
            {
                Username = username,
                Password = password,
            };
            _appData.Users.Add(user);
            return user;

        }
        public void DelUser(int id) 
        {
            User? user = GetUserById(id);
            if (user is null)
            {
                return;
            }
            _appData.Users.Remove(user);

        }
        public User? GetUserById(int id)
        {
            for (int i = 0; i < _appData.Users.Count; i++)
            {
                if (id == _appData.Users[i].Id)
                {
                    return _appData.Users[i];
                }   
            }

            return null;
        }
        public User? GetUserByUsername(string username)
        {
            for (int i = 0; i < _appData.Users.Count; i++)
            {
                if (username.ToLower() == _appData.Users[i].Username.ToLower())
                {
                    return _appData.Users[i];
                }
            }
            return null;
        }

    }
}
