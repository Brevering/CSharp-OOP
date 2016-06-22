using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6
{
    class Startup
    {
        static void Main()
        {
            var givenArray = new int[100];
            for (int i = 0; i < givenArray.Length; i++)
            {
                givenArray[i] += i;
            }

            var lambdaResult = givenArray.Where(x => x % 3 == 0 && x % 7 == 0).ToArray();
            Console.WriteLine("Numbers, divisible by 3 and 7 (using lambda):\n{0}", string.Join(", ", lambdaResult));
            Console.WriteLine(new string('*', 40));

            var linqResult = from number in givenArray
                             where number % 3 == 0 && number % 7 == 0
                             select number;
            Console.WriteLine("Numbers, divisible by 3 and 7 (using LINQ):\n{0}", string.Join(", ", lambdaResult));
        }
    }
}
