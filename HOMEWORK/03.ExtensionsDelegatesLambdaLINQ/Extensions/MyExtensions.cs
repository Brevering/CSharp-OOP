namespace Problems1to2
{
    using System.Collections.Generic;
    using System.Text;
    using System;
    using System.Linq;
    public static class MyExtensions
    {
        //Problem 1. Implement an extension method Substring(int index, int length) for the class StringBuilder
        //that returns new StringBuilder and has the same functionality as Substring in the class String.

        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {            
            string appendable = sb.ToString()
                                    .Substring(index, length);
            sb.Clear();
            sb.Append(appendable);
            return sb;
        }

        //Problem 2. IEnumerable extensions 
        //Implement a set of extension methods for IEnumerable<T> that implement
        //the following group functions: sum, product, min, max, average.

        //Sum
        public static decimal SumExtension<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            var decCollection = collection.Select(x => Convert.ToDecimal(x));
            decimal result = 0;
            foreach (var item in decCollection)
            {
                result += item;
            }
            return result;
        }

        //Product
        public static decimal ProductExtension<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            var decCollection = collection.Select(x => Convert.ToDecimal(x));
            decimal result = 0;
            foreach (var item in decCollection)
            {
                result *= item;
            }
            return result;
        }

        //Min
        public static decimal MinExtension<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            var decCollection = collection.Select(x => Convert.ToDecimal(x));
            decimal result = decimal.MaxValue;
            foreach (var item in decCollection)
            {
                if (item < result)
                {
                    result = item;
                }
            }
            return result;
        }

        //Max
        public static decimal MaxExtension<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            var decCollection = collection.Select(x => Convert.ToDecimal(x));
            decimal result = decimal.MinValue;
            foreach (var item in decCollection)
            {
                if (item > result)
                {
                    result = item;
                }
            }
            return result;
        }

        //Average
        public static decimal AverageExtension<T>(this IEnumerable<T> collection) where T : IConvertible
        {
            var decCollection = collection.Select(x => Convert.ToDecimal(x));
            decimal result = 0;
            foreach (var item in decCollection)
            {
                result += item;
            }

            result = result / decCollection.Count();
            return result;
        }
    }
}
