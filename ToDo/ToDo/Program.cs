// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices.JavaScript;
using ToDo.Models;
using ToDo.Services;

var serviceProvider = new ServiceCollection()
    .AddSingleton<AppData>()
    .AddSingleton<AuthService>()
    .AddSingleton<ListManagementService>()
    .AddSingleton<ParserService>()
    .AddSingleton<ProgramLoopService>()
    .AddSingleton<UserManagerService>()
    .BuildServiceProvider();

var programLoopService = serviceProvider.GetService<ProgramLoopService>();
if (programLoopService is null)
{
    throw new NullReferenceException();
}
programLoopService.WelcomeScreen();
Thread.Sleep(1000);
programLoopService.StartProgramLoop();




