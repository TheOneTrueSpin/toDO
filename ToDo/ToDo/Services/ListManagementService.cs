﻿using System;
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
            int? currentUserId = _appData.CurrentUserId;

            if (currentUserId is null)
            {
                throw new NullReferenceException("damn it, looks like the user is null :)");
            }

            User? user = _userManagerService.GetUserById((int)currentUserId);

            if (user is null)
            {
                throw new NullReferenceException("damn it, looks like the user is null :)");
            }
            //IDs need to be worked out, currently no ID for to do items 
            ToDoItem toDoItem = new ToDoItem()
            {
                ToDoTitle = input,
                IsCompleted = false,
                Id = 1
            };

            user.ToDoItems.Add(toDoItem);

        }

        public void DeleteItem(int id)
        {
            int? currentUserId = _appData.CurrentUserId;

            if (currentUserId is null)
            {
                Console.WriteLine("You must be logged in to list item's");
                return;
            }
            User? user = _userManagerService.GetUserById((int)currentUserId);

            if (user is null)
            {
                throw new NullReferenceException("damn it, looks like the user is null :)");
            }

            ToDoItem? toDoItem = GetItemById(id);
            if (toDoItem is null)
            {
                Console.WriteLine("This item does not exist");
                return;
            }
            user.ToDoItems.Remove(toDoItem);

        }

        public void CompleteItem(string input)
        {

        }

        public void EditItem(int id, string input)
        {

        }

        public void ListItems() 
        {
            int? currentUserId = _appData.CurrentUserId;

            if (currentUserId is null)
            {
                Console.WriteLine("You must be logged in to list item's");
                return;
            }

            User? user = _userManagerService.GetUserById((int)currentUserId);
            
            if (user is null)
            {
                throw new NullReferenceException("damn it, looks like the user is null :)");
            }

            foreach (ToDoItem toDoItem in user.ToDoItems)
            {
                Console.WriteLine();
                Console.WriteLine($"{toDoItem.Id} - {toDoItem.ToDoTitle} - {(toDoItem.IsCompleted ? "Completed" : "")}");
            }
        }

        private ToDoItem? GetItemById(int toDoItemId) 
        {
            int? currentUserId = _appData.CurrentUserId;

            if (currentUserId is null)
            {
                throw new NullReferenceException("damn it, looks like the current user Id is null :)");
            }

            User? user = _userManagerService.GetUserById((int)currentUserId);
            if (user is null)
            {
                throw new NullReferenceException("damn it, looks like the user is null");
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
