namespace Problems3to5
{

    using System;
    using System.Linq;

    class Startup
    {
        
        public static Student[] FirstLastStudents(Student[] students)
        {
            var result = students
                            .Where(str => string.Compare(str.FirstName, str.LastName) < 0)
                            .ToArray();
            return result;
        }
         public static void printResult (Student[] students)
        {
            foreach (var item in students)
            {
                Console.WriteLine(string.Format("First Name: {0} \t Last Name: {1}", item.FirstName, item.LastName));
            }
            Console.WriteLine(new string('*', 50));
            Console.WriteLine();
        }

        static void Main()
        {
            var students = new[]
            {
                new Student{ FirstName = "Pesho", LastName = "Ivanov", Age = 18},
                new Student{ FirstName = "Gosho", LastName = "Ivanov", Age = 23},
                new Student{ FirstName = "Atanas", LastName = "Georgiev", Age = 19},
                new Student{ FirstName = "Stamat", LastName = "Petrov", Age = 20 },
                new Student{ FirstName = "Margarit", LastName = "Trandaforov", Age = 25 },
                new Student{ FirstName = "Izrod", LastName = "Urodski", Age = 28 }
            };


            //Problem 3. First before last
            //Write a method that from a given array of students finds all students
            //whose first name is before its last name alphabetically.
            //Use LINQ query operators.

            var studentsAlphaFirstLast = FirstLastStudents(students);
            Console.WriteLine("Students in the list whose first name is before their last name are:");
            printResult(studentsAlphaFirstLast);
     
            //Problem 4.Age range
            //Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
           var students18to24 = students
                .Where(st => st.Age >= 18 && st.Age <= 24)               
                .ToArray();

            Console.WriteLine("Students in the list who are between 18 and 24 years old are:");
            printResult(students18to24);

            //Problem 5.Order students
            //Using the extension methods OrderBy() and ThenBy() with lambda expressions
            //sort the students by first name and last name in descending order.
           var lambdaOrdered = students
                                    .OrderByDescending(st => st.FirstName)
                                    .ThenByDescending(st => st.LastName)
                                    .ToArray();
            Console.WriteLine("Students ordered by First then Last name, descending (lambda):");
            printResult(lambdaOrdered);

            //Rewrite the same with LINQ.
            var linqOrdered = from item in students
                              orderby item.FirstName descending, item.LastName descending
                              select item;

            var l1 = linqOrdered.ToArray();
            printResult(l1);

        }
    }
}
