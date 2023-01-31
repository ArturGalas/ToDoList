using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;

namespace ToDo_List_Infrastructure.Commands
{
    public class CreateUser
    {
        public CreateUser()
        {

        }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role role { get; set; }
    }
}
