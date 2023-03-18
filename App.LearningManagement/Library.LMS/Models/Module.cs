
using System.Reflection;

namespace Library.LMS.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<ContentItem> Content { get; set; }

        public Module() { 
            Content= new List<ContentItem>();
        }

        public override string ToString()
        {
            return $"{Id}. {Name} - {Description}";
        }
    }
}
