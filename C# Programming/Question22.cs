using System;

class Program
{
    static void Main()
    {
        double?[] values = { 10.5, null, 20.25, null, 5.0 };

        double? avg = AverageNonNull(values);

        if (avg.HasValue)
            Console.WriteLine(avg.Value);
        else
            Console.WriteLine("null");
    }

    static double? AverageNonNull(double?[] values)
    {
        double sum = 0;
        int count = 0;

        foreach (double? v in values)
        {
            if (v.HasValue)
            {
                sum += v.Value;
                count++;
            }
        }

        if (count == 0)
            return null;

        double avg = sum / count;
        return Math.Round(avg, 2, MidpointRounding.AwayFromZero);
    }
}
