using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Enums;

namespace ToDo.Models
{
    public class ParsedCommand
    {
        public Command Command { get; set; }
        public List<string> Arguments { get; set; } = new List<string>();

    }
}
