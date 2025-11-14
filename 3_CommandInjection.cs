using System;
using System.Diagnostics;
using System.Linq;

namespace VulnProjectDemo
{
    public static class Vuln3_CommandInjection
    {
        // ============================
        //  VULNERABLE VERSION
        // ============================
        public static void ListDirectoryVulnerable(string dirArgs)
        {
            // VULNERABLE – attacker can input:  /q & calc.exe
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
            Console.WriteLine("=== Command Injection Demo (VULNERABLE) ===");
            Console.Write("Enter dir arguments: ");
            string args = Console.ReadLine() ?? "";

            ListDirectoryVulnerable(args);
        }

        /// SECURE – blocks injection characters & only allows valid dir arguments (e.g. /A, /S, /B, /Q etc.)
        public static void ListDirectorySecure(string dirArgs)
        {
            // Disallowed characters that enable command injection
            char[] dangerousChars = { '&', '|', ';', '>', '<', '%', '$', '`' };

            if (dirArgs.IndexOfAny(dangerousChars) != -1)
            {
                Console.WriteLine("\n[SECURE] BLOCKED: Suspicious characters detected.");
                return;
            }

            // OPTIONAL: allowlist valid dir switches
            string[] allowed = { "/A", "/B", "/S", "/Q", "/O", "/T", "/W" };

            // Check if it's empty or starts with a valid switch
            if (!string.IsNullOrWhiteSpace(dirArgs))
            {
                if (!allowed.Any(d => dirArgs.Trim().StartsWith(d, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("\n[SECURE] BLOCKED: Argument not in allowlist.");
                    return;
                }
            }

            string fullCommand = "/C dir " + dirArgs.Trim();

            Console.WriteLine("\n[DEBUG - SECURE] FULL COMMAND SENT TO CMD.EXE:");
            Console.WriteLine("cmd.exe " + fullCommand + "\n");

            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = fullCommand,
                UseShellExecute = false
            };

            Process.Start(psi);
        }

        public static void DemoSecure()
        {
            Console.WriteLine("=== SAFE Command Execution Demo (SECURE) ===");
            Console.Write("Enter dir arguments: ");
            string args = Console.ReadLine() ?? "";

            ListDirectorySecure(args);
        }
    }
}
