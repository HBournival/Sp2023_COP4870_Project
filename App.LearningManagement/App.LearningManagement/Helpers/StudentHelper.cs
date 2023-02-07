using Library.LMS.Models;
using Library.LMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.LearningManagement.Helpers
{
    internal class StudentHelper
    {

        private StudentService sService = new StudentService();
        public void CreateStudentRecord()
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

            var student = new Person
            {
                Id = int.Parse(id ?? "0"),
                Name = name ?? string.Empty,
                Classification = classEnum
            };

            sService.Add(student);
        }

        public void ListStudents()
        {
            sService.Students.ForEach(Console.WriteLine);
        }

        public void SearchStudents()
        {
            Console.WriteLine("Enter a Name You Wish to Search: ");
            var query = Console.ReadLine() ?? string.Empty;

            sService.Search(query).ToList().ForEach(Console.WriteLine); 
        }
    }
}
