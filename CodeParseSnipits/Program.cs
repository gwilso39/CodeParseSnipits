using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParseSnipits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"String has unique Chars = {UniqueChars()}");
            Console.ReadLine();

            //What does "ReadKey" do?
            //var inputKey = Console.ReadKey();
            //Console.WriteLine($"{ inputKey}");
        }

        //Creating a method to solve:
        //Given a string of only 9 integers ranging from 0-9, find the missing integer
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

        //Creating a method to solve:
        //Given an input string, determine if any characters are reused
        public static bool UniqueChars()
        {
            bool[] array = new bool[256];

            string text = "SuperCaliFragilisticExpealidocious";

            foreach (char value in text)
            {
                if (array[(int)value])
                {
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
        
    }
}
