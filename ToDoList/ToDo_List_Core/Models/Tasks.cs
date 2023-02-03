using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List_Core.Models
{
    #region TaskEnum
    public enum TaskState
    {
        Active,
        Done,
        Closed,
        Remove
    }
    #endregion
    public class Tasks : Entity
    {
        #region Properties
        public Guid UserID { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime UpdateDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public TaskState State { get; set; }
        #endregion
        #region Constructors
        public Tasks(Guid userid, string title, string description,DateTime enddate):base()
        {
            UserID = userid;
            Title = title;
            Description = description;
            EndDate = enddate;
            CreateDate = DateTime.UtcNow;
            UpdateDate = DateTime.UtcNow;           
        }
        #endregion
        #region Methods
        public void SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new Exception("Tytuł nie może być pusty");
            Title = title;
        }
        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description)) 
                throw new Exception("Opis nie może być pusty");
            Description= description;
        }
        public void SetEndDate(DateTime enddate)
        {
            if (enddate < DateTime.MinValue)
                throw new Exception("Błędna data");
            EndDate = enddate;
        }
        public void SetUpdateDate(DateTime enddate)
        {
            if (enddate < DateTime.MinValue)
                throw new Exception("Błędna data");
            EndDate = enddate;
        }
        #endregion
    }
}
