using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Enums
{
    public enum Command
    {
        Add = 1, //argument size = 1
        Delete = 2,  //argument size = 1
        Complete = 3, //argument size = 1
        Edit = 4, //argument size = 2
        List = 5, //argument size = 0
        Signup = 6, //argument size = 2
        LogIn = 7, //argument size = 2
        LogOut = 8, //argument size = 0

    }
}
