using System;
using System.Linq;

class SafeInput
{
    public static int ReadInt(string prompt = "")
    {
        while (true)
        {
            if (!string.IsNullOrWhiteSpace(prompt))
                Console.Write(prompt);

            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }

    public static decimal ReadDecimal(string prompt = "")
    {
        while (true)
        {
            if (!string.IsNullOrWhiteSpace(prompt))
                Console.Write(prompt);

            try
            {
                return decimal.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal number.");
            }
        }
    }

    public static string ReadText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            Console.WriteLine("Invalid input. Please enter valid text.");
        }
    }

    public static string ReadAccountNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            // Validate account number (only numbers allowed)
            if (!string.IsNullOrWhiteSpace(input) && input.All(char.IsDigit))
            {
                return input;
            }

            Console.WriteLine("Invalid input. Please enter a valid account number (numbers only).");
        }
    }


    private static bool HasNumbers(string input)
    {
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                return true;
            }
        }
        return false;
    }
}
