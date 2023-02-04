using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List_Core.Models
{
    #region UserEnum
    public enum Role
    {
        Admin,
        User,
        SuperAdmin
    }
    public enum UserState
    {
        Active,
        Remove
    }
    #endregion
    public class User : Entity
    {
        #region Properties

        private ISet<Tasks> _tasks = new HashSet<Tasks>();
        public string email { get; protected set; }
        public string password { get; protected set; }
        public string name { get; protected set; }
        public UserState state { get; protected set; }
        public Role role { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public IEnumerable<Tasks> tasks => _tasks.Where(t=>t.State == TaskState.Active);
        #endregion
        #region Constructors
        protected User()
        {
        }

        public User(string email, string password, string name, Role role):base()
        {
            this.email = email;
            this.password = password;
            this.name = name;
            this.role = role;
            CreatedAt= DateTime.UtcNow;
            state = UserState.Active;
        }
        #endregion
        #region Methods
        public void AddTask(Tasks newTask)
        {
            _tasks.Add(newTask);
        }
        public void RemoveUser()
        {
            state= UserState.Remove;
        }
        public void UpdateUser(string? name,string? email)
        {
            if(name == null)           
                this.name = name;
            if (email == null)
                this.email = email;
        }
        #endregion
    }
}

