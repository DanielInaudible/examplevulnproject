using System;
using System.Diagnostics;
using System.Linq;

namespace VulnProjectDemo
{
    public static class Vuln3_CommandInjection
    {
        public static void ListDirectoryVulnerable(string dirArgs)
        {
            string fullCommand = "/C dir " + dirArgs;

            Console.WriteLine("\n[DEBUG - VULNERABLE] FULL COMMAND SENT TO CMD.EXE:");
            Console.WriteLine("cmd.exe " + fullCommand + "\n");

            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = fullCommand,
                UseShellExecute = false
            };

            Process.Start(psi);
        }

        public static void Demo()
        {
            Console.WriteLine("=== Command Injection ===");
            Console.Write("Enter dir arguments: ");
            string args = Console.ReadLine() ?? "";

            ListDirectoryVulnerable(args);
        }
    }
}
