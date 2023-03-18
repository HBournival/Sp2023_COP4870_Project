using App.LearningManagement.Helpers;
using Library.LMS.Models;
using Library.LMS.Services;
using System;


namespace MyLMS
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var sService = new StudentService();
            var cService = new CourseService();
            var aService = new AssignmentService();
            var studentHelper = new StudentHelper(sService, cService);
            var courseHelper = new CourseHelper(sService, cService, aService);
            var assignmentHelper = new AssignmentHelper(sService, aService);

            bool cont = true;
            
            while(cont)
            {
                Console.WriteLine("\nChoose an Action:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Maintain People");
                Console.WriteLine("2. Maintain Courses");

                var input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if (result == 0) { cont = false; }

                    else if(result== 1) 
                    {
                        ShowStudentMenu(studentHelper);
                    }

                    else if(result == 2)
                    {
                        ShowCourseMenu(courseHelper);
                    }

                }
            }
            
        }

        static void ShowStudentMenu(StudentHelper studentHelper)
        {
            Console.WriteLine("\nChoose an Action:");
            Console.WriteLine("1. Add a New Person");
            Console.WriteLine("2. List All People");
            Console.WriteLine("3. Search for a Person");
            Console.WriteLine("4. Update a Person's Record");
            Console.WriteLine("5. Search for a Student's Courses");

            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {


                if (result == 1)
                {
                    studentHelper.CreateStudentRecord();
                }

                else if (result == 2)
                {
                    studentHelper.ListStudents(1);
                }

                else if (result == 3)
                {
                    studentHelper.SearchStudents();
                }
                else if (result == 4)
                {
                    studentHelper.UpdateStudentRecord();
                }
                else if (result == 5)
                {
                    studentHelper.ListStudents(0);
                }
            }


        }

        static void ShowCourseMenu(CourseHelper courseHelper)
        {
            Console.WriteLine("1. Add a New Course");
            Console.WriteLine("2. Update a Course");
            Console.WriteLine("3. List All Courses");
            Console.WriteLine("4. Search for a Course");
            Console.WriteLine("5. Add a Student to a Course");
            Console.WriteLine("6. Remove a Student from a Course");
            Console.WriteLine("7. Add an Assignment to a Course");
            Console.WriteLine("8. Update an Assignment");
            Console.WriteLine("9. Remove an Assignment from a Course");
            Console.WriteLine("10. List a Courses Roster");
            Console.WriteLine("11. List a Course's Assignments");
            Console.WriteLine("12. Create a New Module For a Course");
            Console.WriteLine("13. List a Course's Modules");
            Console.WriteLine("14. Update a Course's Module");
            Console.WriteLine("15. Remove a Course's Module");

            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                if (result == 1)
                {
                    courseHelper.CreateCourseRecord();
                }

                else if (result == 3)
                {
                    courseHelper.ListCourses();
                }
                else if (result == 2)
                {
                    courseHelper.UpdateCourseRecord(1);
                }
                else if (result == 4)
                {
                    courseHelper.SearchCourses();
                }
                else if (result == 5)
                {
                    courseHelper.UpdateCourseRecord(2);
                }
                else if (result == 6)
                {
                    courseHelper.UpdateCourseRecord(4);
                }
                else if (result == 7)
                {
                    courseHelper.UpdateCourseRecord(3);
                }
                else if (result == 8)
                {
                    courseHelper.UpdateCourseRecord(6);
                }
                else if (result == 9)
                {
                    courseHelper.UpdateCourseRecord(5);
                }
                else if (result == 10)
                {
                    courseHelper.ListCourseRoster();
                }
                else if (result == 11)
                {
                    courseHelper.ListCourseAssignments();
                }
                else if (result == 12)
                {
                    courseHelper.UpdateCourseRecord(7);
                }

                else if(result == 13)
                {
                    courseHelper.ListCourseModules();
                }

                else if(result == 14)
                {
                    courseHelper.UpdateCourseRecord(8);
                }
                else if(result == 15)
                {
                    courseHelper.UpdateCourseRecord(9);
                }
            }

        }
    }
}


    
  
