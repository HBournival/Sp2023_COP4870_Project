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
                Console.WriteLine("1. Maintain Students");
                Console.WriteLine("2. Maintain Courses");

                
                
                
                
                /*Console.WriteLine("9. Create an Assignment");
                
                Console.WriteLine("11. List All Assignments");*/
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
                    
                    /*else if(result == 9)
                    {
                        assignmentHelper.CreateAssignment();
                    }
                    
                    else if(result == 11)
                    {
                        assignmentHelper.ListAssignments();
                    }*/
                }
            }
            
        }

        static void ShowStudentMenu(StudentHelper studentHelper)
        {
            Console.WriteLine("\nChoose an Action:");
            Console.WriteLine("1. Add a Student Enrollment");
            Console.WriteLine("2. List All Enrolled Studnets");
            Console.WriteLine("3. Search for a Student");
            Console.WriteLine("4. Update a Student Enrollment");
            Console.WriteLine("5. Search for Students Courses");

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
            Console.WriteLine("2. List All Courses");
            Console.WriteLine("3. Update a Course");
            Console.WriteLine("4. Search for a Course");
            Console.WriteLine("5. Show a Course's Roster");
            Console.WriteLine("6. List a Course's Assignments");

            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                if (result == 1)
                {
                    courseHelper.CreateCourseRecord();
                }

                else if (result == 2)
                {
                    courseHelper.ListCourses();
                }
                else if (result == 3)
                {
                    courseHelper.UpdateCourseRecord();
                }
                else if (result == 4)
                {
                    courseHelper.SearchCourses();
                }
                else if(result == 5)
                {
                    courseHelper.ListCourseRoster();
                }
                else if(result == 6)
                {
                    courseHelper.ListCourseAssignments();
                }
            }

        }
    }
}


    
  
