using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Enums;
using ToDo.Models;

namespace ToDo.Services
{
    public class ListManagementService
    {
        private readonly AppData _appData;
        public ListManagementService(AppData appData)
        {
            _appData = appData;
        }
        public void AddItem(string input)
        {

        }

        public void DeleteItem(int id)
        {

        }

        public void CompleteItem(string input)
        {

        }

        public void EditItem(int id, string input)
        {

        }

        public void ListItems() 
        {

        }

        private ToDoItem? GetItemById(int id) 
        {
            throw new NotImplementedException();
        }


    }
}
