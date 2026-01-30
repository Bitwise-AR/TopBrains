using System;

class Program
{
    static void Main()
    {
        int feet = int.Parse(Console.ReadLine());
        double centimeters = ConvertFeetToCentimeters(feet);
        Console.WriteLine(centimeters);
    }

    static double ConvertFeetToCentimeters(int feet)
    {
        double cm = feet * 30.48;
        return Math.Round(cm, 2, MidpointRounding.AwayFromZero);
    }
}
