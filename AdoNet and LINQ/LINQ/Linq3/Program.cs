using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static List<string> GetTop3Scorers(string filePath)
    {
        return File.ReadAllLines(filePath)
            .Select(line => line.Split(','))
            .Where(parts => parts.Length == 2)
            .Select(parts => new
            {
                Name = parts[0].Trim(),
                Marks = int.Parse(parts[1].Trim())
            })
            .OrderByDescending(x => x.Marks)
            .Take(3)
            .Select(x => x.Name)
            .ToList();
    }

    static void Main()
    {
        string path = "data.csv";

        var topStudents = GetTop3Scorers(path);

        foreach (var name in topStudents)
        {
            Console.WriteLine(name);
        }
    }
}