﻿using App.LearningManagement.Helpers;
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
            var studentHelper = new StudentHelper(sService);
            var courseHelper = new CourseHelper(sService);

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
                Console.WriteLine("7. Update a Course");
                Console.WriteLine("8. Search for a Course");
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
                    else if(result == 7)
                    {
                        courseHelper.UpdateCourseRecord();
                    }
                    else if(result == 8)
                    {
                        courseHelper.SearchCourses();
                    }
                }
            }
            
        }
    }
}


    
  
