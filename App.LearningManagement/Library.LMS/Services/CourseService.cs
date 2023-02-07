using Library.LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Services
{
    public class CourseService
    {
        public List<Course> cList = new List<Course>();

        public void Add(Course course)
        {
            cList.Add(course);
        }

    }
}
