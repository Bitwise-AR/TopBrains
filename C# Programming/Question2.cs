using System;
using System.Text;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string first = Console.ReadLine();
        string second = Console.ReadLine();

        HashSet<char> secondChars = new HashSet<char>();
        foreach (char c in second.ToLower())
        {
            secondChars.Add(c);
        }

        StringBuilder filtered = new StringBuilder();

        foreach (char c in first)
        {
            char lower = char.ToLower(c);

            if (IsConsonant(lower) && secondChars.Contains(lower))
                continue;

            filtered.Append(c);
        }

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < filtered.Length; i++)
        {
            if (i == 0 || filtered[i] != filtered[i - 1])
                result.Append(filtered[i]);
        }

        Console.WriteLine(result.ToString());
    }

    static bool IsConsonant(char c)
    {
        return char.IsLetter(c) && !"aeiou".Contains(c);
    }
}
