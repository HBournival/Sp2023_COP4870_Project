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

        public void CreateCourseRecord(Course? selectCor = null)
        {
            Console.WriteLine("What is the Course Code?");
            var code = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the Name of the Course?");
            var name = Console.ReadLine() ?? string.Empty;  
            Console.WriteLine("What is the Description of the Course?");
            var description = Console.ReadLine() ?? string.Empty;

            bool isCreate = false;
            if(selectCor == null)
            {
                isCreate = true;
                selectCor = new Course();
            }

                selectCor.Code = code;
                selectCor.Name = name;
                selectCor.Description = description;

            if (isCreate)
            {
                cService.Add(selectCor);
            }

        }

        public void UpdateCourseRecord()
        {
            Console.WriteLine("Select a Course to Update(Enter the Course Code): ");
            ListCourses();

            var selectStr = Console.ReadLine();

                var selectCor = cService.Courses.FirstOrDefault(s => s.Code.Equals(selectStr, StringComparison.InvariantCultureIgnoreCase));
                if (selectCor != null)
                {
                    CreateCourseRecord(selectCor);
                }
        }

        public void ListCourses()
        {
            cService.Courses.ForEach(Console.WriteLine);
        }
    }
}
