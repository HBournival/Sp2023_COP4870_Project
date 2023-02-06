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

            bool cont = true;
            
            while(cont)
            {

                Console.WriteLine("\nChoose an Action:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Add a Student Enrollment");
                Console.WriteLine("2. List All Enrolled Studnets");
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


                }
            }
            
        }
    }
}


    
  
