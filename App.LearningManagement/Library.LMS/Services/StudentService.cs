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
        private List<Student> sList = new List<Student>();

        public void Add(Student person)
        {
            sList.Add(person);
        }

        public List<Student> Students 
        { 
            get { return sList; } 
        }

        public IEnumerable<Student> Search(string query)
        {
            return sList.Where(s => s.Name.ToUpper().Contains(query.ToUpper()));
        }
    }
}
