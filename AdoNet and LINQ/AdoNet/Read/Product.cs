using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class ProductRepository
{
    private string connectionString =
        "Server=localhost\\SQLEXPRESS;Database=MVC_With_ADO;Trusted_Connection=True;TrustServerCertificate=True;";

    public List<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, Name, Price FROM Product";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            Id = reader.GetInt32(0),          
                            Name = reader.GetString(1),       
                            Price = reader.GetDecimal(2)      
                        };

                        products.Add(product);
                    }
                }
            }
        }

        return products;
    }
}