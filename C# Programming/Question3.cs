using System;
using System.Globalization;
using System.Text;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        input = input.Trim();

        StringBuilder cleaned = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (i == 0 || input[i] != input[i - 1])
            {
                cleaned.Append(input[i]);
            }
        }

        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        string result = textInfo.ToTitleCase(cleaned.ToString().ToLower());

        Console.WriteLine(result);
    }
}
