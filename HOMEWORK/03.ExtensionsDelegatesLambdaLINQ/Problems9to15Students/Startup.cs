namespace Problems9to15
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        //Problem 9 Create some sample students and add them to a list
        public static Student studentOne = new Student(
            "Gosho", "Petrov", "9958051234", "+359888666777", "goshoTypoto@baliga.com",
            new List<int>{
                    (int)MarksToChoose.Poor,
                    (int)MarksToChoose.Average,
                    (int)MarksToChoose.Poor,
                    (int)MarksToChoose.Poor,
                    (int)MarksToChoose.Average
            }
            , 2);

            public static Student studentTwo = new Student(
                "Pesho", "Goshov", "0101061234", "0888777555", "peshoTypoto@abv.bg",
                new List<int>{
                    (int)MarksToChoose.Excelent,
                    (int)MarksToChoose.Good,
                    (int)MarksToChoose.Excelent,
                    (int)MarksToChoose.Very_Good,
                    (int)MarksToChoose.Average
                }
                , 1);

            public static Student studentThree = new Student(
                "Stamat", "Peshev", "0103061234", "029711456", "stamatTypoto@abv.bg",
                new List<int>{
                    (int)MarksToChoose.Excelent,
                    (int)MarksToChoose.Good,
                    (int)MarksToChoose.Poor,
                    (int)MarksToChoose.Poor
                }
                , 2);

            public static Student studentFour = new Student(
                "Atanas", "Stamatov", "1603061209", "029732121", "naskoUmnoto@idioti.bg",
                new List<int>{
                    (int)MarksToChoose.Excelent,
                    (int)MarksToChoose.Good,
                    (int)MarksToChoose.Excelent,
                    (int)MarksToChoose.Very_Good,
                    (int)MarksToChoose.Poor,
                    (int)MarksToChoose.Poor
                }
                , 3);

            public static Student studentFive = new Student(
                "Mariika", "Ivanova", "1603061209", "023452121", "mimiObshtata@gmail.com",
                new List<int>{
                    (int)MarksToChoose.Good,
                    (int)MarksToChoose.Very_Good,
                    (int)MarksToChoose.Poor,
                    (int)MarksToChoose.Poor
                }
                , 2);

            public static List<Student> sampleStudentsList = new List<Student> { studentOne, studentTwo, studentThree, studentFour, studentFive};

        static void Main()
        {           
            //Problem 9     Select only the students that are from group number 2
            //              Use LINQ query.Order the students by FirstName.
           var studentsG2ByFirstNameLINQ =
               from student in sampleStudentsList
               where student.GroupNumber == 2
               orderby student.FirstName
               select student;

            Console.WriteLine("Students from Group 2 ordered by First Name using LINQ:" + Environment.NewLine);
            foreach (var student in studentsG2ByFirstNameLINQ)
            {
                Console.WriteLine(student);
                Console.WriteLine();
            }
            Console.WriteLine(new string('*', 40));

            //Problem 10 Implement the previous using the same query expressed with extension methods.
            var studentsG2ByFirstNameExtension = sampleStudentsList.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName);

            Console.WriteLine("Students from Group 2 ordered by First Name using extension methods:" + Environment.NewLine);
            foreach (var student in studentsG2ByFirstNameExtension)
            {
                Console.WriteLine(student);
                Console.WriteLine();
            }
            Console.WriteLine(new string('*', 40));

            //Problem 11    Extract all students that have email in abv.bg.
            //              Use string methods and LINQ.

            var studentsWithAbvEmail =
                from student in sampleStudentsList
                where student.Email.Contains("@abv.bg")                
                select student;
                
            Console.WriteLine("Students who have abv.bg e-mails using string methods and LINQ:" + Environment.NewLine);
            foreach (var student in studentsWithAbvEmail)
            {
                Console.WriteLine(student);
                Console.WriteLine();
            }
            Console.WriteLine(new string('*', 40));

            //Problem 12    Extract all students with phones in Sofia.
            //              Use LINQ.

            var studentsWithPhonesFromSofia =
                from student in sampleStudentsList
                where (student.PhoneNumber.StartsWith("+3592") || student.PhoneNumber.StartsWith("02"))
                select student;

            Console.WriteLine("Students who have phones in Sofia:" + Environment.NewLine);
            foreach (var student in studentsWithPhonesFromSofia)
            {
                Console.WriteLine(student);                
                Console.WriteLine();
            }
            Console.WriteLine(new string('*', 40));

            //Problem 13    Select all students that have at least one mark Excellent (6) into a new anonymous class
            //              that has properties – FullName and Marks. Use LINQ.

            var studentsWithExcelent =
                from student in sampleStudentsList
                where student.Marks.Contains((int)MarksToChoose.Excelent)
                select new
                {
                    FullName = student.FirstName + " " + student.LastName,
                    Marks = student.Marks
                };
            Console.WriteLine("Students with at least one excellent mark, each in new anonymous class with " +
                              "properties Fullname and Marks:\n");

            foreach (var student in studentsWithExcelent)
            {
                Console.WriteLine("Full name: {0}", student.FullName);
                Console.WriteLine("Marks: {0}", string.Join(", ", student.Marks));
                Console.WriteLine();
            }
            Console.WriteLine(new string('*', 40));

            //Problem 14    Write down a similar program that extracts the students with exactly two marks "2"
            //              Use extension methods.

            var studentsWithTwoTwos = sampleStudentsList
                .Where(x => x.Marks.FindAll(y => y == 2).Count() == 2)
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                    Marks = x.Marks
                });

            Console.WriteLine("Students with exactly two marks '2', each in new anonymous class with " +
                              "properties Fullname and Marks:\n");

            foreach (var student in studentsWithTwoTwos)
            {
                Console.WriteLine("Full name: {0}", student.FullName);
                Console.WriteLine("Marks: {0}", string.Join(", ", student.Marks));
                Console.WriteLine();
            }
            Console.WriteLine(new string('*', 40));

            //Problem 15    Extract all Marks of the students that enrolled in 2006.
            //              (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).

            var marksOfStudentsEnrolled2006 =
                from student in sampleStudentsList
                where student.FacultyNumber.Substring(4, 2) == "06"
                select student.Marks;

            Console.WriteLine("Marks of the students that enrolled in 2006:" + Environment.NewLine);
            foreach (var mark in marksOfStudentsEnrolled2006)
            {
                Console.WriteLine(string.Join(", ",mark));
                Console.WriteLine();
            }
            Console.WriteLine(new string('*', 40));
        }
    }
}
