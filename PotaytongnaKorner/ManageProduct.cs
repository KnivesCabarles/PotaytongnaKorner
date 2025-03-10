using System;
using MySql.Data.MySqlClient;

namespace PotaytongNaKorner
{
    class ManageProduct
    {
        private string server = "localhost";
        private string database = "potaytong_db";
        private string username = "root";
        private string password = "";
        private string connString;

        public ManageProduct()
        {
            connString = $"Server={server};Database={database};User ID={username};Password={password};";
        }

        public void InsertProduct(string productName, decimal productPrice)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connected to MySQL!");

                    string query = "INSERT INTO products (name, price) VALUES (@name, @price)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", productName);
                        cmd.Parameters.AddWithValue("@price", productPrice);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        Console.WriteLine(rowsAffected > 0 ? "Product added successfully!" : "Failed to add product.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public void DisplayProducts()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM products";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Products List:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Price: P{reader["price"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
