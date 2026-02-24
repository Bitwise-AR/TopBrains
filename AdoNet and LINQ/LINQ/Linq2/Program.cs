class Program
{
    public static void Main()
    {
        // return duplicate products
        string input = Console.ReadLine();
        List<string> products = input.Split(' ').ToList();
        List<string> uniqueProducts = products.Distinct().ToList();
        Console.WriteLine("Duplicate products: ");
        foreach (string product in uniqueProducts)
        {
            int count = products.Count(p => p == product);
            if (count > 1)
            {
                Console.WriteLine(product );
            }
        }
    }
}