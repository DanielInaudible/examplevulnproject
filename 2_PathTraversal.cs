using System;
using System.IO;

namespace VulnProjectDemo
{
    public static class Vuln2_PathTraversal
    {
        // Vulnerable – attacker can controls filename -> directory traversal
        public static string ReadFileVulnerable(string fileName)
        {
            // VULNERABLE: attacker can enter ../../ to escape "data/" folder. PATH TRAVERSAL
            string fullPath = Path.Combine("data", fileName);
            return File.ReadAllText(fullPath);
        }

        // Secure – normalize + restrict path
        public static string? ReadFileSecure(string fileName)
        {
            string baseDir = Path.GetFullPath("data");
            string target = Path.GetFullPath(Path.Combine(baseDir, fileName));

            if (!target.StartsWith(baseDir))
                return null; // blocked traversal

            return File.Exists(target) ? File.ReadAllText(target) : null;
        }

        public static void Demo()
        {
            Console.WriteLine("=== Path Traversal Demo ===");
            Console.Write("Enter a file name: ");
            string input = Console.ReadLine() ?? "";

            try
            {
                string result = ReadFileVulnerable(input);
                Console.WriteLine("\n[VULNERABLE RESULT]");
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] " + ex.Message);
            }
        }
    }
}
