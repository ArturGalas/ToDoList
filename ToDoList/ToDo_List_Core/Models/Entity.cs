using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List_Core.Models
{
    public abstract  class Entity
    {
        public Guid id { get; }

        protected Entity()
        {
            id = Guid.NewGuid();
        }
    }
}
