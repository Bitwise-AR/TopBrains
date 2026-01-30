using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<int, int> salaries = new Dictionary<int, int>
        {
            { 1, 20000 },
            { 4, 40000 },
            { 5, 15000 }
        };

        int[] ids = { 1, 4, 5 };

        int totalSalary = 0;

        foreach (int id in ids)
        {
            if (salaries.ContainsKey(id))
            {
                totalSalary += salaries[id];
            }
        }

        Console.WriteLine(totalSalary);
    }
}
