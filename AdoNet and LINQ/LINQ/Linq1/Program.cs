using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;


public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public int Salary { get; set; }
}

class Program
{
    public static void Main()
    {
        Console.Write("No of Employees :  ");
        int count = int.Parse(Console.ReadLine());

        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < count; i++)
        {
            string[] input = Console.ReadLine().Split(' ');

            employees.Add(new Employee
            {
                Id = int.Parse(input[0]),
                Name = input[1],
                Department = input[2],
                Salary = int.Parse(input[3])
            });
        }

        var result = employees
            .Where(e => e.Salary > 50000)
            .GroupBy(e => e.Department)
            .ToDictionary(g => g.Key, g => g.ToList());

        foreach (var dept in result)
        {
            Console.Write($"{dept.Key} -> ");
            var names = dept.Value.Select(e => e.Name);
            Console.WriteLine(string.Join(", ", names));
        }
    }
}