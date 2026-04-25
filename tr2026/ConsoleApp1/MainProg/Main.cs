using OP7.LinkedListClass;

namespace OP7
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList temp = new LinkedList();

            Console.WriteLine("Enter size of Linked List:\n");
            int size = int.Parse(Console.ReadLine());

            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "");
            }

            for (int i = 0; i < size; ++i)
            {
                Console.WriteLine("Enter node value:\n");
                temp.Add(short.Parse(Console.ReadLine()));
            }

            Console.WriteLine("Your current Linked List:\n");
            foreach (var t in temp)
            {
                Console.Write($"{t}\t");
            }

            Console.WriteLine("\n\nEnter the number whose multiple we will be looking for:\n");
            short t1 = short.Parse(Console.ReadLine());
            Console.WriteLine($"The first value: {temp.FindFirst(t1)}");

            Console.WriteLine($"\nThe product of numbers smaller than avg is {temp.FindProduct()}");

            Console.WriteLine("\nEnter the number whose multiple we will be looking for:\n");
            short t2 = short.Parse(Console.ReadLine());
            LinkedList newList = temp.GenerateNewList(t2);

            Console.WriteLine("Your new Linked List:\n");
            foreach (var t in newList)
            {
                Console.Write($"{t}\t");
            }

            temp.DeleteGreater();

            Console.WriteLine("\n\nYour current Linked List (after removing all values greater than avg):\n");
            foreach (var t in temp)
            {
                Console.Write($"{t}\t");
            }
        }
    }
}
