namespace ConsoleApp1;

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a new instance of the Bot class
        var bot = new Bot();

        // Start the bot - this launches the chat loop
        bot.Start();
    }
}