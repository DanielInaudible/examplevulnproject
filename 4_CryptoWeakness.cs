using System;
using System.Security.Cryptography;
using System.Text;

namespace VulnProjectDemo
{
    public static class Vuln4_CryptoWeakness
    {
        public static string HashPasswordVulnerable(string password)
        {
            using var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(hash);
        }

        public static int GenerateCodeVulnerable()
        {
            var rnd = new Random();
            return rnd.Next(100000, 999999);
        }

        public static void Demo()
        {
            Console.WriteLine("=== Cryptographic Weakness ===");

            Console.Write("Enter a password to hash: ");
            string password = Console.ReadLine() ?? "";

            Console.WriteLine("\nHash");
            Console.WriteLine(HashPasswordVulnerable(password));

            Console.WriteLine("\nRandom num.");
            Console.WriteLine(GenerateCodeVulnerable());
        }
    }
}
