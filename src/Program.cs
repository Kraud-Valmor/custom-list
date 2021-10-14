using System;

namespace Task.List
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> array = new MyList<int>(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);

            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine(array.ItemAt(i));
            }

            Console.WriteLine(array.Count);
            Console.WriteLine(array.Capacity);

            Console.ReadKey();
        }
    }
}