using System;
using System.Collections.Generic;

static class EnumerableExtensions
{
    public static string[] DistinctNamesById(this string[] items)
    {
        HashSet<string> seenIds = new HashSet<string>();
        List<string> result = new List<string>();

        foreach (string item in items)
        {
            if (string.IsNullOrEmpty(item))
                continue;

            string[] parts = item.Split(':');
            if (parts.Length != 2)
                continue;

            string id = parts[0];
            string name = parts[1];

            if (seenIds.Add(id)) // true only for first occurrence
            {
                result.Add(name);
            }
        }

        return result.ToArray();
    }
}

class Program
{
    static void Main()
    {
        string[] items =
        {
            "1:Alice",
            "2:Bob",
            "1:Charlie",
            "3:David",
            "2:Eve"
        };

        string[] distinctNames = items.DistinctNamesById();
        Console.WriteLine(string.Join(", ", distinctNames));
    }
}
