using Library.LMS.Models;
using Library.LMS.Services;
using MyLMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Library.LMS.Models.Student;

namespace App.LearningManagement.Helpers
{
    internal class StudentHelper
    {

        private StudentService sService;
        private CourseService cService;
        private ListNavigator<Person> studentNav;

        public StudentHelper(StudentService srv, CourseService crv)
        {
            sService = srv;
            cService = crv;

            studentNav = new ListNavigator<Person>(sService.Students);
        }
        public void CreateStudentRecord(Person? selectStu = null)
        {
            bool isCreate = false;

            if (selectStu == null)
            {
                isCreate = true;

                Console.WriteLine("What type of Person would you like to Add?");
                Console.WriteLine("(S)tudent");
                Console.WriteLine("(T)eaching Assistant");
                Console.WriteLine("(I)nstructor");
                var choice = Console.ReadLine() ?? string.Empty;
                
                if(string.IsNullOrEmpty(choice))
                {
                    return;
                }
                if(choice.Equals("S", StringComparison.InvariantCultureIgnoreCase))
                {
                    selectStu = new Student();
                }
                else if(choice.Equals("T", StringComparison.InvariantCultureIgnoreCase))
                {
                    selectStu = new TeachingAssistant();
                }
                else if(choice.Equals("I", StringComparison.InvariantCultureIgnoreCase))
                {
                    selectStu = new Instructor();
                }
                
            }

            
            Console.WriteLine("What is the name of the student");
            var name = Console.ReadLine();

            Console.WriteLine("What is the id of the student");
            var id = Console.ReadLine();

            if(selectStu is Student)
            {
                Console.WriteLine("What is the classification of the student[(F)reshman, S(O)phomore, (J)unior, (S)enior]");
                var classification = Console.ReadLine() ?? string.Empty;

                PersonClassification classEnum = PersonClassification.Freshman;

                if (classification.Equals("O", StringComparison.InvariantCultureIgnoreCase))
                {
                    classEnum = PersonClassification.Sophomore;
                }
                else if (classification.Equals("J", StringComparison.InvariantCultureIgnoreCase))
                {
                    classEnum = PersonClassification.Junior;
                }
                else if (classification.Equals("S", StringComparison.InvariantCultureIgnoreCase))
                {
                    classEnum = PersonClassification.Senior;
                }

                var studentRec = selectStu as Student;

                if (studentRec != null)
                {
                    studentRec.Classification = classEnum;

                    studentRec.Id = int.Parse(id ?? "0");
                    studentRec.Name = name ?? string.Empty;


                    if (isCreate)
                    {
                        sService.Add(selectStu);
                    }
                }
            }


            else if(selectStu is TeachingAssistant)
            {
                selectStu.Id = int.Parse(id ?? "0");
                selectStu.Name = name ?? string.Empty;


                if (isCreate)
                {
                    sService.Add(selectStu);
                }
            }

            else if(selectStu is Instructor) 
            {
                selectStu.Id = int.Parse(id ?? "0");
                selectStu.Name = name ?? string.Empty;


                if (isCreate)
                {
                    sService.Add(selectStu);
                }
            }

            

           

            
        }

        public void UpdateStudentRecord() 
        {
            Console.WriteLine("Select a Person to Update: ");
            ListStudents(1);

            var selectStr = Console.ReadLine();

            if (int.TryParse(selectStr, out int selectInt))
            {
                var selectStu = sService.Students.FirstOrDefault(s => s.Id == selectInt);
                if(selectStu != null)
                {
                    CreateStudentRecord(selectStu);
                }
            }
        }

        private void NavigateStudents(int x)
        {
            bool keepPaging = true;
            while(keepPaging)
            {
                foreach (var pair in studentNav.GetCurrentPage())
                {
                    Console.WriteLine($"{pair.Key}. {pair.Value}");
                }

                if (studentNav.HasPreviousPage)
                {
                    Console.WriteLine("P. Previous Page");
                }
                if (studentNav.HasNextPage)
                {
                    Console.WriteLine("N. Next Page");
                }


                Console.WriteLine("Make a Selection('X' To Exit):");
                var selectStr = Console.ReadLine();

                
                if(selectStr.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                {
                    studentNav.GoBackward();
                }
                else if (selectStr.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                {
                   studentNav.GoForward();  
                }
                else if(selectStr.Equals("X", StringComparison.InvariantCultureIgnoreCase))
                {
                    keepPaging = false;
                }

                else
                {
                    if (x == 0)
                    {
                        var selectInt = int.Parse(selectStr ?? "0");

                        Console.WriteLine("Student's Courses: ");
                        cService.Courses.Where(c => c.Roster.Any(s => s.Id == selectInt)).ToList().ForEach(Console.WriteLine);
                        keepPaging = false;
                    }
                }
            }
            
        }
        public void ListStudents(int x)
        {
           NavigateStudents(x);
        }

        public void SearchStudents()
        {
            Console.WriteLine("Enter a Name You Wish to Search: ");
            var query = Console.ReadLine() ?? string.Empty;

            sService.Search(query).ToList().ForEach(Console.WriteLine);
        }
    }
}
