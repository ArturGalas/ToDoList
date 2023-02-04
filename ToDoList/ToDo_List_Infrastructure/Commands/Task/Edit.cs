namespace ToDo_List_Infrastructure.Commands.Task
{
    public class Edit
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
    }
}
