﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string ToDoTitle { get; set; }
        public bool IsCompleted { get; set; }

    }
}
