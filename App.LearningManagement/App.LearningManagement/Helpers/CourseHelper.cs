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

            
               

            
                selectCor = new Course();
            

                selectCor.Code = code;
                selectCor.Name = name;
                selectCor.Description = description;
                

            
                cService.Add(selectCor);
            

        }

        public void UpdateCourseRecord(int x)
        {
            Console.WriteLine("Select a Course to Update(Enter the Course Code): ");
            ListCourses();

            var selectStr = Console.ReadLine();

            var selectCor = cService.Courses.FirstOrDefault(s => s.Code.Equals(selectStr, StringComparison.InvariantCultureIgnoreCase));
            if (selectCor != null)
            {
                if(x == 1) { EditCourseData(selectCor); }

                else if(x == 2) { AddStudents(selectCor); }

                else if(x == 3) { AddAssignments(selectCor); }

                else if(x == 4) { RemoveStudent(selectCor); }

                else if (x == 5) { RemoveAssignment(selectCor); }
                
                else if( x == 6) { UpdateAssignment (selectCor); }
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

        public void AddAssignments(Course selectCor)
        {
            bool adding = true;

            while (adding)
            {
                Console.WriteLine("What is The Assignment's Id?");
                var Id = int.Parse(Console.ReadLine());
                //Name
                Console.WriteLine("Assignment Name: ");
                var aName = Console.ReadLine() ?? string.Empty;
                //Description
                Console.WriteLine("Description: ");
                var aDescription = Console.ReadLine() ?? string.Empty;
                //TotalPoints
                Console.WriteLine("Total Points Available: ");
                var totalPoints = decimal.Parse(Console.ReadLine() ?? "100");
                //DueDate
                Console.WriteLine("When is the Due Date: ");
                var dueDate = DateTime.Parse(Console.ReadLine() ?? "01/01/1900");

                selectCor.Assignments.Add(new Assignment
                {
                    Id = Id,
                    Name = aName,
                    Description = aDescription,
                    tPoints = totalPoints,
                    DueDate = dueDate
                });

                Console.WriteLine("Would You Like to Add Another Assignment? (Y/N)");
                var ans = Console.ReadLine() ?? "N";

                if (ans.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    adding = true;
                }

                else
                {
                    adding = false;
                }

            }

        }

        public void AddStudents(Course selectCor)
        {
            Console.WriteLine("Which Students Would you Like to Enroll in This Course?\n(Enter Their Student I.D.)\n('X' to Exit)");
            bool adding = true;
            while (adding)
            {
                sService.Students.Where(s => !selectCor.Roster.Any(s2 => s2.Id == s.Id)).ToList().ForEach(Console.WriteLine);
                var select = "X";
                if (sService.Students.Any(s => !selectCor.Roster.Any(s2 => s2.Id == s.Id)))
                {
                    select = Console.ReadLine() ?? string.Empty;
                }


                if (select.Equals("X", StringComparison.InvariantCultureIgnoreCase))
                {
                    adding = false;
                }

                else
                {
                    var selectId = int.Parse(select);
                    var selectStu = sService.Students.FirstOrDefault(s => s.Id == selectId);

                    if (selectStu != null)
                    {
                        selectCor.Roster.Add(selectStu);
                    }
                }
            }

        }

        public void EditCourseData(Course selectCor)
        {
            Console.WriteLine("What is the Course Code?");
            var code = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the Name of the Course?");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the Description of the Course?");
            var description = Console.ReadLine() ?? string.Empty;


            selectCor.Code = code;
            selectCor.Name = name;
            selectCor.Description = description;
        }

        public void ListCourseRoster()
        {
            Console.WriteLine("Which Course's Roster Do you want to view?(Enter the Course Code): ");
            ListCourses();

            var selectStr = Console.ReadLine();

            var selectCor = cService.Courses.FirstOrDefault(s => s.Code.Equals(selectStr, StringComparison.InvariantCultureIgnoreCase));

            if (selectCor != null)
            {
                selectCor.Roster.ForEach(Console.WriteLine);
            }
        }

        public void ListCourseAssignments()
        {

            Console.WriteLine("Which Course's Assignment List Do you want to view?(Enter the Course Code): ");
            ListCourses();

            var selectStr = Console.ReadLine();

            var selectCor = cService.Courses.FirstOrDefault(s => s.Code.Equals(selectStr, StringComparison.InvariantCultureIgnoreCase));

            if (selectCor != null)
            {
                selectCor.Assignments.ForEach(Console.WriteLine);
            }
        }

        public void RemoveStudent(Course selectCor)
        {
            Console.WriteLine("Which Students Would you Like to Remove in This Course?\n(Enter Their Student I.D.)\n('X' to Exit)");
            bool removing = true;
            while (removing)
            {
                selectCor.Roster.ForEach(Console.WriteLine);
                var select = "X";
                if (selectCor.Roster.Any())
                {
                    select = Console.ReadLine() ?? string.Empty;
                }
                else
                {
                    select = null;
                }

                if (select.Equals("X", StringComparison.InvariantCultureIgnoreCase))
                {
                    removing = false;
                }

                else
                {
                    var selectId = int.Parse(select);
                    var selectStu = sService.Students.FirstOrDefault(s => s.Id == selectId);

                    if (selectStu != null)
                    {
                        selectCor.Roster.Remove(selectStu);
                    }
                }
            }
        }

        public void RemoveAssignment(Course selectCor)
        {
            bool removing = true;

            while (removing)
            {
                Console.WriteLine("Enter the Id of the assignment you want to Remove\n");
                selectCor.Assignments.ForEach(Console.WriteLine);

                var select = Console.ReadLine() ?? string.Empty;
                var selectInt = int.Parse(select);
                var selectAss = selectCor.Assignments.FirstOrDefault(a => a.Id == selectInt);
                if (selectAss != null)
                {
                    var index = selectCor.Assignments.IndexOf(selectAss);
                    selectCor.Assignments.RemoveAt(index);
                }


                Console.WriteLine("Would You Like to Add Remove another Assignment? (Y/N)");
                var ans = Console.ReadLine() ?? "N";

                if (ans.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    removing = true;
                }

                else
                {
                    removing = false;
                }

            }
        }

        public void UpdateAssignment(Course selectCor)
        {
            AssignmentHelper aHelp = new AssignmentHelper(sService, aService);

            Console.WriteLine("Enter the Id of the assignment you want to update\n");
            selectCor.Assignments.ForEach(Console.WriteLine);

            var select = Console.ReadLine() ?? string.Empty;
            var selectInt = int.Parse(select);
            var selectAss = selectCor.Assignments.FirstOrDefault(a => a.Id == selectInt);
            if (selectAss != null)
            {
                var index = selectCor.Assignments.IndexOf(selectAss);
                selectCor.Assignments.RemoveAt(index);

                

                selectCor.Assignments.Insert(index, aHelp.CreateAssignment());
            }
        }
    }
}
