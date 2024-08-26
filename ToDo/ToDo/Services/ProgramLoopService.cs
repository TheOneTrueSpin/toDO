using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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

        public void WelcomeScreen() { }

        public void StartProgramLoop() { }


    }
}
