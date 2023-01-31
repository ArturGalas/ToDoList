using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;

namespace ToDo_List_Infrastructure.DTO
{
    public class TaskDetailsDTO
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime EndDate { get; set; }
        public TaskState state { get; set; }
    }
}
