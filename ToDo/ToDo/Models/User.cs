using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class User
    {
        private static int PreviousId = 0;
        public int UserId { get; set; }
        public string Username { get; set; } = "Defualt";
        public string Password { get; set; } = "Defualt";
        public List<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();

        public User()
        {
            PreviousId = PreviousId + 1;
            UserId = PreviousId;
        }


    }
}
