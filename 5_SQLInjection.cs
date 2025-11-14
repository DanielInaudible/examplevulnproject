using System;
using Microsoft.Data.Sqlite;

namespace VulnProjectDemo
{
    public static class Vuln5_SQLInjection
    {
        // VULNERABLE – concatenates user input into SQL
        public static void QueryVulnerable(string username)
        {
            using var conn = new SqliteConnection("Data Source=:memory:");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "CREATE TABLE users(name TEXT); INSERT INTO users VALUES('alice');";
            cmd.ExecuteNonQuery();

            // BAD: direct concatenation -> SQL injection
            cmd.CommandText = $"SELECT name FROM users WHERE name = '{username}'";
            using var reader = cmd.ExecuteReader();
            var found = false;
            while (reader.Read())
            {
                Console.WriteLine($"Found: {reader.GetString(0)}");
                found = true;
            }

            if (!found) Console.WriteLine("No results.");
        }

        // Secure – parameterized query
        public static void QuerySecure(string username)
        {
            using var conn = new SqliteConnection("Data Source=:memory:");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "CREATE TABLE users(name TEXT); INSERT INTO users VALUES('alice');";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "SELECT name FROM users WHERE name = @u";
            cmd.Parameters.AddWithValue("@u", username);
            using var reader = cmd.ExecuteReader();
            var found = false;
            while (reader.Read())
            {
                Console.WriteLine($"Found (safe): {reader.GetString(0)}");
                found = true;
            }

            if (!found) Console.WriteLine("No results.");
        }

        public static void Demo()
        {
            Console.WriteLine("=== SQL Injection Demo ===");
            Console.Write("Enter username (try alice or ' OR 1=1 -- ): ");
            var input = Console.ReadLine() ?? "";
            Console.WriteLine("[Vulnerable query results]");
            QueryVulnerable(input);
        }
    }
}
