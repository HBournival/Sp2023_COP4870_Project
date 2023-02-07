
namespace Library.LMS.Models
{
    public class Assignment
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal tPoints { get; set; }
        public DateTime DueDate { get; set; }

        public override string ToString()
        {
            return $"[{Name}] {tPoints} - {Description}";
        }
    }
}
