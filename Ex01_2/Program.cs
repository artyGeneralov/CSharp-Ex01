using System;

namespace Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            printHourGlass(5);
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        public static void printHourGlass(int depth)
        {
            if (depth % 2 == 0)
                depth++;
            printWholeDescending(depth, depth); // decending pattern starts from max depth (highest amount of stars)
            printWholeAscending(3, depth); // ascending pattern starts from 3, so that 1 isnt printed twice
        }

        private static void printWholeDescending(int currentDepth, int originalDepth)
        {
            // currentDepth here and in 'Ascending' method - represents number of stars in line
            if (currentDepth > 0)
            {
                printLine(currentDepth, originalDepth);
                printWholeDescending(currentDepth - 2, originalDepth);
            }
        }

        private static void printWholeAscending(int currentDepth, int originalDepth)
        {
            if (currentDepth <= originalDepth)
            {
                printLine(currentDepth, originalDepth);
                printWholeAscending(currentDepth + 2, originalDepth);
            }
        }

        private static void printLine(int numberOfStars, int depth)
        {
            // prints num of stars padded to the left by spaces.
            string line = new string('*', numberOfStars).PadLeft((depth + numberOfStars) / 2);
            Console.WriteLine(line);
        }
    }
}
