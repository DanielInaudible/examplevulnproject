using System;
using System.IO;
using System.Text.RegularExpressions;

namespace VulnProjectDemo
{
    public static class Vuln2_PathTraversal
    {
        public static string ReadFileVulnerable(string fileName)
        {
            string fullPath = Path.Combine("data", fileName);
            return File.ReadAllText(fullPath);
        }
        public static void Demo()
        {
            Console.WriteLine("=== Path Traversal ===");
            Console.Write("Enter a file name: ");
            string input = Console.ReadLine() ?? "";

            try
            {
                string result = ReadFileVulnerable(input);
                Console.WriteLine("\n result");
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error " + ex.Message);
            }
        }
    }
}
