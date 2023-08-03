using System;
using Ex01_4;

namespace Ex01_6
{
    internal class Program
    {
        readonly static int STRING_LEN = 6;
        public static void Main()
        {
            startNumberStatistic();
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        private static void startNumberStatistic()
        {
            // get input
            string userString;
            while (true)
            {
                Console.WriteLine("Please insert a 6 digit number");
                userString = Console.ReadLine();
                if (userString.Length == STRING_LEN && Ex01_4.Program.isNumber(userString))
                    break;
                Console.WriteLine("Wrong input");
            }

            // how many larger then 1
            int lower = 1;
            Console.WriteLine(String.Format("There are {0} numbers larger then {1}", digitsLargerThen(userString, lower), lower));

            // the smallest digit
            Console.WriteLine(String.Format("The smallest digit in your number is {0}", smallestDigit(userString)));

            // how many numbers devisible by 3
            int devisor = 3;
            Console.WriteLine(String.Format("{0} digits devisible by {1} in your number", digsDevisibleBy(userString, devisor),devisor));

            // the average of digits
            Console.WriteLine(String.Format("The average of digits in your number: {0}", avgOfDigs(userString)));
        }

        private static float avgOfDigs(string number)
        {
            float avg = 0f;
            float sum = 0;
            for (int i = 0; i < number.Length; i++)
                sum += (float)char.GetNumericValue(number[i]);
            avg = sum / number.Length;
            return avg;
        }

        private static int digsDevisibleBy(string number, int devisor)
        {
            int count = 0;
            for(int i = 0; i < number.Length; i++)
                if ((char.GetNumericValue(number[i])) % devisor == 0)
                    count++;
            return 1;
        }

        private static int smallestDigit(string number)
        {
            int smallest = 9;
            for(int i = 0; i < number.Length; i++)
                if (char.GetNumericValue(number[i]) < smallest)
                    smallest = (int)char.GetNumericValue(number[i]);
            return smallest;
        }

        private static int digitsLargerThen(string number, int lower)
        {
            int count = 0;
            for(int i = 0; i < number.Length; i++)
            {
                int current = (int)char.GetNumericValue(number[i]);
                if (current > lower)
                    count++;
            }
            return count;
        }

   }

}
