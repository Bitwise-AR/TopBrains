using System;

class Program
{
    static void Main()
    {
        object[] values = { 10, "20", null, 5, true, 3L, -7 };

        int sum = SumOnlyIntegers(values);
        Console.WriteLine(sum);
    }

    static int SumOnlyIntegers(object[] values)
    {
        int sum = 0;

        foreach (object value in values)
        {
            if (value is int x)
            {
                sum += x;
            }
        }

        return sum;
    }
}
