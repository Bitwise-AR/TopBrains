using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string inputFile = "log.txt";
        string outputFile = "error.txt";

        List<string> errorLogs = new List<string>();

        foreach (string line in File.ReadLines(inputFile))
        {
            if (line.Contains("ERROR"))
            {
                errorLogs.Add(line);
            }
        }

        File.WriteAllLines(outputFile, errorLogs);

        Console.WriteLine("ERROR logs extracted successfully.");
    }
}
