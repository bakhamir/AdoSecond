using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;


namespace AdoSecond
{
    internal class Program
    {
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=testdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; // Замените на свои значения
        static void Main()
        {
            returnAnimals();
        }
        static void  returnAnimals()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("GetAllAnimals", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string category = reader.GetString(2);
                                string color = reader.GetString(3);
                                Console.WriteLine($"ID: {id}, Name: {name}, Category: {category}, Color: {color}");
                            }
                        }


                    }
                }
            }
        }
    }

}
//create PROCEDURE GetAllAnimals
//AS
//BEGIN
//    SELECT * FROM Animals;
//END;

//CREATE TABLE Animals (
//    id INT PRIMARY KEY,
//    name NVARCHAR(255),
//    category NVARCHAR(255),
//    color NVARCHAR(255)
//);

//INSERT INTO Animals (id, name, category, color) VALUES
//(1, 'Dog', 'Mammal', 'Brown'),(2, 'Cat', 'Mammal', 'Gray'),(3, 'Parrot', 'Bird', 'Green'),(4, 'Fish', 'Fish', 'Gold'),(5, 'Snake', 'Reptile', 'Black');
