using System;

namespace FizzBuzz
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string response = "";           // Holds the string value that will eventually be output
            
            Console.WriteLine("Enter an upper bound for FizzBuzz:");
            int limit = Convert.ToInt32(Console.ReadLine());       // Upper bound on numbers to process, obtained from user
            
            for (int i = 1; i <= limit; i++)
            {
                response = "";              // Response initialised for each number processed
                
                if (i % 13 == 0)            // Carry out rule for Fezz first as the position of this respective to the other words is most crucial
                {
                    response = "Fezz,";     // Words ended with commas so they can be separated ad have order reversed if necessary 
                }
                
                if (i % 11 == 0)            // Other words added if required in relevant positions
                {
                    response += "Bong,";
                }
                else
                {
                    if (i % 3 == 0)
                    {
                        response = "Fizz," + response;
                    }

                    if (i % 5 == 0)
                    {
                        response += "Buzz,";
                    }

                    if (i % 7 == 0)
                    {
                        response += "Bang,";
                    }
                }
                
                
                if (response == "")            // If no words added then our response is the number i
                {
                    response = i.ToString();
                }
                else                           // Otherwise we remove the commas from our output, reversing the order of words if necessary
                {
                    if (i % 17 == 0)
                    {
                        string[] words = response.Split(',');
                        response = "";
                        foreach (string word in words)
                        {
                            response = word + response;
                        }
                    }
                    else
                    {
                        string[] words = response.Split(',');
                        response = "";
                        foreach (string word in words)
                        {
                            response += word;
                        }
                    }
                }
                
                Console.WriteLine(response);    // Output
            }
        }
    }
}