// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices.JavaScript;
using ToDo.Models;
using ToDo.Services;

Console.WriteLine("test");
var serviceProvider = new ServiceCollection()
    .AddSingleton<AppData>()
    .AddSingleton<AuthService>()
    .AddSingleton<ListManagementService>()
    .AddSingleton<ParserService>()
    .AddSingleton<ProgramLoopService>()
    .AddSingleton<UserManagerService>()
    .BuildServiceProvider();

var userManagerService = serviceProvider.GetService<UserManagerService>();
var authService = serviceProvider.GetService<AuthService>();

//UserManagerService.CreateUser("ted", "fred");
//Console.WriteLine(UserManagerService.GetUserById(1).Username);
//Console.WriteLine(UserManagerService.GetUserById(1).Password);


authService.SignUp("jeff", "bezos");
//authService.SignUp("jeff", "makrd");
//authService.SignUp("fdsadf", "bezos");
//authService.SignUp("jeff", "bezos");
//authService.SignUp("jeff", "bezos");
//Console.WriteLine(userManagerService.GetUserByUsername("jeff").Username);

//authService.Login("jeff", "pesos");
//authService.Login("mark", "bezos");
authService.Login("jeff", "bezos");



