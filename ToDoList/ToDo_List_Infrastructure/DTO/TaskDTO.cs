using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List_Infrastructure.DTO
{
    public class TaskDTO
    {
        public Guid id { get; set; }
        public string title { get; set; }
    }
}
