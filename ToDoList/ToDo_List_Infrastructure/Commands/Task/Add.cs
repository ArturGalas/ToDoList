using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;

namespace ToDo_List_Infrastructure.Commands.Task
{
    public class Add
    {
        [Required(ErrorMessage ="Tytuł nie może być pusty")]
        [DisplayName("Tytuł")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Opis nie może być pusty")]
        [DisplayName("Opis")]
        public string Description { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
