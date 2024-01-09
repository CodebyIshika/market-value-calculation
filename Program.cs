using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    internal class Program
    {
        /// <summary>
        /// Calculating the market value for the investment based on user-input interest rate, 
        /// growth rate, dividend and number of shares. 
        /// </summary>
        static void Main(string[] args)
        {
            Console.Write("Enter interest rate (high, medium, low): ");
            string interestRate = Console.ReadLine();

            Console.Write("Enter growth rate (high, medium, low): ");
            string growthRate = Console.ReadLine();

            Console.Write("Enter most recent dividend (between 1 and 99): ");
            uint dividend = uint.Parse(Console.ReadLine());
            // Check whether dividend is between 1 and 99 or not
            if (dividend < 1 || dividend > 99)
            {
                Console.WriteLine("Invalid input for recent dividend.");
                return; 
            }

            Console.Write("Enter number of shares: ");
            uint shares = uint.Parse(Console.ReadLine());

            // Calculate the market value
            CalculateMarketValue(interestRate, growthRate, dividend, shares);

            Console.ReadLine();
        }

        static void CalculateMarketValue(string interestRate, string growthRate, uint dividend, uint shares)
        {
            // Defining interest rate and growth rate 
            double R = GetInterestRate(interestRate);
            double G = GetGrowthRate(growthRate);

            // Check for division by zero
            if (R - G == 0)
            {
                Console.WriteLine("Sorry, there is an error as your input may cause division by zero.");
                return ;
            }

            // Calculate the price using the given formula
            double price = dividend / (R - G);

            // Calculate the projected market value using the price and number of shares
            double marketValue = price * shares;

            // Display the market value by rounding it to two decimal place
            Console.WriteLine("The projected market value for the investment is: ${0}", Math.Round(marketValue, 2));
        }

        static double GetInterestRate(string rate)
        {
            // convert rate to lower-case for case-insensitive comparsion
            rate = rate.ToLower();

            // check interest rate 
            if (rate == "high")
            {
                return 0.20;
            }
            else if (rate == "medium")
            {
                return 0.10;
            }
            else if (rate == "low")
            {
                return 0.08;
            }
            else
            {
                return 0; // Default to 0 for invalid input
            }
        }

        static double GetGrowthRate(string rate)
        {
            // convert rate to lower-case for case-insensitive comparsion
            rate = rate.ToLower();

            // check growth rate 
            if (rate == "high")
            {
                return 0.075;
            }
            else if (rate == "medium")
            {
                return 0.05;
            }
            else if (rate == "low")
            {
                return 0.025;
            }
            else
            {
                return 0; // Default to 0 for invalid input
            }
        }
    }
}
