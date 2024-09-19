using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Enums;
using ToDo.Models;

namespace ToDo.Services
{
    public class ParserService
    {

        public ParsedCommand? ParseInput(string input)
        {
            throw new NotImplementedException();
        }

        private List<string> ParseArgument(string input, int size)//How many arguments there are
        {
            //delete command and seperate the rest into a list
            List<string> seperatedInput = input.Split(" ").ToList();
            if(seperatedInput.Count == 0)
            {
                throw new Exception("Seperated input count is zero");
            }
            seperatedInput.RemoveAt(0);
            return seperatedInput;
            
        }
        
        private Command? ParseCommand(string input) 
        {
            List<string> seperatedInput = input.Split(" ").ToList();
            string? command = seperatedInput.FirstOrDefault();

            if (Enum.TryParse(command, true, out Command outputCommand))
            {
                return outputCommand; 
            }
            else
            {
                return null;
            }
 
        }

    }
}
