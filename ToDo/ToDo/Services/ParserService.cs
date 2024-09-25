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
        private Dictionary<Command, int> commandArgumentSizeDictionary = new Dictionary<Command, int>()
        {
            {Command.Add, 1},
            {Command.Delete, 1},
            {Command.Complete, 1},
            {Command.Edit, 2},
            {Command.List, 0},
            {Command.Signup, 2},
            {Command.LogIn, 2},
            {Command.LogOut, 0}
        };
        public ParsedCommand? ParseInput(string input)
        {

            Command? command = ParseCommand(input);
            //work out argument size 
            if (command is null)
            {
                return null;
            }
            List<string> arguments = ParseArguments(input, GetArgumentSize((Command)command));
            //i was up to here hkjdf sakhjla sdfhkljdasfkhjlafdskjlhadfslkhjadsflkhjiadsfljkh
            ParsedCommand parsedCommand = new ParsedCommand
            {
                Command = (Command)command,
                Arguments = arguments

            };
            return parsedCommand;
        }

        private List<string> ParseArguments(string input, int argumentSize)//How many arguments there are
        {
            //delete command and seperate the rest into a list
            List<string> seperatedInput = input.Split(" ").ToList();
            if(seperatedInput.Count == 0)
            {
                throw new Exception("Seperated input count is zero");
            }
            seperatedInput.RemoveAt(0);

            //Redo the list so it splits it into the argument size

            if(argumentSize == 0)
            {
                return new List<string>();
            }

            List<string> seperatedArguments = seperatedInput.Take(argumentSize - 1).ToList();

            string text = string.Join(" ", seperatedInput.TakeLast(seperatedInput.Count - (argumentSize - 1)));
            // takes the rest of the input and puts it back together in the list
            seperatedArguments.Add(text);

            return seperatedArguments;
            
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
        private int GetArgumentSize(Command command)
        {
            //if(command == Command.Add)
            //{
            //    return 1;
            //}
            //else if (command == Command.Delete)
            //{
            //    return 1;
            //}
            //else if (command == Command.Complete)
            //{
            //    return 1;
            //}
            //else if (command == Command.Edit)
            //{
            //    return 2;
            //}
            //else if (command == Command.List)
            //{
            //    return 0;
            //}
            //else if (command == Command.Signup)
            //{
            //    return 2;
            //}
            //else if (command == Command.LogIn)
            //{
            //    return 2;
            //}
            //else if (command == Command.LogOut)
            //{
            //    return 0;
            //}
            if (!commandArgumentSizeDictionary.ContainsKey(command))
            {
                throw new Exception("Argument size not found for command");
            }

            return commandArgumentSizeDictionary[command];
        }

    }
}
