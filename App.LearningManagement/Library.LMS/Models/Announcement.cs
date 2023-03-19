using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    public class Announcement
    {
        private static int lastId = 0;
        public int Id { get; private set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public Announcement()
        {
            Id = ++lastId;
        }

        public override string ToString()
        {
            return $"{Id}. {Name} \n\n {Description}\n";
        }
    }
}
