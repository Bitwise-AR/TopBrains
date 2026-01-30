using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<dynamic> books = new List<dynamic>();
    static int idCounter = 1;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Admin\n2. User\n3. Exit");
            Console.Write("Select Role: ");
            string choice = Console.ReadLine();

            if (choice == "1") AdminMenu();
            else if (choice == "2") UserMenu();
            else if (choice == "3") break;
            else Console.WriteLine("Invalid choice");
        }
    }

    static void AdminMenu()
    {
        while (true)
        {
            Console.WriteLine("\nAdmin Menu");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Update Book");
            Console.WriteLine("3. Delete Book");
            Console.WriteLine("4. View All Books");
            Console.WriteLine("5. Back");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            if (choice == "1") AddBook();
            else if (choice == "2") UpdateBook();
            else if (choice == "3") DeleteBook();
            else if (choice == "4") ViewBooks(books);
            else if (choice == "5") break;
            else Console.WriteLine("Invalid choice");
        }
    }

    static void UserMenu()
    {
        while (true)
        {
            Console.WriteLine("\nUser Menu");
            Console.WriteLine("1. Browse Books");
            Console.WriteLine("2. Search by Name");
            Console.WriteLine("3. Search by Publisher");
            Console.WriteLine("4. Highest Price Book");
            Console.WriteLine("5. Lowest Price Book");
            Console.WriteLine("6. Back");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            if (choice == "1") ViewBooks(books);
            else if (choice == "2") SearchByName();
            else if (choice == "3") SearchByPublisher();
            else if (choice == "4") ShowHighestPrice();
            else if (choice == "5") ShowLowestPrice();
            else if (choice == "6") break;
            else Console.WriteLine("Invalid choice");
        }
    }

    static void AddBook()
    {
        dynamic book = new System.Dynamic.ExpandoObject();
        book.Id = idCounter++;

        Console.Write("Book Name: ");
        book.Name = Console.ReadLine();

        Console.Write("Publisher: ");
        book.Publisher = Console.ReadLine();

        Console.Write("Price: ");
        book.Price = decimal.Parse(Console.ReadLine());

        books.Add(book);
        Console.WriteLine("Book added successfully");
    }

    static void UpdateBook()
    {
        Console.Write("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine());
        var book = books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            Console.WriteLine("Book not found");
            return;
        }

        Console.Write("New Name: ");
        book.Name = Console.ReadLine();

        Console.Write("New Publisher: ");
        book.Publisher = Console.ReadLine();

        Console.Write("New Price: ");
        book.Price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Book updated successfully");
    }

    static void DeleteBook()
    {
        Console.Write("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine());
        var book = books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            Console.WriteLine("Book not found");
            return;
        }

        books.Remove(book);
        Console.WriteLine("Book deleted successfully");
    }

    static void ViewBooks(IEnumerable<dynamic> list)
    {
        if (!list.Any())
        {
            Console.WriteLine("No books available");
            return;
        }

        foreach (var b in list)
        {
            Console.WriteLine($"ID:{b.Id} Name:{b.Name} Publisher:{b.Publisher} Price:{b.Price}");
        }
    }

    static void SearchByName()
    {
        Console.Write("Enter Book Name: ");
        string name = Console.ReadLine();
        var result = books.Where(b => b.Name.ToString().Contains(name, StringComparison.OrdinalIgnoreCase));
        ViewBooks(result);
    }

    static void SearchByPublisher()
    {
        Console.Write("Enter Publisher Name: ");
        string publisher = Console.ReadLine();
        var result = books.Where(b => b.Publisher.ToString().Contains(publisher, StringComparison.OrdinalIgnoreCase));
        ViewBooks(result);
    }

    static void ShowHighestPrice()
    {
        if (!books.Any())
        {
            Console.WriteLine("No books available");
            return;
        }

        var book = books.OrderByDescending(b => b.Price).First();
        ViewBooks(new List<dynamic> { book });
    }

    static void ShowLowestPrice()
    {
        if (!books.Any())
        {
            Console.WriteLine("No books available");
            return;
        }

        var book = books.OrderBy(b => b.Price).First();
        ViewBooks(new List<dynamic> { book });
    }
}
