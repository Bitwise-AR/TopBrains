using System;
using System.Collections.Generic;

class Bike
{
    public string Model { get; set; }
    public int PricePerDay { get; set; }
    public string Brand { get; set; }
}

class BikeUtility
{
    public void AddBikeDetails(string model, string brand, int pricePerDay)
    {
        int key = Program.bikeDetails.Count + 1;

        Bike bike = new Bike
        {
            Model = model,
            Brand = brand,
            PricePerDay = pricePerDay
        };

        Program.bikeDetails.Add(key, bike);
    }

    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string, List<Bike>> result =
            new SortedDictionary<string, List<Bike>>();

        foreach (Bike bike in Program.bikeDetails.Values)
        {
            if (!result.ContainsKey(bike.Brand))
            {
                result[bike.Brand] = new List<Bike>();
            }

            result[bike.Brand].Add(bike);
        }

        return result;
    }
}

class Program
{
    public static SortedDictionary<int, Bike> bikeDetails =
        new SortedDictionary<int, Bike>();

    static void Main()
    {
        BikeUtility utility = new BikeUtility();
        int choice;

        do
        {
            Console.WriteLine("1. Add Bike Details");
            Console.WriteLine("2. Group Bikes By Brand");
            Console.WriteLine("3. Exit");
            Console.WriteLine();
            Console.Write("Enter your choice ");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the model: ");
                    string model = Console.ReadLine();

                    Console.Write("Enter the brand: ");
                    string brand = Console.ReadLine();

                    Console.Write("Enter the price per day: ");
                    int price = int.Parse(Console.ReadLine());

                    utility.AddBikeDetails(model, brand, price);

                    Console.WriteLine();
                    Console.WriteLine("Bike details added successfully");
                    Console.WriteLine();
                    break;

                case 2:
                    var grouped = utility.GroupBikesByBrand();

                    foreach (var entry in grouped)
                    {
                        foreach (var bike in entry.Value)
                        {
                            Console.WriteLine($"{entry.Key} {bike.Model}");
                        }
                    }
                    Console.WriteLine();
                    break;

                case 3:
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    Console.WriteLine();
                    break;
            }

        } while (choice != 3);
    }
}
