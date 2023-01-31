using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;

namespace ToDo_List_Infrastructure.DTO
{
    public class AccountDTO
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public Role role { get; set; }
    }
}
