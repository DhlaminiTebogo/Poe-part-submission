// BotResponses.cs - Handles keyword matching and generates appropriate responses

using System;

namespace ConsoleApp1
{
    public class BotResponses
    {
        // GetResponse - takes user input and returns the appropriate response string
        // Returns "QUIT" if the user wants to exit, "" if input is not recognised
        public string GetResponse(string input)
        {
            // Return empty string if input is null or whitespace
            if (string.IsNullOrWhiteSpace(input))
                return "";

            // Convert input to lowercase for case-insensitive keyword matching
            string lower = input.ToLower().Trim();

            // Respond to greetings about the bot's status
            if (lower.Contains("how are you"))
                return "I'm fully operational and scanning for threats! Thanks for asking.";

            // Respond to questions about the bot's purpose
            else if (lower.Contains("purpose") || lower.Contains("what do you do"))
                return "I'm your Cybersecurity Awareness Bot! I help you stay safe online.";

            // Show the menu if user asks for help or selects a numbered option
            else if (lower.Contains("help") || lower.Contains("what can i ask") ||
                     lower == "1" || lower == "2" || lower == "3")
                return GetMenuResponse(lower);

            // Respond to password-related questions
            else if (lower.Contains("password"))
                return "Use at least 12 characters, mix letters, numbers and symbols. Never reuse passwords.\n\n" + GetMenu();

            // Respond to phishing or scam-related questions
            else if (lower.Contains("phishing") || lower.Contains("scam"))
                return "Never click links in unexpected emails. Always verify the sender and go directly to websites instead.\n\n" + GetMenu();

            // Respond to safe browsing questions
            else if (lower.Contains("browsing") || lower.Contains("internet"))
                return "Always use HTTPS, avoid public Wi-Fi for sensitive tasks, and keep your browser updated.\n\n" + GetMenu();

            // Signal the bot to exit when user says goodbye
            else if (lower.Contains("bye") || lower.Contains("exit") || lower.Contains("quit"))
                return "QUIT";

            // Return empty string if no keyword matched
            else
                return "";
        }

        // GetMenuResponse - returns the appropriate topic response based on
        // the user's menu selection or keyword
        private string GetMenuResponse(string lower)
        {
            // Option 1 or password keyword - return password safety advice
            if (lower == "1" || lower.Contains("password"))
                return "Use at least 12 characters, mix letters, numbers and symbols. Never reuse passwords.\n\n" + GetMenu();

            // Option 2 or phishing keyword - return phishing advice
            else if (lower == "2" || lower.Contains("phishing"))
                return "Never click links in unexpected emails. Always verify the sender and go directly to websites instead.\n\n" + GetMenu();

            // Option 3 or browsing keyword - return safe browsing advice
            else if (lower == "3" || lower.Contains("browsing"))
                return "Always use HTTPS, avoid public Wi-Fi for sensitive tasks, and keep your browser updated.\n\n" + GetMenu();

            // If only 'help' was typed, just show the menu
            else
                return GetMenu();
        }

        // GetMenu - returns the formatted menu options string
        private string GetMenu()
        {
            return "What would you like to know about?\n  1) Password safety\n  2) Phishing\n  3) Safe browsing";
        }
    }
}   