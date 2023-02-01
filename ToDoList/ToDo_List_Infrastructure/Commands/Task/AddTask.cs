using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;

namespace ToDo_List_Infrastructure.Commands.Task
{
    public class AddTask
    {
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public DateTime EndDate { get; protected set; }
    }
}
