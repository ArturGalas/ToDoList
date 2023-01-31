using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;

namespace ToDo_List_Infrastructure.DTO
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string name { get; set; }
        public DateTime CreateAt { get; set; }
        public IEnumerable<TaskDTO> tasks { get; set; }
    }
}
