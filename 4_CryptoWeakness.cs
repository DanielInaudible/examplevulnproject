using System;
using System.Security.Cryptography;
using System.Text;

namespace VulnProjectDemo
{
    public static class Vuln4_CryptoWeakness
    {
        //
        // Weak Hashing
        //

        // Vulnerable – MD5 hashing
        public static string HashPasswordVulnerable(string password)
        {
            // BAD: MD5 is cryptographically broken
            using var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(hash);
        }

        // Secure – SHA-256 hashing
        public static string HashPasswordSecure(string password)
        {
            using var sha = SHA256.Create();
            var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(hash);
        }

        //
        // Insecure Randomness
        //

        // Vulnerable – predictable RNG (System.Random)
        public static int GenerateCodeVulnerable()
        {
            // BAD: predictable pseudo-random number generator
            var rnd = new Random();
            return rnd.Next(100000, 999999);
        }

        // Secure – cryptographically secure RNG
        public static int GenerateCodeSecure()
        {
            return RandomNumberGenerator.GetInt32(100000, 999999);
        }


        // =========================
        //  DEMO
        // =========================

        public static void Demo()
        {
            Console.WriteLine("=== Cryptographic Weakness Demo ===");

            Console.Write("Enter a password to hash: ");
            string password = Console.ReadLine() ?? "";

            Console.WriteLine("\n[VULNERABLE MD5 HASH]");
            Console.WriteLine(HashPasswordVulnerable(password));

            Console.WriteLine("\n[SECURE SHA256 HASH]");
            Console.WriteLine(HashPasswordSecure(password));

            Console.WriteLine("\n[VULNERABLE RANDOM CODE]");
            Console.WriteLine(GenerateCodeVulnerable());

            Console.WriteLine("\n[SECURE RANDOM CODE]");
            Console.WriteLine(GenerateCodeSecure());
        }
    }
}
