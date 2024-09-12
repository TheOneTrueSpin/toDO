using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class ToDoItem
    {
        public required int Id { get; set; }
        public required string ToDoTitle { get; set; }
        public required bool IsCompleted { get; set; }


    }
}
