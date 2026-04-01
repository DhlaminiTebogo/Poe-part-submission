// ConsoleUIMethods.cs - Handles all console output formatting and color styling

namespace ConsoleApp1;

using System;

public class ConsoleUIMethods
{
    // PrintBanner - displays the ASCII art logo in green at the start of the app
    public static void PrintBanner()
    {
        // Set text color to green for the banner
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("==============================================");

        // Print the ASCII art logo
        Console.WriteLine(@"
   ___        _  |__   ___   _ |__    ___  | |_
  / /| | | | '_\ / _ \ '__| '_\ / _ \| __|
 / /_| |_| | |_) | (_) | |  | |_) | (_) | |_
/____\__,_|_.__/ \___/|_|  |_.__/ \___/ \__|
        |___/
        ");
        Console.WriteLine("==============================================");

        // Reset color back to default
        Console.ResetColor();
    }

    // PrintBot - displays a message from the bot in cyan
    public static void PrintBot(string message)
    {
        // Print "Bot: " label in cyan
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Bot: ");

        // Reset color and print the actual message in default color
        Console.ResetColor();
        Console.WriteLine(message);
    }

    // PrintUser - displays the "You: " prompt in yellow to indicate user input
    public static void PrintUser()
    {
        // Print "You: " label in yellow
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("You: ");

        // Reset color so the user's typed input appears in default color
        Console.ResetColor();
    }

    // PrintError - displays an error or unrecognised input message in red
    public static void PrintError(string message)
    {
        // Print the error message in red
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);

        // Reset color back to default
        Console.ResetColor();
    }

    // PrintDivider - prints a horizontal line in dark cyan to separate sections
    public static void PrintDivider()
    {
        // Print the divider line in dark cyan
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("--------------------------------------------");

        // Reset color back to default
        Console.ResetColor();
    }
}