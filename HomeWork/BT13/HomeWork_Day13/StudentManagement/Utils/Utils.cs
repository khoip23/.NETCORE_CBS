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

    public static int GetIntInput(string prompt, string errorMsg, int from, int to)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out result) && result >= from && result <= to)
            {
                return result;
            }
            Console.WriteLine("The value must be between " + from + " and " + to + ".");
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
            if (double.TryParse(Console.ReadLine(), out result) && result >= 0 && result <= 10)
            {
                return result;
            }
            Console.WriteLine(errorMsg);
        }
    }
}
