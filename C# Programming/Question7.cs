using System;

class Program
{
    static void Main()
    {
        int a = 10;
        int b = 20;

        Console.WriteLine("Before ref swap:");
        Console.WriteLine($"a = {a}, b = {b}");

        SwapUsingRef(ref a, ref b);

        Console.WriteLine("After ref swap:");
        Console.WriteLine($"a = {a}, b = {b}");

        Console.WriteLine();

        int x = 30;
        int y = 40;

        Console.WriteLine("Before out swap:");
        Console.WriteLine($"x = {x}, y = {y}");

        SwapUsingOut(x, y, out x, out y);

        Console.WriteLine("After out swap:");
        Console.WriteLine($"x = {x}, y = {y}");
    }

    static void SwapUsingRef(ref int p, ref int q)
    {
        int temp = p;
        p = q;
        q = temp;
    }

    static void SwapUsingOut(int p, int q, out int x, out int y)
    {
        x = q;
        y = p;
    }
}
