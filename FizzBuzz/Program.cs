using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter an upper bound for FizzBuzz:");
            var limit = Convert.ToInt32(Console.ReadLine());       // Upper bound on numbers to process, obtained from user
            
            for (var i = 1; i <= limit; i++)
            {
                var response = "";
                var words = new List<string>();           // Holds the string value that will eventually be output
                
                if (i % 13 == 0)            // Carry out rule for Fezz first as the position of this respective to the other words is most crucial
                {
                    words.Add("Fezz");     // Words ended with commas so they can be separated ad have order reversed if necessary 
                }
                
                if (i % 11 == 0)            // Other words added if required in relevant positions change
                {
                    words.Add("Bong");
                }
                else
                {
                    if (i % 3 == 0)
                    {
                        words.Insert(0, "Fizz");
                    }

                    if (i % 5 == 0)
                    {
                        words.Add("Buzz");
                    }

                    if (i % 7 == 0)
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
                    if (i % 17 == 0)
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