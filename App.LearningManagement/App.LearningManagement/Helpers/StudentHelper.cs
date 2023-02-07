using Library.LMS.Models;
using Library.LMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.LearningManagement.Helpers
{
    internal class StudentHelper
    {

        private StudentService sService;
        private CourseService cService;

        public StudentHelper(StudentService srv, CourseService crv)
        {
            sService = srv;
            cService = crv;
        }
        public void CreateStudentRecord(Person? selectStu = null)
        {
            Console.WriteLine("What is the name of the student");
            var name = Console.ReadLine();

            Console.WriteLine("What is the id of the student");
            var id = Console.ReadLine();

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

            bool isCreate = false;

            if (selectStu == null)
            {
                isCreate = true;
                selectStu = new Person();
            }

            if(isCreate) { selectStu.Id = int.Parse(id ?? "0"); }
            selectStu.Name = name ?? string.Empty;
            selectStu.Classification = classEnum;

            if(isCreate)
            {
                sService.Add(selectStu);
            }
        }

        public void UpdateStudentRecord() 
        {
            Console.WriteLine("Select a Student to Update: ");
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

        public void ListStudents(int x)
        {
            sService.Students.ForEach(Console.WriteLine);

            if (x == 0)
            {
                Console.WriteLine("Select a Student:");
                var selectStr = Console.ReadLine();
                var selectInt = int.Parse(selectStr ?? "0");

                Console.WriteLine("Student's Courses: ");
                cService.Courses.Where(c => c.Roster.Any(s => s.Id == selectInt)).ToList().ForEach(Console.WriteLine);
            }
        }

        public void SearchStudents()
        {
            Console.WriteLine("Enter a Name You Wish to Search: ");
            var query = Console.ReadLine() ?? string.Empty;

            sService.Search(query).ToList().ForEach(Console.WriteLine);
        }
    }
}
