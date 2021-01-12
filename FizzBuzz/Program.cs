using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    [Flags]
    public enum Instructions
    {
        None = 0b_0000_0000,
        Fizz = 1,
        Buzz = 2,
        Bang = 4,
        Bong = 8,
        Fezz = 16,
        Reverse = 32
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter an upper bound for FizzBuzz:");
            var limit = Convert.ToInt32(Console.ReadLine());       // Upper bound on numbers to process, obtained from user
            var rules = new Dictionary<int, Instructions>()
            {
                {3, Instructions.Fizz},
                {5, Instructions.Buzz},
                {7, Instructions.Bang},
                {11, Instructions.Bong},
                {13, Instructions.Fezz},
                {17, Instructions.Reverse}
            };
            
            for (var i = 1; i <= limit; i++)
            {
                var response = "";
                var divisors = Instructions.None;           // Holds the string value that will eventually be output
                var words = new List<string>();

                for (var j = 0; j < rules.Count(); j++)
                {
                    if (i % rules.ElementAt(j).Key == 0)
                    {
                        divisors |= rules.ElementAt(j).Value;
                    }
                }
                
                if ((divisors & Instructions.Fezz) == Instructions.Fezz)            // Carry out rule for Fezz first as the position of this respective to the other words is most crucial
                {
                    words.Add("Fezz");     // Words ended with commas so they can be separated ad have order reversed if necessary 
                }
                
                if ((divisors & Instructions.Bong) == Instructions.Bong)            // Other words added if required in relevant positions change
                {
                    words.Add("Bong");
                }
                else
                {
                    if ((divisors & Instructions.Fizz) == Instructions.Fizz)
                    {
                        words.Insert(0, "Fizz");
                    }

                    if ((divisors & Instructions.Buzz) == Instructions.Buzz)
                    {
                        words.Add("Buzz");
                    }

                    if ((divisors & Instructions.Bang) == Instructions.Bang)
                    {
                        words.Add("Bang");
                    }
                }
                
                
                if (!words.Any())            // If no words added then our response is the number i
                {
                    response = i.ToString();
                }
                else                           // Otherwise we remove the commas from our output, reversing the order of words if necessary
                {
                    if ((divisors & Instructions.Reverse) == Instructions.Reverse)
                    {
                        response = words.Aggregate("", (current, word) => word + current);
                    }
                    else
                    {
                        response = words.Aggregate("", (current, word) => current + word);
                    }
                }
                
                Console.WriteLine(response);    // Output
            }
        }
    }
}