using Library.LMS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Services
{
    public class AssignmentService
    {
        private List<Assignment> aList = new List<Assignment>();

        public List<Assignment> Assignments
        { 
            get { return aList; } 
        }

        public void Add(Assignment assignment)
        {
            aList.Add(assignment);
        }
    }
}
