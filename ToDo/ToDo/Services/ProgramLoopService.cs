using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ToDo.Enums;
using ToDo.Models;

namespace ToDo.Services
{
    public class ProgramLoopService
    {
        private readonly AppData _appData;
        private readonly AuthService _authService;
        private readonly ListManagementService _listManagementService;
        private readonly ParserService _parserService;



        public ProgramLoopService(AppData appdata, AuthService authService, ListManagementService listManagementService, ParserService parserService)
        {
            _appData = appdata;
            _authService = authService;
            _listManagementService = listManagementService;
            _parserService = parserService;
        }

        public void WelcomeScreen()
        {
            Console.WriteLine(" _____ ___________ _____   _     _____ _____ _____  \r\n|_   _|  _  |  _  \\  _  | | |   |_   _/  ___|_   _| \r\n  | | | | | | | | | | | | | |     | | \\ `--.  | |   \r\n  | | | | | | | | | | | | | |     | |  `--. \\ | |   \r\n  | | \\ \\_/ / |/ /\\ \\_/ / | |_____| |_/\\__/ / | |   \r\n  \\_/  \\___/|___/  \\___/  \\_____/\\___/\\____/  \\_/   \r\n                                                    \r\n                                                    ");
            Console.WriteLine("Welcome to Todo's to do list");  
        }

        public void StartProgramLoop()
        {
            Console.Clear();
            while (true)
            {
                try
                {
                    if (_appData.CurrentUserId is null)
                    {
                        Console.WriteLine("To SignUp please type \"SignUp\" followed by a username and password");
                        Console.WriteLine("");
                        Console.WriteLine("To LogIn please type \"LogIn\" followed by a username and password");
                    }
                    else
                    {
                        _listManagementService.ListItems();
                        Console.WriteLine("Inputs: Add, Delete, Edit, Complete, List or LogOut");
                    }
                    string? input = Console.ReadLine();
                    if (input is null)
                    {
                        Console.WriteLine("Input is Invalid");
                        continue;
                    }
                    ParsedCommand? parsedCommand = _parserService.ParseInput(input);
                    if (parsedCommand is null)
                    {
                        Console.WriteLine("Input is Invalid");
                        continue;
                    }

                    if (parsedCommand.Command == Command.Add)
                    {
                        _listManagementService.AddItem(parsedCommand.Arguments[0]);
                    }
                    else if (parsedCommand.Command == Command.Delete)
                    {
                        _listManagementService.DeleteItem(int.Parse(parsedCommand.Arguments[0]));
                    }
                    else if (parsedCommand.Command == Command.Complete)
                    {
                        _listManagementService.CompleteItem(int.Parse(parsedCommand.Arguments[0]));
                    }
                    else if (parsedCommand.Command == Command.Edit)
                    {
                        _listManagementService.EditItem(int.Parse(parsedCommand.Arguments[0]), parsedCommand.Arguments[1]);
                    }
                    else if (parsedCommand.Command == Command.List)
                    {
                        
                    }
                    else if (parsedCommand.Command == Command.Signup)
                    {
                        _authService.SignUp(parsedCommand.Arguments[0], parsedCommand.Arguments[1]);
                    }
                    else if (parsedCommand.Command == Command.LogIn)
                    {
                        _authService.Login(parsedCommand.Arguments[0], parsedCommand.Arguments[1]);
                    }
                    else if (parsedCommand.Command == Command.LogOut)
                    {
                        _authService.SignOut();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (FormatException ex)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid command. \r\n\r\n If you are selecting a list item please use the ID\r\n");
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("An unspecified error was caught");
                    Console.WriteLine(ex.Message);
                }
            }

        }


    }
}
