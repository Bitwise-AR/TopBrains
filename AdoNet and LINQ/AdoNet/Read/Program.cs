class Program
{
    static void Main()
    {
        ProductRepository repo = new ProductRepository();
        List<Product> products = repo.GetAllProducts();

        foreach (var p in products)
        {
            Console.WriteLine($"{p.Id} - {p.Name} - ${p.Price}");
        }
    }
}