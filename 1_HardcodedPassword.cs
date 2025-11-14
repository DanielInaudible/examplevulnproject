using System;

namespace VulnProjectDemo
{
    public static class Vuln1_HardcodedPassword
    {
        // VULNERABLE – hardcoded password 
        public static bool AuthenticateVulnerable(string user, string pass)
        {
            // password = 'SuperSecret123'
            const string PASSWORD = "SuperSecret123"; // hardcoded secret
            return user == "admin" && pass == PASSWORD;
        }

        // Secure alternative
        public static bool AuthenticateSecure(string user, string pass)
        {
            var PASSWORD = Environment.GetEnvironmentVariable("ADMIN_PASS");
            return user == "admin" && pass == PASSWORD;
        }

        public static void Demo()
        {
            Console.WriteLine("=== Hardcoded Password Demo ===");
            Console.Write("Username: ");
            var u = Console.ReadLine() ?? "";
            Console.Write("Password: ");
            var p = Console.ReadLine() ?? "";

            if (AuthenticateVulnerable(u, p))
                Console.WriteLine("Authenticated (vulnerable path!)");
            else
                Console.WriteLine("Access denied");
        }
    }
}
