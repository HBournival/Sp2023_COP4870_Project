
namespace Library.LMS.Models
{
    public class Course
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CreditHours { get; set; }
        public List<Person> Roster { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Module> Modules { get; set; }
        public List<Announcement> Announcements { get; set; }

        public Course() { 
            Code = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            CreditHours = string.Empty;
            Roster = new List<Person>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
            Announcements = new List<Announcement>();
        }

        public override string ToString()
        {
            return $"{Code} - {Name}\n";
        }
    }
}
