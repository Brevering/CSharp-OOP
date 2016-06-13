namespace GenericClass
{
    using System;
    public class Test
    {
        static void Main()
        {
            var myList = new GenericList<int>(5);

            myList.Add(5);
            myList.Add(8);
            myList.Add(123);
            myList.Add(4);
            myList.Add(19);
            Console.WriteLine(myList);//Problem 5 -- adding elements

            Console.WriteLine(myList[1]);//Problem 5 -- accessing elements by index

            myList.RemoveByIndex(2);
            Console.WriteLine(myList);//Problem 5 -- removing elements by index

            myList.InsertAtIndex(2, 234);//Problem 5 -- inserting elements by index
            Console.WriteLine(myList);

            myList.InsertAtIndex(1, 567);//Problem 6 -- implementing Auto grow when needed
            Console.WriteLine(myList);
            myList.InsertAtIndex(3, -89);
            Console.WriteLine(myList);

            Console.WriteLine(myList.IndexOf(8));//Problem 5 -- finding by value (return index)
            Console.WriteLine(myList.IndexOf(6));// when element not found returns -1 

            Console.WriteLine(myList.ToString());//Problem 5 ToString() override

            Console.WriteLine(myList.Min());//Problem 7 Min and Max
            Console.WriteLine(myList.Max());

            myList.Clear();//Problem 5 -- Clear the list
            Console.WriteLine(myList.ToString());
        }
    }
}
