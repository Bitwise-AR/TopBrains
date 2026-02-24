using System;
using System.Data;
using Microsoft.Data.SqlClient;

public class EmployeeRepository
{
    private string connectionString =
        "Server=localhost\\SQLEXPRESS;Database=MVC_With_ADO;Trusted_Connection=True;TrustServerCertificate=True;";

    public void GetEmployeeCount()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("sp_GetEmployeesCount", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter outputParam = new SqlParameter
                {
                    ParameterName = "@TotalEmployees",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(outputParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                int count = (int)cmd.Parameters["@TotalEmployees"].Value;

                Console.WriteLine("Employee Count: " + count);
            }
        }
    }
}