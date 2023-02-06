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
        public List<Person> sList = new List<Person>();

        public void Add(Person person)
        {
            sList.Add(person);
        }
    }
}