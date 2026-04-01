// Bot.cs - Manages the main chat loop and user interaction flow

using System;

namespace ConsoleApp1
{
    public class Bot
    {
        // Engine that processes user input and returns appropriate responses
        private readonly BotResponses _engine = new BotResponses();

        // Stores the user's name, defaults to "User" if none is provided
        private string _userName = "User";

        // Default constructor
        public Bot()
        {
        }

        // Start - launches the bot and runs the main conversation loop
        public void Start()
        {
            // Display the ASCII art banner
            ConsoleUIMethods.PrintBanner();

            // Play the audio greeting if the file exists
            AudioGreeting.PlayGreeting("AudioGreeting.wav");

            // Prompt the user to enter their name
            ConsoleUIMethods.PrintDivider();
            ConsoleUIMethods.PrintBot("Hello! What is your name?");
            ConsoleUIMethods.PrintUser();

            // Read and store the user's name if provided
            string? name = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(name))
                _userName = name;

            // Greet the user by name and show available commands
            ConsoleUIMethods.PrintDivider();
            ConsoleUIMethods.PrintBot($"Nice to meet you, {_userName}! Type 'help' to see what I can do, or 'bye' to exit.");
            ConsoleUIMethods.PrintDivider();

            // Main chat loop - runs until the user types 'bye', 'exit', or 'quit'
            while (true)
            {
                Console.WriteLine();
                ConsoleUIMethods.PrintUser();

                // Read user input
                string? input = Console.ReadLine();

                // Handle empty input
                if (string.IsNullOrWhiteSpace(input))
                {
                    ConsoleUIMethods.PrintError("I didn't understand that. Could you rephrase?");
                    continue;
                }

                // Get response from the bot engine
                string response = _engine.GetResponse(input);

                if (response == "QUIT")
                {
                    // User wants to exit - say goodbye and break the loop
                    ConsoleUIMethods.PrintDivider();
                    ConsoleUIMethods.PrintBot($"Stay safe online, {_userName}! Goodbye!");
                    ConsoleUIMethods.PrintDivider();
                    break;
                }
                else if (response == "")
                {
                    // Bot didn't recognise the input
                    ConsoleUIMethods.PrintError($"I didn't quite understand that, {_userName}. Could you rephrase?");
                }
                else
                {
                    // Print the bot's response
                    ConsoleUIMethods.PrintBot(response);
                }
            }
        }
    }
}