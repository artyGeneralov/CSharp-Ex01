using System;

namespace Ex01_4
{
    public class Program
    {
        readonly static int STRING_LENGTH = 8;
        public static void Main()
        {
            startStringAnalyzer();
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        private static void startStringAnalyzer()
        {
            string userString;
            while (true)
            {
                Console.WriteLine("Please insert an 8 digit/letter string.");
                userString = Console.ReadLine();
                if (checkStringCorrect(userString))
                    break;
                Console.WriteLine("Wrong input. Try again.");
            }

            // test if palyndrome
            if(checkIfPalindrome(userString))
                Console.WriteLine(String.Format("The string : \"{0}\" is a palyndrome!", userString));
            else
                Console.WriteLine(String.Format("The string : \"{0}\" is NOT a palyndrome!", userString));


            // number - > check if devisible by 4
            // word - > count uppercase in word
            int devisor = 4;
            if(isNumber(userString))
                if(isDevisibleBy(userString, devisor))
                    Console.WriteLine(String.Format("Your number \"{0}\" is devisible by {1}", userString, devisor));
                else
                    Console.WriteLine(String.Format("Your number \"{0}\" is NOT devisible by {1}", userString, devisor));
            else if(!isNumber(userString))
                Console.WriteLine(String.Format("Your word \"{0}\" has {1} uppercase letters", userString, countUppercase(userString)));

            


        }


        private static bool checkIfPalindrome(string stringToCheck)
        {
            return checkIfPalindrome(stringToCheck, 0, stringToCheck.Length - 1);     
        }
        private static bool checkIfPalindrome(string stringToCheck, int first, int last)
        {
            if (first >= last)
                return true;

            if (stringToCheck[first] != stringToCheck[last])
                return false;

            return checkIfPalindrome(stringToCheck, first + 1, last - 1);
        }

        private static bool checkStringCorrect(string stringToCheck)
        {
            // check for correct length
            if (stringToCheck.Length != STRING_LENGTH)
                return false;


            // check that string contains either letters or numbers but not both
            bool isNumeral = false;
            if (char.IsDigit(stringToCheck[0]))
                isNumeral = true;
            for(int i = 1; i < stringToCheck.Length; i++)
            {
                char curLetter = stringToCheck[i];
                if (!char.IsLetter(curLetter) && !char.IsDigit(curLetter))
                    return false;
                else if (char.IsDigit(curLetter) && isNumeral == false)
                    return false;
                else if (char.IsLetter(curLetter) && isNumeral)
                    return false;
            }
            return true;
        }
        private static bool isDevisibleBy(string stringToCheck, int devisor)
        {
            int x = 10;
            int exponent = stringToCheck.Length;
            long number = 0;
            for (int i = 0; i < stringToCheck.Length; i++)
            {
                number += (long)(char.GetNumericValue(stringToCheck[i]) * Math.Pow(x, exponent));
                exponent--;
            }
            if (number % devisor != 0)
                return false;
            return true;
        }

        private static int countUppercase(string word)
        {
            int uppercaseCount = 0;
            for(int i = 0; i < word.Length; i++)
                if (char.IsUpper(word[i]))
                    uppercaseCount++;
            return uppercaseCount;
        }


        public static bool isNumber(string stringToCheck)
        {
            for(int i = 0; i < stringToCheck.Length; i++)
            {
                if (!char.IsDigit(stringToCheck[i]))
                    return false;
            }
            return true;
        }
    }
}
