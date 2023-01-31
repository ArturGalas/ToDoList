using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List_Core.Models;
using ToDo_List_Infrastructure.DTO;

namespace ToDo_List_Infrastructure.Services
{
    public interface IJwtHandler
    {
        JWTDTO CreateToken(Guid userId, Role role);
    }
}
