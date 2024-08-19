using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class User
    {
        public string Username { get; set; } = "Defualt";
        public string Password { get; set; } = "Defualt";
        public List<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();


    }
}
