using System;
using System.Collections.Specialized;

namespace Problem_2_Solution
{
    internal class Program {

        public static string[] CreateRandomArrayOfStrings(int numberOfStrings) {

            var chars = "abcdefghijklmnopqrstuvwxyz0123456789[]%";
            var randomChar = new Random();

            var space = " ";
            var randomSpace = new Random();

            var random = new Random();

            List<string> stringsList = new List<string>();
            string[] stringsArray = new string[numberOfStrings];

            Console.Write("\n" + "The String is: " + "\n");
            for (int j = 0; j < numberOfStrings; j++) {
                int randomLenght = random.Next(10, 100);
                var stringChars = new char[randomLenght];

                for (int i = 0; i < stringChars.Length; i++) {

                    int randomSpaceLenght = randomSpace.Next(1, 10);

                    if (randomSpaceLenght < 2) {
                        stringChars[i] = space[randomSpace.Next(space.Length)];
                    } else {
                        stringChars[i] = chars[randomChar.Next(chars.Length)];
                    }
                }

                var finalString = new String(stringChars);
                Console.WriteLine(finalString);
                stringsList.Add(finalString);
            }
            
            stringsArray = stringsList.ToArray();
            return stringsArray;
        }

        public static string[] ParseTheArrayOfStrings(string[] arrayOfStrings) {


            return null;
        }

        public static string SortTheArrayOfStrings(string[] arrayOfNumbers) {


            return null;
        }

        static void Main(string[] args) {

            Console.Write("Give a number of strings: ");
            int numberOfStrings = Int32.Parse(Console.ReadLine());

            string[] arrayOfString = CreateRandomArrayOfStrings(numberOfStrings);
            //string[] arrayOfNumbers = ParseTheArrayOfStrings(arrayOfString);
            //foreach (string str in arrayOfNumbers) {
            //    Console.Write("The Output is: " + "[" + str + "],");
            //}
            //string finalString = SortTheArrayOfStrings(arrayOfNumbers);
            //Console.Write("The Output is: " + "["+ finalString + "]");
        }
    }
}