namespace Problem17
{
    using System;
    using System.Linq;

    class Startup
    {
        static void Main(string[] args)
        {
            string[] arr =
            {
                "Lorem",
                "ipsum",
                "dolor",
                "sit",
                "amet",
                "consectetur",
                "adipisicinga",
                "elit"
            };

            var longestString =
                 (from strs in arr
                 orderby strs.Length descending
                 select strs).First();

            Console.WriteLine(longestString);

            // same can be accomplished using
            //var longestString = arr.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
            

        }
    }
}
