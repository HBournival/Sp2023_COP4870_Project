using Library.LMS.Models;
using Library.LMS.Services;
using MyLMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.LearningManagement.Helpers
{
    public class CourseHelper
    {
        private CourseService cService;
        private StudentService sService;
        private AssignmentService aService;
        private ListNavigator<Course> courseNav;
        private List<String> codes;

        public CourseHelper(StudentService srv, CourseService crv, AssignmentService arv)
        {
            sService = srv;
            cService = crv;
            aService = arv;

            courseNav = new ListNavigator<Course>(cService.Courses, 2);
            codes = new List<String>();
        }
        public void CreateCourseRecord(Course? selectCor = null)
        {
            Console.WriteLine("What is the Course Code?");
            var code = Console.ReadLine() ?? string.Empty;

            if (codes.Contains(code))
            {
                bool badCode = true;
                while (badCode)
                {
                    Console.WriteLine("The Code You Entered Is Already Occupied by Another Course.\nPlease Enter a New Code");
                    code = Console.ReadLine() ?? string.Empty;

                    if (!codes.Contains(code))
                    {
                        badCode = false;
                    }
                }
            }

            Console.WriteLine("What is the Name of the Course?");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the Description of the Course?");
            var description = Console.ReadLine() ?? string.Empty;

            


            codes.Add(code);
            selectCor = new Course();


            selectCor.Code = code;
            selectCor.Name = name;
            selectCor.Description = description;



            cService.Add(selectCor);


        }

        public void UpdateCourseRecord(int x)
        {
            Console.WriteLine("Select a Course to Update(Enter the Course Code): ");
            ListCourses();
            Console.WriteLine("Confirm The Course Code");


            var selectStr = Console.ReadLine();

            var selectCor = cService.Courses.FirstOrDefault(s => s.Code.Equals(selectStr, StringComparison.InvariantCultureIgnoreCase));
            if (selectCor != null)
            {
                if (x == 1) { EditCourseData(selectCor); }

                else if (x == 2) { AddStudents(selectCor); }

                else if (x == 3) { AddAssignments(selectCor); }

                else if (x == 4) { RemoveStudent(selectCor); }

                else if (x == 5) { RemoveAssignment(selectCor); }

                else if (x == 6) { UpdateAssignment(selectCor); }

                else if (x == 7) { CreateModule(selectCor); }

                else if (x == 8) { UpdateModule(selectCor); }

                else if (x == 9) { RemoveModule(selectCor); }
            }
        }

        public void NavigateCourses()
        {
            bool keepPaging = true;
            while (keepPaging)
            {
                foreach (var pair in courseNav.GetCurrentPage())
                {
                    Console.WriteLine($"{pair.Key}. {pair.Value}");
                }

                if (courseNav.HasPreviousPage)
                {
                    Console.WriteLine("P. Previous Page");
                }
                if (courseNav.HasNextPage)
                {
                    Console.WriteLine("N. Next Page");
                }


                Console.WriteLine("Make a Selection('X' To Exit):");
                var selectStr = Console.ReadLine();


                if (selectStr.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                {
                    courseNav.GoBackward();
                }
                else if (selectStr.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                {
                    courseNav.GoForward();
                }
                else if (selectStr.Equals("X", StringComparison.InvariantCultureIgnoreCase))
                {
                    keepPaging = false;
                }
                else
                {
                    return;
                }

            }
        }

        public void ListCourses()
        {
            NavigateCourses();
        }

        public void SearchCourses()
        {
            Console.WriteLine("Enter a Course You Wish to Search: ");
            var query = Console.ReadLine() ?? string.Empty;

            cService.Search(query).ToList().ForEach(Console.WriteLine);
        }

        public void AddAssignments(Course selectCor)
        {
            bool adding = true;

            while (adding)
            {
                //Name
                Console.WriteLine("Assignment Name: ");
                var aName = Console.ReadLine() ?? string.Empty;
                //Description
                Console.WriteLine("Description: ");
                var aDescription = Console.ReadLine() ?? string.Empty;
                //TotalPoints
                Console.WriteLine("Total Points Available: ");
                var totalPoints = decimal.Parse(Console.ReadLine() ?? "100");
                //DueDate
                Console.WriteLine("When is the Due Date: ");
                var dueDate = DateTime.Parse(Console.ReadLine() ?? "01/01/1900");

                selectCor.Assignments.Add(new Assignment
                {
                    Name = aName,
                    Description = aDescription,
                    tPoints = totalPoints,
                    DueDate = dueDate
                });

                Console.WriteLine("Would You Like to Add Another Assignment? (Y/N)");
                var ans = Console.ReadLine() ?? "N";

                if (ans.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    adding = true;
                }

                else
                {
                    adding = false;
                }

            }

        }

        public void AddStudents(Course selectCor)
        {
            Console.WriteLine("Which Students Would you Like to Enroll in This Course?\n(Enter Their Student I.D.)\n('X' to Exit)");
            bool adding = true;
            while (adding)
            {
                sService.Students.Where(s => !selectCor.Roster.Any(s2 => s2.Id == s.Id)).ToList().ForEach(Console.WriteLine);
                var select = "X";
                if (sService.Students.Any(s => !selectCor.Roster.Any(s2 => s2.Id == s.Id)))
                {
                    select = Console.ReadLine() ?? string.Empty;
                }


                if (select.Equals("X", StringComparison.InvariantCultureIgnoreCase))
                {
                    adding = false;
                }

                else
                {
                    var selectId = int.Parse(select);
                    var selectStu = sService.Students.FirstOrDefault(s => s.Id == selectId);

                    if (selectStu != null)
                    {
                        selectCor.Roster.Add(selectStu);
                    }
                }
            }

        }

        public void EditCourseData(Course selectCor)
        {
            Console.WriteLine("What is the Course Code?");
            var code = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the Name of the Course?");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the Description of the Course?");
            var description = Console.ReadLine() ?? string.Empty;


            selectCor.Code = code;
            selectCor.Name = name;
            selectCor.Description = description;
        }

        public void ListCourseRoster()
        {
            Console.WriteLine("Which Course's Roster Do you want to view?(Enter the Course Code): ");
            ListCourses();

            var selectStr = Console.ReadLine();

            var selectCor = cService.Courses.FirstOrDefault(s => s.Code.Equals(selectStr, StringComparison.InvariantCultureIgnoreCase));

            if (selectCor != null)
            {
                selectCor.Roster.ForEach(Console.WriteLine);
            }

            Console.WriteLine("\n\n");
        }

        public void ListCourseAssignments()
        {

            Console.WriteLine("Which Course's Assignment List Do you want to view?(Enter the Course Code): ");
            ListCourses();

            var selectStr = Console.ReadLine();

            var selectCor = cService.Courses.FirstOrDefault(s => s.Code.Equals(selectStr, StringComparison.InvariantCultureIgnoreCase));

            if (selectCor != null)
            {
                selectCor.Assignments.ForEach(Console.WriteLine);
            }

            Console.WriteLine("\n\n");
        }

        public void RemoveStudent(Course selectCor)
        {
            Console.WriteLine("Which Students Would you Like to Remove in This Course?\n(Enter Their Student I.D.)\n('X' to Exit)");
            bool removing = true;
            while (removing)
            {
                selectCor.Roster.ForEach(Console.WriteLine);
                var select = "X";
                if (selectCor.Roster.Any())
                {
                    select = Console.ReadLine() ?? string.Empty;
                }
                else
                {
                    select = "X";
                }

                if (select.Equals("X", StringComparison.InvariantCultureIgnoreCase))
                {
                    removing = false;
                }

                else
                {
                    var selectId = int.Parse(select);
                    var selectStu = sService.Students.FirstOrDefault(s => s.Id == selectId);

                    if (selectStu != null)
                    {
                        selectCor.Roster.Remove(selectStu);
                    }
                }
            }
        }

        public void RemoveAssignment(Course selectCor)
        {
            bool removing = true;

            while (removing)
            {
                Console.WriteLine("Enter the Id of the assignment you want to Remove\n");
                selectCor.Assignments.ForEach(Console.WriteLine);

                var select = Console.ReadLine() ?? string.Empty;
                var selectInt = int.Parse(select);
                var selectAss = selectCor.Assignments.FirstOrDefault(a => a.Id == selectInt);
                if (selectAss != null)
                {
                    var index = selectCor.Assignments.IndexOf(selectAss);
                    selectCor.Assignments.RemoveAt(index);
                }


                Console.WriteLine("Would You Like to Add Remove another Assignment? (Y/N)");
                var ans = Console.ReadLine() ?? "N";

                if (ans.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    removing = true;
                }

                else
                {
                    removing = false;
                }

            }
        }

        public void UpdateAssignment(Course selectCor)
        {
            AssignmentHelper aHelp = new AssignmentHelper(sService, aService);

            Console.WriteLine("Enter the Id of the assignment you want to update\n");
            selectCor.Assignments.ForEach(Console.WriteLine);

            var select = Console.ReadLine() ?? string.Empty;
            var selectInt = int.Parse(select);
            var selectAss = selectCor.Assignments.FirstOrDefault(a => a.Id == selectInt);
            if (selectAss != null)
            {
                var index = selectCor.Assignments.IndexOf(selectAss);
                selectCor.Assignments.RemoveAt(index);



                selectCor.Assignments.Insert(index, aHelp.CreateAssignment());
            }
        }

        public void CreateModule(Course selectCor)
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Description");
            var description = Console.ReadLine();

            var module = new Module
            {
                Name = name,
                Description = description,
            };

            Console.WriteLine("Would you like to add content to this module?(Y/N)");
            var choice = Console.ReadLine() ?? "N";

            while (choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("What Type of content to you want to add?");
                Console.WriteLine("1. Assignment");
                Console.WriteLine("2. File");
                Console.WriteLine("3. Page");
                var cChoice = int.Parse(Console.ReadLine() ?? "0");

                switch (cChoice)
                {
                    case 1:
                        var newAssignmentContent = CreateAssignmentItem(selectCor);
                        if (newAssignmentContent != null)
                        {
                            module.Content.Add(newAssignmentContent);
                        }
                        break;

                    case 2:
                        var newFileContent = CreateFileItem(selectCor);
                        if (newFileContent != null)
                        {
                            module.Content.Add(newFileContent);
                        }
                        break;

                    case 3:
                        var newPageItem = CreatePageItem(selectCor);
                        if (newPageItem != null)
                        {
                            module.Content.Add(newPageItem);
                        }
                        break;

                    default:
                        break;
                }

                Console.WriteLine("Would you like to add more content?(Y/N");
                choice = Console.ReadLine() ?? "N";

            }

            if (module != null)
            {
                selectCor.Modules.Add(module);
            }

        }

        private AssignmentItem? CreateAssignmentItem(Course c)
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Description");
            var description = Console.ReadLine();

            Console.WriteLine("Which Assignment should be added?");
            c.Assignments.ForEach(Console.WriteLine);
            var choice = int.Parse(Console.ReadLine() ?? "-1");

            if (choice >= 0)
            {
                var assignment = c.Assignments.FirstOrDefault(a => a.Id == choice);
                return new AssignmentItem
                {
                    Assignment = assignment,
                    Name = name,
                    Description = description
                };
            }

            return null;
        }

        private FileItem? CreateFileItem(Course c)
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Description");
            var description = Console.ReadLine();

            Console.WriteLine("Enter a Path to the File");
            var filePath = Console.ReadLine();

            return new FileItem
            {
                Path = filePath,
                Name = name,
                Description = description
            };
        }

        private PageItem? CreatePageItem(Course c)
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Description");
            var description = Console.ReadLine();

            Console.WriteLine("Enter Page Content");
            var body = Console.ReadLine();

            return new PageItem
            {
                HtmlBody = body,
                Name = name,
                Description = description
            };
        }

        public void ListCourseModules()
        {
            Console.WriteLine("Which Course's Modules Do you want to view?(Enter the Course Code): ");
            ListCourses();

            var selectStr = Console.ReadLine();

            var selectCor = cService.Courses.FirstOrDefault(s => s.Code.Equals(selectStr, StringComparison.InvariantCultureIgnoreCase));

            if (selectCor != null)
            {
                selectCor.Modules.ForEach(Console.WriteLine);
            }

            Console.WriteLine("\n\n");
        }

        public void UpdateModule(Course selectCor)
        {
            Console.WriteLine("Enter the Id of the Module you want to update\n");
            selectCor.Modules.ForEach(Console.WriteLine);

            var select = Console.ReadLine() ?? string.Empty;
            var selectInt = int.Parse(select);
            var selectMod = selectCor.Modules.FirstOrDefault(m => m.Id == selectInt);

            if (selectMod == null)
            {
                Console.WriteLine("The Selected Module Does Not Exist");
                return;
            }



            Console.WriteLine("Would You Like to Update this Module's Description?(Y/N)");
            var choice = Console.ReadLine() ?? string.Empty;

            if(choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Name: ");
                selectMod.Name = Console.ReadLine();
                Console.WriteLine("Description");
                selectMod.Description = Console.ReadLine();
            }


            Console.WriteLine("Would you like to add content to this module?(Y/N)");
            choice = Console.ReadLine() ?? "N";

            while (choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("What Type of content to you want to add?");
                Console.WriteLine("1. Assignment");
                Console.WriteLine("2. File");
                Console.WriteLine("3. Page");
                var cChoice = int.Parse(Console.ReadLine() ?? "0");

                switch (cChoice)
                {
                    case 1:
                        var newAssignmentContent = CreateAssignmentItem(selectCor);
                        if (newAssignmentContent != null)
                        {
                            selectMod.Content.Add(newAssignmentContent);
                        }
                        break;

                    case 2:
                        var newFileContent = CreateFileItem(selectCor);
                        if (newFileContent != null)
                        {
                            selectMod.Content.Add(newFileContent);
                        }
                        break;

                    case 3:
                        var newPageItem = CreatePageItem(selectCor);
                        if (newPageItem != null)
                        {
                            selectMod.Content.Add(newPageItem);
                        }
                        break;

                    default:
                        break;
                }

                Console.WriteLine("Would you like to add more content?(Y/N");
                choice = Console.ReadLine() ?? "N";

            }




        }

        public void RemoveModule(Course selectCor)
        {
            Console.WriteLine("Which Modules Would you Like to Remove in This Course?\n(Enter The Module's I.D.)\n('X' to Exit)");
            bool removing = true;
            while (removing)
            {
                selectCor.Modules.ForEach(Console.WriteLine);
                var select = "X";
                if (selectCor.Modules.Any())
                {
                    select = Console.ReadLine() ?? string.Empty;
                }
                else
                {
                    select = "X";
                }

                if (select.Equals("X", StringComparison.InvariantCultureIgnoreCase))
                {
                    removing = false;
                }

                else
                {
                    var selectId = int.Parse(select);
                    var selectStu = selectCor.Modules.FirstOrDefault(s => s.Id == selectId);

                    if (selectStu != null)
                    {
                        selectCor.Modules.Remove(selectStu);
                    }
                }
            }

        }
    }
}
