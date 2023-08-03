using System;
using Ex01_2;

namespace Ex01_3
{
    internal class Program
    {

        public static void Main()
        {
            runHourglass();
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        private static void runHourglass()
        {
            Console.WriteLine("Please insert the amount of lines wanted in your clock: ");

            int numOfLines;
            while (true)
            {
                string numAsString = Console.ReadLine();
                bool okInteger = int.TryParse(numAsString, out numOfLines);
                if (okInteger && numOfLines >= 0)
                    break;
                Console.WriteLine("Bad value, try again");
            }
            Ex01_2.Program.printHourGlass(numOfLines);
        }


    }
}
