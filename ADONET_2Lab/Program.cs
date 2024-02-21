using Microsoft.Data.SqlClient;

namespace ADONET_2Lab
{
    internal class Program
    {
        public static string ConnectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Warehouse;Integrated Security=True;Connect Timeout=30;";
        static void Main()
        {


            Console.WriteLine("Connect [Warehouse]?(Y/N)");
            string responce = Console.ReadLine();
            if (responce != "N")
            {
                try
                {
                    bool exit = false;
                    string query = "";
                    while (!exit)
                    {
                        Console.Clear();
                        Console.WriteLine("Select an option:\n\t1)\n\t2)\n\t3)\n\t4)\n\t5)\n\t6)\n\t7)\n\t8)\n\t9)\n\t10)\n\t11)\n\t0)Exit");
                        responce = Console.ReadLine();
                        switch (responce)
                        {
                            case "1":
                                query = "SELECT * FROM Product JOIN Shipment ON Shipment.ProductId = Product.Id";
                                
                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        Console.WriteLine("Product info");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["Id"]}|{reader["Name"]}|{reader["Type"]}|{reader["Price"]}|{reader["Producer"]}|{reader["Quantity"]}|{reader["ShipmentDate"]}|");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "2":
                                query = "SELECT DISTINCT [Type] FROM Product";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        Console.WriteLine("Types:");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($">{reader["Type"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "3":
                                query = "SELECT DISTINCT [Producer] FROM Shipment";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        Console.WriteLine("Producers:");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($">{reader["Type"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "4":
                                query = "SELECT TOP 1 Product.Name, Shipment.Quantity FROM Product JOIN Shipment ON Shipment.ProductId = Product.Id ORDER BY Shipment.Quantity DESC";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        Console.WriteLine("Max Quantity:");
                                        while (reader.Read())
                                        {
                                            Console.Write($"{reader["Name"]}|{reader["Quantity"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "5":
                                query = "SELECT TOP 1 Product.Name, Shipment.Quantity FROM Product JOIN Shipment ON Shipment.ProductId = Product.Id ORDER BY Shipment.Quantity ASC";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        Console.WriteLine("Min Quantity:");
                                        while (reader.Read())
                                        {
                                            Console.Write($"{reader["Name"]}|{reader["Quantity"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "6":
                                query = "SELECT TOP 1 Name, Price FROM Product ORDER BY Price ASC";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        Console.WriteLine("Min Price:");
                                        while (reader.Read())
                                        {
                                            Console.Write($"{reader["Name"]}|{reader["Price"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "7":
                                query = "SELECT TOP 1 Name, Price FROM Product ORDER BY Price DESC";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        Console.WriteLine("Max Price:");
                                        while (reader.Read())
                                        {
                                            Console.Write($"{reader["Name"]}|{reader["Price"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "8":
                                Console.WriteLine("Enter type:");
                                string type = Console.ReadLine();


                                query = $"SELECT Id,Name, [Type], Price FROM Product WHERE [Type] LIKE '{type}'";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        if (!reader.HasRows)
                                        {
                                            Console.Write($"No items found with this type");
                                        }
                                        else
                                            while (reader.Read())
                                            {
                                                Console.Write($"{reader["Id"]}|{reader["Name"]}|{reader["Price"]}");
                                            }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "9":
                                Console.WriteLine("Enter producer:");
                                string producer = Console.ReadLine();


                                query = $"SELECT Id,Name, Shipment.Producer, Price FROM Product JOIN Shipment ON Shipment.ProductId = Product.Id WHERE Shipment.Producer LIKE '{producer}'";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        if (!reader.HasRows)
                                        {
                                            Console.Write($"No items found from this producer");
                                        }
                                        else
                                            while (reader.Read())
                                            {
                                                Console.Write($"{reader["Id"]}|{reader["Name"]}|{reader["Price"]}");
                                            }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "10":

                                query = "SELECT TOP 1 Id, Name, ShipmentDate FROM Product JOIN Shipment ON ProductId = Product.Id ORDER BY ShipmentDate  ASC";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            Console.Write($"{reader["Id"]}|{reader["Name"]}|{reader["ShipmentDate"]}");
                                        }

                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "11":

                                query = "SELECT [Type], AVG(Quantity) AS AverageQua FROM Product JOIN Shipment ON ProductId = Product.Id GROUP BY [Type]";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["Type"]}|{reader["AverageQua"]}");
                                        }

                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "i":
                                Console.WriteLine("What values to insert?(Separate with spaces)");
                                string values_string = Console.ReadLine();
                                string[] values = values_string.Split(' ');

                                string values_final = "(";
                                for (int i = 0; i < values.Length; i++)
                                {
                                    if (i > 0) values_final += ",";
                                    values_final += $" '{values[i]}'";
                                }

                                values_final += ")";
                                query = $"INSERT INTO Students VALUES {values_final}";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    try
                                    {
                                        connection.Open();
                                        using (SqlCommand cmd = new SqlCommand(query, connection))
                                        {
                                            cmd.ExecuteReader().Close();
                                            Console.WriteLine("Inserted data seccesfully");
                                        }
                                    }
                                    catch (Exception ex) { Console.WriteLine("Error while inserting data; Error: " + ex.Message); }
                                }
                                Console.ReadKey();
                                break;
                            case "d":
                                Console.WriteLine("Delete all data or a single row(by Id)?(0 = All/ 1 = One row)");
                                responce = Console.ReadLine();
                                string target;
                                if (responce == "0")
                                {
                                    query = "DELETE FROM Students";
                                }
                                else if (responce == "1")
                                {
                                    Console.WriteLine("Id of a row you'd like to delete:");
                                    target = Console.ReadLine();
                                    query = $"DELETE FROM Students WHERE [ID] = {target}";

                                }
                                else
                                {
                                    Console.WriteLine("Invalid answer"); Console.ReadKey();
                                    continue;

                                }

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    try
                                    {
                                        connection.Open();
                                        using (SqlCommand cmd = new SqlCommand(query, connection))
                                        {
                                            cmd.ExecuteReader().Close();
                                            Console.WriteLine("Deleted data seccesfully");
                                        }
                                    }
                                    catch (Exception ex) { Console.WriteLine("Error while deleting data; Error: " + ex.Message); }
                                }
                                Console.ReadKey();
                                break;
                            case "0":
                                exit = true;
                                break;
                            default: break;
                        }

                    }





                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while connecting to [Warehouse]; Error: " + ex.Message);

                }
            }
            else
            {
                Console.WriteLine("Connection terminated");

            }

        }
    }
}
