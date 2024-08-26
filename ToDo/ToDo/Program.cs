// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
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


