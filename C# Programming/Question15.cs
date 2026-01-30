using System;

class Program
{
    static void Main()
    {
        string[] tokens = { "10", "abc", "20", "9999999999", "-5" };
        int sum = SumValidIntegers(tokens);
        Console.WriteLine(sum);
    }

    static int SumValidIntegers(string[] tokens)
    {
        int sum = 0;

        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int value))
            {
                sum += value;
            }
        }

        return sum;
    }
}
