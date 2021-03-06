﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace CodeParseSnipits
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = false;
            do
            {
                try
                {
                    //Playing with multithreading and asynchronous processing
                    //Section 1 of 2
                    //Thread t = new Thread(new ThreadStart(ThreadMethod));
                    //t.Start();
                    //for (int i = 0; i < 4; i++)
                    //{
                    //    Console.WriteLine("Main Thread: Do some work.");
                    //    Thread.Sleep(0);
                    //}
                    //t.Join();

                    //Playing with Tasks and multithreading
                    //Task<int> t = Task.Run(() => { return 42; });
                    //t.ContinueWith((i) => { Console.WriteLine("Cancelled"); },
                    //    TaskContinuationOptions.OnlyOnCanceled);
                    //t.ContinueWith((i) => { Console.WriteLine("Faulted"); },
                    //    TaskContinuationOptions.OnlyOnFaulted);
                    //var completedTask = t.ContinueWith((i) => { Console.WriteLine("Completed"); },
                    //    TaskContinuationOptions.OnlyOnRanToCompletion);
                    //completedTask.Wait();
                    UseDelegate();

                    //Console.Write("Enter a number to test for Palindrome: ");
                    //Console.WriteLine($"{IsOrCanBePalindrome(int.Parse(Console.ReadLine()))}");

                    //Console.WriteLine($"The Reverse String of your input is: {ReverseString()}.");

                    //LeapYear();

                    //Console.WriteLine($"String has unique Chars = {UniqueChars()}");

                    //Console.WriteLine($"{ReverseStringWords("Hello Big World")}");

                    //AlternateReverseStringWords();

                    //CombineAndSortArray(new int[] { 1, 3, 4, 7, 9 }, new int[] { 2, 6, 5, 8, 10 });

                    //Console.WriteLine($"Your Answer is: {CalculateThirdSide()}");
                    input = true;
                }
                catch
                {
                    Console.WriteLine("Invalid Input");
                }
            } while (!input);

            //What does "ReadKey" do?
            //var inputKey = Console.ReadKey();
            //Console.WriteLine($"{ inputKey}");
        }

        //Playing with delegates
        public delegate int Calculate(int a, int b);
        //public static int Add(int a, int b) { return (a + b); }//Omit if using Lambda
        //public static int Multiply(int a, int b) { return (a * b); }//Omit if using Lambda

        public static void UseDelegate()
        {
            //Calculate myMath = Add;
            
            //Playing with LAMBDA
            Calculate myMath = (x, y) => x + y;

            Console.WriteLine(myMath(4, 5));


            //myMath = Multiply;
            //More LAMBDA
            myMath = (x, y) => x * y;
            Console.WriteLine(myMath(5, 5));
        }

        //Playing with multithreading and asynchronous processing
        //Section 2 of 2
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }

        private static void LeapYear()
        {
            Console.WriteLine("Leap Year test; What year would you like to check: ");
            var inputYear = int.Parse(Console.ReadLine());
            bool done = false;

            do
            {
                if (((inputYear % 4 == 0) && (inputYear % 100 == 0) && (inputYear % 400 == 0)) || 
                    ((inputYear % 4 == 0) && (inputYear % 100 != 0)))
                {
                    Console.WriteLine("Your year is a leap year...");
                    Console.WriteLine("The next 20 leap years are as follows:");
                    int ActualLeapYear = inputYear;
                    for (int i = 0; i < 20; i++)
                    {
                        Console.WriteLine($"{ActualLeapYear}");
                        ActualLeapYear += 4;
                    }
                    done = true;
                }
                else
                {
                    Console.WriteLine("The year you input is not a leap year.");

                    bool yearFound = false;
                    do
                    {
                        inputYear += 1;
                        var testVariable = inputYear % 100;
                        if (((inputYear % 4 == 0) && (inputYear % 100 == 0) && (inputYear % 400 == 0)) ||
                            ((inputYear % 4 == 0) && (inputYear % 100 != 0)))
                        {
                            yearFound = true;
                            Console.WriteLine($"The next leap year is {inputYear}");
                            done = true;
                        }
                    }
                    while (!yearFound);
                }
            } while (!done);
        }

        //Methods to determine if a number is a palidrome
        private static int Reverse(int original)
        {
            int reverse = 0;
                while (original != 0)
            {
                int digit = original % 10;
                reverse = reverse * 10 + digit;
                original = original / 10;
            }
            return reverse;
        }
        private static bool IsPalidrome(int original, int reverse)
        {
            return original == reverse;
        }
        public static bool IsOrCanBePalindrome(int number)
        {
            const int MaxPalindrome = 1000000;

            while (number < MaxPalindrome)
            {
                int reverse = Reverse(number);
                bool isPal = IsPalidrome(number, reverse);
                if (isPal)
                {
                    return true;
                }

                number += reverse;
            }
            return false;
        }

        //Method to receive a string and return the reverse of the string
        private static string ReverseString()
        {
            Console.Write("Input a string value here: ");
            string inputReceived = (Console.ReadLine());
            string reversedString = "";

            for (int i = inputReceived.Length - 1; i>=0; i--)
            {
                reversedString += inputReceived[i];
            }
            return reversedString;
        }

        //Given a string of only 9 random integers ranging from 0-9, find the missing integer
        public static int FindMissingNumber()
        {
            var numbers = new List<int>() { 9, 4, 8, 6, 7, 2, 0, 1, 5 };

            for (int i = 0; i < 10; i++)
            {
                if (!numbers.Contains(i))
                {
                    return i;
                }
            }
            return -1; //if no missing number
        }

        //Given an input string, determine if any characters are reused
        public static bool UniqueChars()
        {
            bool[] array = new bool[256];

            Console.WriteLine("Input a String:");
            string text = Console.ReadLine();

            foreach (char value in text)
            {
                if (array[(int)value])
                {
                    Console.WriteLine($"Duplicated character is a '{value}'");
                    return false;
                }
                else
                {
                    array[(int)value] = true;
                }
            }return true;
        }
         
        //When creating something which will require user input:
        private int UserInput()
        {
            var input = false;

            int selection = 0;

            do
            {
                Console.Write(" Make a selection :");

                try
                {
                    selection = int.Parse(Console.ReadLine());
                    input = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid selection, Try again!");
                }
            } while (!input);

            return selection;

        }

        //When you need to receive input and act on it
        private bool ActOnSelectedItem(int selection)
        {
            var exit = false;

            switch (selection)
            {
                case 1:
                    //Call method 1 here
                    break;
                case 2:
                    //Call Method 2 here
                    break;
                case 3:
                   //Call Method 3 here
                    break;
                case 0:
                    exit = true;
                    break;
                default:
                    exit = true;//Not sure which value is default - should kick out if input not expected.
                    break;
            }
            return exit;
        }
		
		//Method to return the answer to the Pythagorean theorem obtaining user input
        public static double CalculateThirdSide()
        {
            double a, b, c;
            Console.WriteLine("Enter the First Value ");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Second Value ");
            b = double.Parse(Console.ReadLine());
            c = Math.Sqrt((Math.Pow(a,2))+(Math.Pow(b,2)));
            return c;
        }
		
		//Method calculate the average test score for 4 tests obtaining user input
  //      {
  //          Console.WriteLine($"Your Grade is: {CalculateTestScores()}");
  //      }
        private static object CalculateTestScores()
        {
        double cumulativeScores = 0;
        int i;
        for (i=0; i<=3; i++)
            {
                Console.Write($"Enter score #{i + 1}: ");
                cumulativeScores += (double.Parse(Console.ReadLine()));
            }
            var averageScore = cumulativeScores / i;
            return averageScore;
        }
		
        public static string ReverseStringWords(string phrase)
        {
            string sentence = "";
            string word = "";
            int i = 1;

            foreach (char z in phrase)
            {
                if (char.IsWhiteSpace(z))
                {
                    sentence = word + " " + sentence;
                    word = "";
                }
                else
                {
                    word += z;
                    if (phrase.Length == i)
                    {
                        sentence = word + " " + sentence; 
                    }
                }
                i++;
            }
            return sentence;
        }

        //ALTERNATE TO ABOVE
        public static void AlternateReverseStringWords()
        {
            string str = "Hello World";
            string[] words = str.Split(' ');
            Array.Reverse(words);
            str = string.Join(" ", words);
            Console.WriteLine(str);
        }

        public static void CombineAndSortArray(int[] ArrayOne, int[] ArrayTwo)
        {
            int[] answerArray = new int[10];

            bool done = false;
            int i = 0;
            int j = 0;
            int k = 0;

            do
            {
                if (ArrayOne[i] < ArrayTwo[j])
                {
                    answerArray[k] = ArrayOne[i];
                    i++;
                    k++;
                }
                else
                {
                    answerArray[k] = ArrayTwo[j];
                    j++;
                    k++;
                }

                if (k == answerArray.Length)
                {
                    done = true;
                }
            } while (!done);

            Console.Write("Your answer is: ");
            for (int g = 0; g <= answerArray.Length; g++)
            {
                Console.Write($"{answerArray[g]}, ");
            }
            //int[] answerArray = new int[ArrayOne.Length + ArrayTwo.Length];
            //int i = 0;
            //int j = 0;
            //int k = 0;

            //while (i < ArrayOne.Length && j < ArrayTwo.Length)
            //{
            //    if (ArrayOne[i] < ArrayTwo[j])
            //    {
            //        answerArray[k] = ArrayOne[i];
            //        i++;
            //    }
            //    else
            //    {
            //        answerArray[k] = ArrayTwo[j];
            //        j++;
            //    }
            //}

            //while (i < ArrayOne.Length)
            //{
            //    answerArray[k] = ArrayOne[i];
            //    i++;
            //    k++;
            //}

            //while (j < ArrayTwo.Length)
            //{
            //    answerArray[k] = ArrayTwo[j];
            //    j++;
            //    k++;
            //}
        }
    }
}
