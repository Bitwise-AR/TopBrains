using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }

    public override string ToString()
    {
        return $"{Name}, Age: {Age}, Marks: {Marks}";
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Aman", Age = 20, Marks = 85 },
            new Student { Name = "Riya", Age = 19, Marks = 92 },
            new Student { Name = "Karan", Age = 18, Marks = 92 },
            new Student { Name = "Neha", Age = 21, Marks = 85 }
        };

        var sortedStudents = students
            .OrderByDescending(s => s.Marks)
            .ThenBy(s => s.Age)
            .ToList();

        foreach (var student in sortedStudents)
        {
            Console.WriteLine(student);
        }
    }
}
