using System;

class Program
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        int gcd = Gcd(a, b);
        Console.WriteLine(gcd);
    }

    static int Gcd(int a, int b)
    {
        if (b == 0)
            return a;

        return Gcd(b, a % b);
    }
}
