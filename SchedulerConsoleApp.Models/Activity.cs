using ActivityManagerConsoleApp.Utility;

namespace ActivityManagerConsoleApp.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string Category { get; set; }
        public Status Status { get; set; }

    }
}
