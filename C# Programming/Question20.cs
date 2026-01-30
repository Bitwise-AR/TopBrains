using System;
using System.Globalization;

interface IArea
{
    double GetArea();
}

abstract class Shape : IArea
{
    public abstract double GetArea();
}

class Circle : Shape
{
    private double r;

    public Circle(double r)
    {
        this.r = r;
    }

    public override double GetArea()
    {
        return Math.PI * r * r;
    }
}

class Rectangle : Shape
{
    private double w;
    private double h;

    public Rectangle(double w, double h)
    {
        this.w = w;
        this.h = h;
    }

    public override double GetArea()
    {
        return w * h;
    }
}

class Triangle : Shape
{
    private double b;
    private double h;

    public Triangle(double b, double h)
    {
        this.b = b;
        this.h = h;
    }

    public override double GetArea()
    {
        return 0.5 * b * h;
    }
}

class Program
{
    static void Main()
    {
        string[] shapes =
        {
            "C 3",
            "R 4 5",
            "T 6 2"
        };

        double totalArea = CalculateTotalArea(shapes);
        Console.WriteLine(totalArea);
    }

    static double CalculateTotalArea(string[] shapes)
    {
        double total = 0;

        foreach (string s in shapes)
        {
            Shape shape = ParseShape(s);
            if (shape != null)
            {
                total += shape.GetArea();
            }
        }

        return Math.Round(total, 2, MidpointRounding.AwayFromZero);
    }

    static Shape ParseShape(string input)
    {
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        char type = parts[0][0];

        switch (type)
        {
            case 'C':
                return new Circle(double.Parse(parts[1], CultureInfo.InvariantCulture));

            case 'R':
                return new Rectangle(
                    double.Parse(parts[1], CultureInfo.InvariantCulture),
                    double.Parse(parts[2], CultureInfo.InvariantCulture)
                );

            case 'T':
                return new Triangle(
                    double.Parse(parts[1], CultureInfo.InvariantCulture),
                    double.Parse(parts[2], CultureInfo.InvariantCulture)
                );

            default:
                return null;
        }
    }
}
