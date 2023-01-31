using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List_Infrastructure.DTO
{
    public class JWTDTO
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}
