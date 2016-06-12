namespace DefineClass
{
    using System;
    using System.Linq;

    public class GSMCallHistoryTest
    {
        //Create an instance of object GSM
        public static GSM testGSM = new GSM("3310", "Nokia", 157.33, "Gosho Pesho Atanas", new Battery("BL-5", 120, 9, BatteryType.NiMh), new Display(1.5, 8));

        //Price of call per minute
        private const double price = 0.37;

        //Loading some calls in call history of test GSM
        public static void TestPhone()
        {
            testGSM.AddCall((new DateTime(2016, 06, 01, 16, 53, 17)), "0888999888", 49);
            testGSM.AddCall((new DateTime(2016, 06, 02, 13, 14, 21)), "0888888777", 117);
            testGSM.AddCall((new DateTime(2016, 06, 03, 11, 53, 01)), "00443211566547", 73);
            testGSM.AddCall((new DateTime(2016, 06, 03, 19, 50, 11)), "0877568953", 235);
            testGSM.AddCall((new DateTime(2016, 06, 05, 02, 11, 33)), "0899564487", 19);

            testGSM.PrintCallHistory();    //Printing call history        

            //Printing total price of calls
            Console.WriteLine("Total price of all calls is {0:F2} BGN.", testGSM.CalculateTotalPrice(testGSM.CallHistory, price));

            //If there are calls in call history - remove the longest call and print price after removal
            if (testGSM.CallHistory.Count > 0 )
            {
                Call longestcall = testGSM.CallHistory.OrderByDescending(x => x.Duration).First();
                testGSM.DeleteCall(longestcall);
                Console.WriteLine("Total price after removing longest call is {0:F2} BGN.", testGSM.CalculateTotalPrice(testGSM.CallHistory, price));
            }

            testGSM.ClearHistory(); //Clearing call history

            testGSM.PrintCallHistory(); //Printing call history after clear
        }
    }
}
