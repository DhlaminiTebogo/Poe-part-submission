using System;

namespace ConsoleApp1
{
    public class BotResponses
    {
        public string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "";

            string lower = input.ToLower().Trim();

            if (lower.Contains("how are you"))
                return "I'm fully operational and scanning for threats! Thanks for asking.";

            else if (lower.Contains("purpose") || lower.Contains("what do you do"))
                return "I'm your Cybersecurity Awareness Bot! I help you stay safe online.";

            else if (lower.Contains("help") || lower.Contains("what can i ask") ||
                     lower == "1" || lower == "2" || lower == "3")
                return GetMenuResponse(lower);

            else if (lower.Contains("password"))
                return "Use at least 12 characters, mix letters, numbers and symbols. Never reuse passwords.\n\n" + GetMenu();

            else if (lower.Contains("phishing") || lower.Contains("scam"))
                return "Never click links in unexpected emails. Always verify the sender and go directly to websites instead.\n\n" + GetMenu();

            else if (lower.Contains("browsing") || lower.Contains("internet"))
                return "Always use HTTPS, avoid public Wi-Fi for sensitive tasks, and keep your browser updated.\n\n" + GetMenu();

            else if (lower.Contains("bye") || lower.Contains("exit") || lower.Contains("quit"))
                return "QUIT";

            else
                return "";
        }

        private string GetMenuResponse(string lower)
        {
            if (lower == "1" || lower.Contains("password"))
                return "Use at least 12 characters, mix letters, numbers and symbols. Never reuse passwords.\n\n" + GetMenu();

            else if (lower == "2" || lower.Contains("phishing"))
                return "Never click links in unexpected emails. Always verify the sender and go directly to websites instead.\n\n" + GetMenu();

            else if (lower == "3" || lower.Contains("browsing"))
                return "Always use HTTPS, avoid public Wi-Fi for sensitive tasks, and keep your browser updated.\n\n" + GetMenu();

            else
                return GetMenu();
        }

        private string GetMenu()
        {
            return "What would you like to know about?\n  1) Password safety\n  2) Phishing\n  3) Safe browsing";
        }
    }
}