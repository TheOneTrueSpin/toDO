using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class AppData
    {
        public List<User> Users { get; set; } = new List<User>();
        public int? CurrentUserId = null; //null for no user

    }
}
