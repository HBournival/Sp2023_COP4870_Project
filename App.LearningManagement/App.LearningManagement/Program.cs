using App.LearningManagement.Helpers;
using Library.LMS.Models;
using System;


namespace MyLMS
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var studentHelper = new StudentHelper();
            var courseHelper = new CourseHelper();

            bool cont = true;
            
            while(cont)
            {

                Console.WriteLine("\nChoose an Action:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Add a Student Enrollment");
                Console.WriteLine("2. List All Enrolled Studnets");
                Console.WriteLine("3. Search for a Student");
                Console.WriteLine("4. Add a New Course");
                Console.WriteLine("5. Update a Student Enrollment");
                Console.WriteLine("6. List All Courses");
                var input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if (result == 0) { cont = false; }

                    else if (result == 1)
                    {
                        studentHelper.CreateStudentRecord();
                    }

                    else if(result == 2)
                    {
                        studentHelper.ListStudents();
                    }

                    else if(result == 3)
                    {
                        studentHelper.SearchStudents();
                    }
                    else if(result == 4)
                    {
                        courseHelper.CreateCourseRecord();
                    }
                    else if(result == 5)
                    {
                        studentHelper.UpdateStudentRecord();
                    }
                    else if(result == 6)
                    {
                        courseHelper.ListCourses();
                    }

                }
            }
            
        }
    }
}


    
  
