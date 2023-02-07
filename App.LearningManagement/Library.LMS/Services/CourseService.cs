using Library.LMS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Services
{
    public class CourseService
    {
        private List<Course> cList = new List<Course>();

        public void Add(Course course)
        {
            cList.Add(course);
        }

        public List<Course> Courses 
        {
            get { return cList; }
        }

        public IEnumerable<Course> Search(string query)
        {
            return Courses.Where(s => s.Code.ToUpper().Contains(query.ToUpper())
                 || s.Name.ToUpper().Contains(query.ToUpper())
                 || s.Description.ToUpper().Contains(query.ToUpper()));
        }
    }
}
