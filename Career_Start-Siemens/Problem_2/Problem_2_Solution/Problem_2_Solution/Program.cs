using System;
using System.Collections.Specialized;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Problem_2_Solution
{
    internal class Program {

        public static string[] CreateRandomArrayOfStrings(int numberOfStrings) {

            var chars = "abcdefghijklmnopqrstuvwxyz0123456789[]%";
            var randomChar = new Random();

            var space = " ";
            var randomSpace = new Random();

            var random = new Random();

            List<string> stringsList = new();
            string[] stringsArray = new string[numberOfStrings];

            Console.Write("\n" + "The strings are: " + "\n");

            while (numberOfStrings > 0) {

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

                if (numberOfStrings != 1) {
                    Console.WriteLine("'" + finalString + "',");
                } else {
                    Console.WriteLine("'" + finalString + "'");
                }

                stringsList.Add(finalString);
                numberOfStrings--;
            }
            
            stringsArray = stringsList.ToArray();
            return stringsArray;
        }

        public static int[] ParseTheArrayOfStrings(string[] arrayOfStrings) {

            int[] arrayOfNumbers;
            List<int> numberList = new();
            Queue<int> q = new();

            Console.Write("\n" + "The numbers are: " + "\n");

            foreach (string str in arrayOfStrings) {

                Regex regex = new Regex(@"[ ](?=(?:[^""]*""[^""]*"")*[^""]*$)", RegexOptions.Multiline);
                string[] splits = regex.Split(str);

                foreach (string split in splits) {
                    
                    string numbersPerSplit = string.Empty;
                    int val;
                    for (int i = 0; i < split.Length; i++) {
                        if (Char.IsDigit(split[i]))
                            numbersPerSplit += split[i];
                    }
                    if (numbersPerSplit.Length > 0) {
                        val = int.Parse(numbersPerSplit);
                        numberList.Add(val);
                        q.Enqueue(val);
                    }
                }

                Console.Write("[");
                while (q.Count > 0) {
                    if (q.Count != 1) {
                        Console.Write(q.Dequeue() + ",");
                    } else {
                        Console.Write(q.Dequeue());
                    }
                }
                Console.Write("]");

                q = new();
            }

            arrayOfNumbers = numberList.ToArray();
            return arrayOfNumbers;
        }

        public static int[] RemoveDuplicatesFromSortedArray(int[] arrayOfNumbers) {

            int index = 1;
            for (int i = 0; i < arrayOfNumbers.Length - 1; i++) {
                if (arrayOfNumbers[i] != arrayOfNumbers[i + 1]) {
                    arrayOfNumbers[index] = arrayOfNumbers[i + 1];
                    index++;
                }
                else {
                    continue;
                }
            }

            int[] newarr = new int[index];
            for (int i = 0; i < index; i++) {
                newarr[i] = arrayOfNumbers[i];
            }
            return newarr;
        }

        public static void SortTheArrayOfStrings(int[] arrayOfNumbers) {
  
            Array.Sort(arrayOfNumbers);

            int lastValue = arrayOfNumbers.Last();

            int[] finalArrayOfNumbers = RemoveDuplicatesFromSortedArray(arrayOfNumbers);

            Console.Write("\n" + "\n"  + "The Output is: " + "\n" + "[");
            foreach (int i in finalArrayOfNumbers) {
                if (i != lastValue) {
                    Console.Write(i + ",");
                } else {
                    Console.Write(i);
                }
            }
            Console.Write("]" + "\n");
        }

        static void Main(string[] args) {

            Console.Write("Give a number of strings: ");
            int numberOfStrings = int.Parse(Console.ReadLine());

            string[] arrayOfString = CreateRandomArrayOfStrings(numberOfStrings);
            //string[] arrayOfString = {"12 might 45 % internship 2022" , "array of 5 elements" , " best fo[23]%6c abc 45 "};
            int[] arrayOfNumbers = ParseTheArrayOfStrings(arrayOfString);
            SortTheArrayOfStrings(arrayOfNumbers);
        }
    }
}