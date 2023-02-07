using Library.LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Services
{
    public class StudentService
    {
        private List<Person> sList = new List<Person>();

        public void Add(Person person)
        {
            sList.Add(person);
        }

        public List<Person> Students 
        { 
            get { return sList; } 
        }

        public IEnumerable<Person> Search(string query)
        {
            return sList.Where(s => s.Name.ToUpper().Contains(query.ToUpper()));
        }
    }
}
