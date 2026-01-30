using System;

class Program
{
    static void Main()
    {
        int totalSeconds = int.Parse(Console.ReadLine());
        string formatted = FormatTime(totalSeconds);
        Console.WriteLine(formatted);
    }

    static string FormatTime(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        return minutes + ":" + seconds.ToString("D2");
    }
}
