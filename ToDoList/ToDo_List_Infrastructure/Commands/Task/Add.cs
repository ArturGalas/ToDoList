using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;

namespace ToDo_List_Infrastructure.Commands.Task
{
    public class Add
    {
        [Required]
        public string Title { get; protected set; }
        [Required]
        public string Description { get; protected set; }
        [Required]
        public DateTime EndDate { get; protected set; }
    }
}
