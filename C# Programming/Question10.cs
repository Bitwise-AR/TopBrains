using System;

class Program
{
    static void Main()
    {
        int heightCm = int.Parse(Console.ReadLine());
        string category = GetHeightCategory(heightCm);
        Console.WriteLine(category);
    }

    static string GetHeightCategory(int heightCm)
    {
        if (heightCm < 150)
            return "Short";
        else if (heightCm < 180)
            return "Average";
        else
            return "Tall";
    }
}
