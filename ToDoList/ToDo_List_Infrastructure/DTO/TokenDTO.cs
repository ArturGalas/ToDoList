using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;

namespace ToDo_List_Infrastructure.DTO
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public Role Role { get; set; }
        public long Expires { get; set; }
    }
}
