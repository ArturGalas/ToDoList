﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List_Infrastructure.Commands.User
{
    public class CreateTask
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime endDate { get; set; } 
    }
}
