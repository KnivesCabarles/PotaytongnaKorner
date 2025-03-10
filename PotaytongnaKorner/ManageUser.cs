using System;
using MySql.Data.MySqlClient;

namespace PotaytongNaKorner
{
    class ManageUser
    {
        private string server = "localhost";
        private string database = "potaytong_db";
        private string username = "root";
        private string password = "";
        private string connString;

        public ManageUser()
        {
            connString = $"Server={server};Database={database};User ID={username};Password={password};";
        }

        public bool Login(string user, string pass)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM users WHERE username = @user AND password = @pass";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", user);
                        cmd.Parameters.AddWithValue("@pass", pass);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            return reader.Read(); // Returns true if user exists
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        public bool Register(string user, string pass)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO users (username, password) VALUES (@user, @pass)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", user);
                        cmd.Parameters.AddWithValue("@pass", pass);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
