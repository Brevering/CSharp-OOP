namespace Problems1to2
{
    using System;
    using System.Text;

    class Startup
    {
        static void Main()
        {
            var testSBSubstring = new StringBuilder();

            testSBSubstring.Append("I want to remove this. Show only this.");
            Console.WriteLine(testSBSubstring);
            Console.WriteLine("----------------------");
            StringBuilder testAfterSubstring = testSBSubstring.Substring(23, 15);
            Console.WriteLine(testAfterSubstring);
        }
    }
}
