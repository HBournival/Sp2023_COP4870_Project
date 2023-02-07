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
        private CourseService cService;
        private StudentService sService;
        private AssignmentService aService;

        public CourseHelper(StudentService srv, CourseService crv, AssignmentService arv)
        { 
            sService = srv;
            cService = crv;
            aService = arv;
        }
        public void CreateCourseRecord(Course? selectCor = null)
        {
            Console.WriteLine("What is the Course Code?");
            var code = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the Name of the Course?");
            var name = Console.ReadLine() ?? string.Empty;  
            Console.WriteLine("What is the Description of the Course?");
            var description = Console.ReadLine() ?? string.Empty;


            Console.WriteLine("Which Students Would you Like to Enroll in This Course?\n(Enter Their Student I.D.)\n('X' to Exit)");
            var roster = new List<Person>();
            bool adding = true;
            while (adding)  
            {
                sService.Students.Where(s => !roster.Any(s2 => s2.Id == s.Id)).ToList().ForEach(Console.WriteLine);
                var select = "X";
                if(sService.Students.Any(s => !roster.Any(s2 => s2.Id == s.Id)))
                {
                    select = Console.ReadLine() ?? string.Empty;
                }
                

                if(select.Equals("X", StringComparison.InvariantCultureIgnoreCase))
                {
                    adding = false;
                }

                else
                {
                    var selectId = int.Parse(select);
                    var selectStu = sService.Students.FirstOrDefault(s => s.Id == selectId);

                    if(selectStu != null)
                    {
                        roster.Add(selectStu);
                    }
                }
            }

            bool isCreate = false;
            if(selectCor == null)
            {
                isCreate = true;
                selectCor = new Course();
            }

                selectCor.Code = code;
                selectCor.Name = name;
                selectCor.Description = description;
                selectCor.Roster.AddRange(roster);

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

        public void SearchCourses()
        {
            Console.WriteLine("Enter a Course You Wish to Search: ");
            var query = Console.ReadLine() ?? string.Empty;

            cService.Search(query).ToList().ForEach(Console.WriteLine);
        }
    }
}
