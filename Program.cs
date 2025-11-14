using System;

namespace VulnProjectDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("=== Vulnerable Project Demo ===");
            Console.WriteLine("Select a demo to run (1-5):");
            Console.WriteLine("1 - Hardcoded Password");
            Console.WriteLine("2 - Path Traversal");
            Console.WriteLine("3 - Command Injection");
            Console.WriteLine("4 - Cryptographic Weakness");
            Console.WriteLine("5 - SQL Injection");
            Console.Write("> ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Vuln1_HardcodedPassword.Demo();
                    break;
                case "2":
                    Vuln2_PathTraversal.Demo();
                    break;
                case "3":
                    Vuln3_CommandInjection.Demo();
                    break;
                case "4":
                    Vuln4_CryptoWeakness.Demo();
                    break;
                case "5":
                    Vuln5_SQLInjection.Demo();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
