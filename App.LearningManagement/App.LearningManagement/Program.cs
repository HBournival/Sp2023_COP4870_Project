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

            Console.WriteLine("Choose an Action:");
            Console.WriteLine("1. Add a Student Enrollment");
            Console.WriteLine("2. Exit");
            var input = Console.ReadLine();
            if(int.TryParse(input, out int result))
            {
                while (result != 2)
                {
                    if (result == 1)
                    {
                        studentHelper.CreateStudentRecord();
                    }
                    input= Console.ReadLine();
                    int.TryParse(input, out result);
                }
            }
            
        }
    }
}


    
  
