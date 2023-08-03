using System;
namespace Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            startProg();
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        private static void startProg()
        {

            int[] binaryNumbersFromUserAsDecimals = new int[3];
            Console.WriteLine("Please insert three, 7-digit long binary numbers.");
            // fill binary array
            for (int i = 0; i < binaryNumbersFromUserAsDecimals.Length; i++)
            {
                string numStr;
                do
                {
                    Console.WriteLine("Please insert the next binary number and press 'enter':");
                    numStr = Console.ReadLine();
                    // check if valid, if not get a new number
                    if (isValidBinary(numStr))
                        break;
                    Console.WriteLine("Your value is an invalid binary number, make sure its 7 digits long and contains only 0s and 1s");
                } while (true);
                binaryNumbersFromUserAsDecimals[i] = convertBinaryToDecimal(numStr);
            }

            // print the array to the user as decimals
            Console.WriteLine("Your binaries as decimals: ");
            for (int i = 0; i < binaryNumbersFromUserAsDecimals.Length; i++)
                if (i == binaryNumbersFromUserAsDecimals.Length - 1)
                    Console.WriteLine(String.Format("{0}.", binaryNumbersFromUserAsDecimals[i]));
                else
                    Console.WriteLine(String.Format("{0}, ", binaryNumbersFromUserAsDecimals[i]));

            // how many 1s and 0s avg
            onesAndZeroesAverage(binaryNumbersFromUserAsDecimals);
            // how many powers of 2
            howManyPowersOfTwo(binaryNumbersFromUserAsDecimals);
            // how many ascending
            howManyAscendingSeries(binaryNumbersFromUserAsDecimals);
            // smallest and largest
            smallestAndLargest(binaryNumbersFromUserAsDecimals);
        }


        private static void smallestAndLargest(int[] numbersAsDecimalArray)
        {
                int largest, smallest;
                smallest = largest = numbersAsDecimalArray[0];
            for(int i = 1; i < numbersAsDecimalArray.Length; i++)
            {
                if (numbersAsDecimalArray[i] > largest)
                    largest = numbersAsDecimalArray[i];
                else if (numbersAsDecimalArray[i] < smallest)
                    smallest = numbersAsDecimalArray[i];
            }

            Console.WriteLine(String.Format("Smallest number is {0}, largest number is {1}", smallest, largest));
        }

        private static void howManyAscendingSeries(int[] numbersAsDecimalsArray)
        {
            int countAscending = 0;

            for (int i = 0; i < numbersAsDecimalsArray.Length; i++)
            {
                string numberAsString = numbersAsDecimalsArray[i].ToString();
                bool isAscending = true;

                for (int j = 0; j < numberAsString.Length - 1; j++)
                    if(numberAsString[j] >= numberAsString[j+1])
                    {
                        isAscending = false;
                        break;
                    }

                if (isAscending)
                    countAscending++;
            }

            Console.WriteLine("Number of Ascending series is: " + countAscending);
        }

        private static void howManyPowersOfTwo(int[] numbersAsDecimalArray)
        {
            int countPowersOfTwo = 0;
            for(int i = 0; i < numbersAsDecimalArray.Length; i++)
                if (Math.Log(numbersAsDecimalArray[i], 2) == Math.Round(Math.Log(numbersAsDecimalArray[i], 2)))
                    countPowersOfTwo++;
            Console.WriteLine(String.Format("There are {0} numbers that are exact powers of 2 in your input", countPowersOfTwo));

        }
        private static void onesAndZeroesAverage(int[] numbersAsDecimalsArray)
        {
            int currentZeroes = 0;
            int currentOnes = 0;
            int totalZeroes = 0;
            int totalOnes = 0;
            int binaryLengthOfNum = 7;

            float averageZeroes;
            float averageOnes;
            for (int j = 0; j < numbersAsDecimalsArray.Length; j++)
            {
                
                int maskOne = 0b0000001;
                int maskZero = ~maskOne;
                for (int i = 0; i < binaryLengthOfNum; i++)
                {
                    if ((numbersAsDecimalsArray[j] & maskOne) != 0)
                        currentOnes++;
                    else if ((numbersAsDecimalsArray[j] & maskZero) == numbersAsDecimalsArray[j])
                        currentZeroes++;
                    maskOne = maskOne << 1;
                    maskZero = ~maskOne;
                }
                totalOnes += currentOnes;
                totalZeroes += currentZeroes;
                currentOnes = 0;
                currentZeroes = 0;
            }

            averageZeroes = (float)totalZeroes / numbersAsDecimalsArray.Length;
            averageOnes = (float)totalOnes / numbersAsDecimalsArray.Length;
            Console.WriteLine(String.Format("The number of average 0s is {0}. The number of average 1s is {1}.", averageZeroes,averageOnes));
        }
        
       

        private static bool isValidBinary(string strToTest)
        {
            // check string is 7 digits long
            if (strToTest.Length != 7)
                return false;
            // check that it only contains 0s and 1s
            for(int i = 0; i < strToTest.Length; i++)
                if(strToTest[i] != '0' && strToTest[i] != '1')
                    return false;
            return true;
        }

        private static int convertBinaryToDecimal(string binaryNumberAsStr)
        {
            int powerOfTwo = 0;
            int finalNumber = 0;
            for (int i = binaryNumberAsStr.Length - 1; i >= 0; i--)
            {
                finalNumber += (int)Math.Pow(2, powerOfTwo) * int.Parse(binaryNumberAsStr[i].ToString());
                powerOfTwo++;
            }
            return finalNumber;
        }
    }
}
