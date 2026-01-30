using System;
using System.Collections.Generic;
using System.Text.Json;

record Student(string Name, int Score);

class Program
{
    static void Main()
    {
        string[] items =
        {
            "Alice:85",
            "Bob:70",
            "Charlie:85",
            "David:60"
        };

        int minScore = 70;

        string json = BuildStudentsJson(items, minScore);
        Console.WriteLine(json);
    }

    static string BuildStudentsJson(string[] items, int minScore)
    {
        List<Student> students = new List<Student>();

        foreach (string item in items)
        {
            if (string.IsNullOrWhiteSpace(item))
                continue;

            string[] parts = item.Split(':');
            if (parts.Length != 2)
                continue;

            string name = parts[0];
            if (!int.TryParse(parts[1], out int score))
                continue;

            if (score >= minScore)
            {
                students.Add(new Student(name, score));
            }
        }

        students.Sort((a, b) =>
        {
            int scoreCompare = b.Score.CompareTo(a.Score);
            if (scoreCompare != 0)
                return scoreCompare;

            return string.Compare(a.Name, b.Name, StringComparison.Ordinal);
        });

        return JsonSerializer.Serialize(students);
    }
}
