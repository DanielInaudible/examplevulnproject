using System;

namespace VulnProjectDemo
{
    public static class Vuln1_HardcodedPassword
    {
        public static bool AuthenticateVulnerable(string user, string pass)
        {
            // password = 'SuperSecret123'
            const string PASSWORD = "SuperSecret123";
            return user == "admin" && pass == PASSWORD;
        }

        public static void Demo()
        {
            Console.WriteLine("=== Hardcoded Password ===");
            Console.Write("Username: ");
            var u = Console.ReadLine() ?? "";
            Console.Write("Password: ");
            var p = Console.ReadLine() ?? "";

            if (AuthenticateVulnerable(u, p)){
                Console.WriteLine("Authenticated (vulnerable path!)");
            }
            else{
                Console.WriteLine("Access denied");
            }

        }
    }
}
