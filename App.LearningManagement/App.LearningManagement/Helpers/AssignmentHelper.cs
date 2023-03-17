using Library.LMS.Models;
using Library.LMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.LearningManagement.Helpers
{
    internal class AssignmentHelper
    {
        private StudentService sService;
        private AssignmentService aService;

        public AssignmentHelper(StudentService srv, AssignmentService aSrv)
        {
            sService = srv;
            aService = aSrv;
        }

        public Assignment CreateAssignment(Assignment? selectAss = null)
        {
            Console.WriteLine("What is The Assignment's Id?");
            var Id = int.Parse(Console.ReadLine());
            Console.WriteLine("What is The Name of The Assignment?");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is The Description of The Assignment?");
            var script = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("How many Points are Available on This Assignment?");
            var points = decimal.Parse(Console.ReadLine() ?? "100");
            Console.WriteLine("When is the Due Date?");
            var dDate = DateTime.Parse(Console.ReadLine() ?? "01/01/1900");

            selectAss = new Assignment();

            selectAss.Id = Id;
            selectAss.Name = name;
            selectAss.Description = script;
            selectAss.tPoints = points;
            selectAss.DueDate = dDate; 

//            aService.Add(selectAss);

            return selectAss;
        }
        public void ListAssignments()
        {
            aService.Assignments.ForEach(Console.WriteLine);
        }
    }
}
