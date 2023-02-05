using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;

namespace ToDo_List_Infrastructure.Commands.User
{
    public class Details
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Role Role { get; set; }
    }
}
