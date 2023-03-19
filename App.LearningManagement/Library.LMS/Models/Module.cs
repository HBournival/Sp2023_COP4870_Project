
using System.Reflection;

namespace Library.LMS.Models
{

    public class Module
    {
        private static int lastId = 0;
        public int Id { get; private set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<ContentItem> Content { get; set; }

        public Module() { 
            Content= new List<ContentItem>();
            Id = ++lastId;
        }

        public override string ToString()
        {
            return $"{Id}. {Name} - {Description}";
        }
    }
}
