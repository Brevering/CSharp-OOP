namespace VersionAttribute
{
    using System;

    [Version(3, 14)]

    public class SampleClass
    {
        static void Main()
        {
            Type type = typeof(SampleClass);
            object[] allAttributes =
              type.GetCustomAttributes(false);
            foreach (VersionAttribute attr in allAttributes)
            {
                Console.WriteLine(
                  "This class is version {0}.{1} ", attr.Major, attr.Minor);
            }
        }
    }
}
