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

        public void CreateAssignment(Assignment? selectAss = null)
        {
            Console.WriteLine("What is The Name of The Assignment?");
            var name = Console.ReadLine();
            Console.WriteLine("What is The Description of The Assignment?");
            var script = Console.ReadLine();
            Console.WriteLine("How many Points are Available on This Assignment?");
            var points = Console.ReadLine();

            selectAss = new Assignment();

            selectAss.Name = name ?? string.Empty;
            selectAss.Description = script ?? string.Empty;
            selectAss.tPoints = int.Parse(points ?? "0");

            aService.Add(selectAss);
        }
        public void ListAssignments()
        {
            aService.Assignments.ForEach(Console.WriteLine);
        }
    }
}
