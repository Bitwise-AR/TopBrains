using System;
using Microsoft.Data.SqlClient;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
}

public class StudentRepository
{
    private string connectionString =
        "Server=localhost\\SQLEXPRESS;Database=MVC_With_ADO;Trusted_Connection=True;TrustServerCertificate=True;";

    public void InsertStudent(Student student)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO StudentNew (Id, Name, Marks) VALUES (@Id, @Name, @Marks)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", student.Id);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Marks", student.Marks);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Inserted Successfully");
    }
}

