namespace Problem7
{
    using System;

    class TimerStartup
    {
        public static void TestMethodOne ()
        {
            Console.WriteLine("This is test method One");
        }

        public static void TestMethodTwo()
        {
            Console.WriteLine("This is test method Two");
        }



        static void Main()
        {
            Timer testTimer = new Timer(2, 3);

            //adding TestMethodOne to delegate
            testTimer.PassedMethods += TestMethodOne;
            Console.WriteLine("The method(s) passed will be executed {0} times every {1} seconds", testTimer.Repetitions, testTimer.TimeInterval);
            testTimer.ExecuteMethods();

            //adding TestMethodTwo to delegate
            testTimer.PassedMethods += TestMethodTwo;
            Console.WriteLine("The method(s) passed will be executed {0} times every {1} seconds", testTimer.Repetitions, testTimer.TimeInterval);
            testTimer.ExecuteMethods();
        }
    }
}
