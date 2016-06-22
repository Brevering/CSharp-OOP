namespace Problems1to2
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Startup
    {
        static void Main()
        {

            //Problem 1. Implement an extension method Substring(int index, int length) for the class StringBuilder
            //that returns new StringBuilder and has the same functionality as Substring in the class String.

            var testSBSubstring = new StringBuilder();

            testSBSubstring.Append("I want to remove this. Show only this.");
            Console.WriteLine(testSBSubstring);
            Console.WriteLine("----------------------");
            StringBuilder testAfterSubstring = testSBSubstring.Substring(23, 15);
            Console.WriteLine(testAfterSubstring);

            //Problem 2. IEnumerable extensions 
            //Implement a set of extension methods for IEnumerable<T> that implement
            //the following group functions: sum, product, min, max, average.
            //Testing of the various extensions for different types of collections and elements:

            IEnumerable<int> test = new List<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine(test.SumExtension());
            IEnumerable<double> test1 = new[] { 1.5, 2.5, 3.5, 4.5, 5.5 };

            Console.WriteLine(test1.SumExtension());
            Console.WriteLine(test1.ProductExtension());
            Console.WriteLine(test1.MinExtension());
            Console.WriteLine(test1.MaxExtension());
            Console.WriteLine(test1.AverageExtension());

            Console.WriteLine(MyExtensions.AverageExtension(test));
            Console.WriteLine(MyExtensions.ProductExtension(test1));
        }
    }
}
