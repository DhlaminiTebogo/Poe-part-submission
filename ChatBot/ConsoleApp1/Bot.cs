using System;

namespace ConsoleApp1
{
    public class Bot
    {
        private readonly BotResponses _engine = new BotResponses();
        private string _userName = "User";

        public Bot()
        {
        }

        public void Start()
        {
            ConsoleUIMethods.PrintBanner();

            AudioGreeting.PlayGreeting("AudioGreeting.wav");

            ConsoleUIMethods.PrintDivider();
            ConsoleUIMethods.PrintBot("Hello! What is your name?");
            ConsoleUIMethods.PrintUser();

            string? name = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(name))
                _userName = name;

            ConsoleUIMethods.PrintDivider();
            ConsoleUIMethods.PrintBot($"Nice to meet you, {_userName}! Type 'help' to see what I can do, or 'bye' to exit.");
            ConsoleUIMethods.PrintDivider();

            while (true)
            {
                Console.WriteLine();
                ConsoleUIMethods.PrintUser();
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    ConsoleUIMethods.PrintError("I didn't understand that. Could you rephrase?");
                    continue;
                }

                string response = _engine.GetResponse(input);

                if (response == "QUIT")
                {
                    ConsoleUIMethods.PrintDivider();
                    ConsoleUIMethods.PrintBot($"Stay safe online, {_userName}! Goodbye!");
                    ConsoleUIMethods.PrintDivider();
                    break;
                }
                else if (response == "")
                {
                    ConsoleUIMethods.PrintError($"I didn't quite understand that, {_userName}. Could you rephrase?");
                }
                else
                {
                    ConsoleUIMethods.PrintBot(response);
                }
            }
        }
    }
}