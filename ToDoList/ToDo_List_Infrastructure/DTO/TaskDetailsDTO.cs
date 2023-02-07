using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;

namespace ToDo_List_Infrastructure.DTO
{
    public class TaskDetailsDTO
    {
        public Guid Id { get; set; }
        [Range(0,400)]
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime EndDate { get; set; }
        public TaskState state { get; set; }
    }
}
