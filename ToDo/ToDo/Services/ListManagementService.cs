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
        private readonly UserManagerService _userManagerService;
        public ListManagementService(AppData appData, UserManagerService userManagerService)
        {
            _appData = appData;
            _userManagerService = userManagerService;
        }
        public void AddItem(string input)
        {
            User? user = _userManagerService.GetUser();
            if (user is null)
            {
                Console.WriteLine("You are not logged in");
                return;
            }
            ToDoItem toDoItem = new ToDoItem()
            {
                ToDoTitle = input,
                IsCompleted = false,
                Id = user.CurrentToDoItemId
            };

            user.ToDoItems.Add(toDoItem);
            user.CurrentToDoItemId++;
        }

        public void DeleteItem(int id)
        {
            User? user = _userManagerService.GetUser();
            if (user is null)
            {
                Console.WriteLine("You are not logged in");
                return;
            }

            ToDoItem? toDoItem = GetItemById(id);
            if (toDoItem is null)
            {
                Console.WriteLine("This item does not exist");
                return;
            }
            user.ToDoItems.Remove(toDoItem);

        }

        public void CompleteItem(int id)
        {
            ToDoItem? toDoItem = GetItemById(id);
            if (toDoItem is null)
            {
                Console.WriteLine("This item does not exist");
                return;
            }
            toDoItem.IsCompleted = true;
        }

        public void EditItem(int id, string input)
        {
            ToDoItem? toDoItem = GetItemById(id);
            if (toDoItem is null)
            {
                Console.WriteLine("This item does not exist");
                return;
            }
            toDoItem.ToDoTitle = input;  

        }

        public void ListItems() 
        {
            User? user = _userManagerService.GetUser();
            if (user is null)
            {
                Console.WriteLine("You are not logged in");
                return;
            }

            foreach (ToDoItem toDoItem in user.ToDoItems)
            {
                Console.WriteLine();
                Console.WriteLine($"{toDoItem.Id} - {toDoItem.ToDoTitle} - {(toDoItem.IsCompleted ? "Completed" : "")}");
            }
        }

        private ToDoItem? GetItemById(int toDoItemId) 
        {
            User? user = _userManagerService.GetUser();
            if (user is null)
            {
                return null;
            }
            for (int i = 0; i < user.ToDoItems.Count; i++)
            {
                if (toDoItemId == user.ToDoItems[i].Id)
                {
                    return user.ToDoItems[i];
                }
            }
            return null;
        }


    }
}
