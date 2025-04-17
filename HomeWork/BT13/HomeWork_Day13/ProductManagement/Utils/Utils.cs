using System;

public static class Utils
{
    public static int GetIntInput(string prompt, string errorMsg)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out result))
            {
                return result;
            }
            Console.WriteLine(errorMsg);
        }
    }

    public static string GetStringInput(string prompt, string errorMsg)
    {
        while (true)
        {
            Console.Write(prompt);
            var result = Console.ReadLine();
            if (!string.IsNullOrEmpty(result))
            {
                return result;
            }
            Console.WriteLine(errorMsg);
        }
    }

    public static double GetDoubleInput(string prompt, string errorMsg)
    {
        double result;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out result) && result >= 0)
            {
                return result;
            }
            Console.WriteLine(errorMsg);
        }
    }

    public static bool GetBoolInput(string prompt, string errorMsg)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine()?.Trim().ToLower();

            if (input == "true" || input == "t" || input == "yes" || input == "y")
            {
                return true;
            }
            else if (input == "false" || input == "f" || input == "no" || input == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine(errorMsg);
            }
        }
    }

}
