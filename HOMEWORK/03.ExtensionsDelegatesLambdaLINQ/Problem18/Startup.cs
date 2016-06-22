namespace Problems18to19
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Problems9to15;

    class Startup
    {
        static void Main()
        {
            Problems9to15.Startup.sampleStudentsList.Add(new Student(
                "Zdravko", "Yakimov", "7811062534", "+359868954456",
                "jelezoto@abv.bg", new List<int> { (int)MarksToChoose.Good, (int)MarksToChoose.Very_Good, (int)MarksToChoose.Average }, 3));

            //Problem 18:   Create a program that extracts all students grouped by GroupNumber and then prints them to the console.
            //              Use LINQ.
            var studentsGrouped =
                from student in Problems9to15.Startup.sampleStudentsList
                group student by student.GroupNumber
                into groups
                orderby groups.Key
                select new
                {
                    Group = groups.Key,
                    Students = groups.ToList()
                };

            Console.WriteLine("Students grouped by group number using LINQ:" + Environment.NewLine);
            foreach (var groupOfStudents in studentsGrouped)
            {
                Console.WriteLine("Group: {0} Students:", groupOfStudents.Group);
                Console.WriteLine(new string('*', 40));
                Console.WriteLine(string.Join(Environment.NewLine + Environment.NewLine, groupOfStudents.Students));
                Console.WriteLine();
            }

            //Problem 19:   Rewrite the previous using extension methods.
            //              I intentionally skipped ordering the groups so a difference with the previous problem is visible.

            var studentsGrouped2 = Problems9to15.Startup.sampleStudentsList
                .GroupBy(x => x.GroupNumber,(groupNumber, students) => new { Group = groupNumber, Students = students });

            Console.WriteLine("Students grouped by group number using extension methods:" + Environment.NewLine);
            foreach (var group in studentsGrouped2)
            {
                Console.WriteLine("Group: {0} Students:", group.Group);
                Console.WriteLine(new string('*', 40));
                Console.WriteLine(string.Join(Environment.NewLine + Environment.NewLine, group.Students));
                Console.WriteLine();
            }
        }
    }
}
