
namespace Library.LMS.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal tPoints { get; set; }
        public DateTime DueDate { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {DueDate}";
        }
    }
}
