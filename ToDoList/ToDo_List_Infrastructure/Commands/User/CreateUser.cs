using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;

namespace ToDo_List_Infrastructure.Commands.User
{
    public class CreateUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
        [EmailAddress(ErrorMessage ="Proszę wpisać adres Email")]
        public string _Email { get; set; }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                if(new EmailAddressAttribute().IsValid(value))
                {
                    _Email = value;
                }
            }
        }
    }
}
