using System;
using System.Collections.Specialized;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Problem_2_Solution
{
    internal class Program {

        public static string[] CreateRandomArrayOfStrings(int numberOfStrings) {

            // Take the caracters to can construct random strings
            var chars = "abcdefghijklmnopqrstuvwxyz[]%";

            // Take the numbers to can construct random strings
            var numbers = "0123456789";

            // Take some white spaces to can divide the string in some portiones
            var space = " ";

            var random = new Random();

            // Create a list to save each string in it
            List<string> stringsList = new();
            // Create an array of stringes to can append the list of stringes in it
            string[] stringsArray = new string[numberOfStrings];

            Console.Write("\n" + "The strings are: " + "\n");

            // Create stringes of a defined number
            while (numberOfStrings > 0) {

                // Choose a random lenght for each string between 10-100
                int randomLenght = random.Next(10, 100);
                var stringChars = new char[randomLenght];

                // Create a random string
                for (int i = 0; i < stringChars.Length; i++) {

                    // Take a random number to can add a white space in the string
                    int randomSpaceLenght = random.Next(1, 10);
                    // Take a random number to can add a number in the string
                    int randomNumberLenght = random.Next(1, 10);

                    // Choose a number less then 2 to not have so many white spaces
                    if (randomSpaceLenght < 2) {
                        // Append each white space in the string
                        stringChars[i] = space[random.Next(space.Length)];
                    } else {
                        // Choose a number less then 2 in order to not exceed the inter size
                        if (randomNumberLenght < 2) {
                            // Append each number in the string
                            stringChars[i] = numbers[random.Next(numbers.Length)];
                        } else {
                            // Append each character in the string
                            stringChars[i] = chars[random.Next(chars.Length)];
                        }
                    }
                }

                // Create the string 
                var finalString = new String(stringChars);

                // Display each string 
                if (numberOfStrings != 1) {
                    Console.WriteLine("'" + finalString + "',");
                } else {
                    Console.WriteLine("'" + finalString + "'");
                }

                // Add each string in a list
                stringsList.Add(finalString);
                numberOfStrings--;
            }
            
            // Transfer the strings from the list in an array of strings 
            stringsArray = stringsList.ToArray();
            return stringsArray;
        }

        public static int[] ParseTheArrayOfStrings(string[] arrayOfStrings) {

            int[] arrayOfNumbers;

            // Create a list to can store the final string of numbers
            List<int> numberList = new();
            // Create a queue to can display the numbers from every strings appart
            Queue<int> q = new();

            Console.Write("\n" + "The numbers are: " + "\n");

            // Take each string from the array of strings
            foreach (string str in arrayOfStrings) {

                // Split every string in portions by the white spaces
                Regex regex = new Regex(@"[ ](?=(?:[^""]*""[^""]*"")*[^""]*$)", RegexOptions.Multiline);
                string[] splits = regex.Split(str);

                // Check every split string and take the numbers from it
                foreach (string split in splits) {
                    
                    string numbersPerSplit = string.Empty;
                    int val;

                    // Take every number in a split string
                    for (int i = 0; i < split.Length; i++) {
                        if (Char.IsDigit(split[i]))
                            numbersPerSplit += split[i];
                    }

                    // Condition to check if exist a number in a split string
                    if (numbersPerSplit.Length > 0) {
                        
                        // convert string to int
                        val = int.Parse(numbersPerSplit);

                        // Save each number in a list
                        numberList.Add(val);

                        // Save each number in a queue
                        q.Enqueue(val);
                    }
                }

                // Display each set of numbers for each split string appart
                Console.Write("[");
                while (q.Count > 0) {
                    if (q.Count != 1) {
                        Console.Write(q.Dequeue() + ",");
                    } else {
                        Console.Write(q.Dequeue());
                    }
                }
                Console.Write("]");

                // Cleare the queue to can solve the next string
                q = new();
            }

            // Transfer the numbers from the list in an array of numbers 
            arrayOfNumbers = numberList.ToArray();
            return arrayOfNumbers;
        }

        public static int[] RemoveDuplicatesFromSortedArray(int[] arrayOfNumbers) {

            // Create an index to can move the numbers forward and to can eliminate de duplicates
            int index = 1;
            // Save the numbers in a new array whithout the duplicates
            for (int i = 0; i < arrayOfNumbers.Length - 1; i++) {
                if (arrayOfNumbers[i] != arrayOfNumbers[i + 1]) {
                    arrayOfNumbers[index] = arrayOfNumbers[i + 1];
                    index++;
                }
                else {
                    continue;
                }
            }

            // Put the numbers in a final array with the indexes for each single number 
            int[] newarr = new int[index];
            for (int i = 0; i < index; i++) {
                newarr[i] = arrayOfNumbers[i];
            }
            return newarr;
        }

        public static void SortTheArrayOfStrings(int[] arrayOfNumbers) {
  
            // Sort the array of numbers to be arranged 
            Array.Sort(arrayOfNumbers);

            // Take the last number in the array 
            int lastValue = arrayOfNumbers.Last();

            //  Remove the duplicates number in the array
            int[] finalArrayOfNumbers = RemoveDuplicatesFromSortedArray(arrayOfNumbers);

            // Display the final array of numbers
            Console.Write("\n" + "\n"  + "The Output is: " + "\n" + "[");
            foreach (int i in finalArrayOfNumbers) {

                // Check if is the final number in the array so it can`t have a comma after it
                if (i != lastValue) {
                    Console.Write(i + ",");
                } else {
                    Console.Write(i);
                }
            }
            Console.Write("]" + "\n");
        }

        static void Main(string[] args) {

            // Give a number of strings to be displayed and solved
            Console.Write("Give a number of strings: ");
            int numberOfStrings = int.Parse(Console.ReadLine());

            // Create an array of random strings
            string[] arrayOfString = CreateRandomArrayOfStrings(numberOfStrings);

            // Parse every string in the array and display the numbers in each string
            int[] arrayOfNumbers = ParseTheArrayOfStrings(arrayOfString);

            // Sort the final array of numbers and display the solution
            SortTheArrayOfStrings(arrayOfNumbers);
        }
    }
}