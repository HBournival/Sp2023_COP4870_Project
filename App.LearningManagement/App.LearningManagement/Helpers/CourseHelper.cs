using Library.LMS.Models;
using Library.LMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.LearningManagement.Helpers
{
    public class CourseHelper
    {
        private CourseService cService = new CourseService();

        public void CreateCourseRecord()
        {
            Console.WriteLine("What is the Course Code?");
            var code = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the Name of the Course?");
            var name = Console.ReadLine() ?? string.Empty;  
            Console.WriteLine("What is the Description of the Course?");
            var description = Console.ReadLine() ?? string.Empty;

            var course = new Course
            {
                Code = code,
                Name = name,
                Description = description
            };

            cService.Add(course);

        }

        public void ListCourses()
        {
            cService.Courses.ForEach(Console.WriteLine);
        }
    }
}
