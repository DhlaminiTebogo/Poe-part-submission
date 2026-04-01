// AudioGreeting.cs - Handles playing the audio greeting when the bot starts

using System;
using System.IO;
using System.Media;

namespace ConsoleApp1
{
    public class AudioGreeting
    {
        // PlayGreeting - plays a WAV audio file as a greeting when the bot launches
        // filePath defaults to "AudioGreeting.wav" if no path is provided
        public static void PlayGreeting(string filePath = "AudioGreeting.wav")
        {
            try
            {
                // Check if the audio file exists before attempting to play it
                if (File.Exists(filePath))
                {
                    // Create a SoundPlayer and play the file synchronously
                    // PlaySync waits for the audio to finish before continuing
                    using var player = new SoundPlayer(filePath);
                    player.PlaySync();
                }
                else
                {
                    // Notify the user if the audio file could not be found
                    ConsoleUIMethods.PrintError("Greeting file not found");
                }
            }
            catch
            {
                // Handle any unexpected errors during audio playback
                ConsoleUIMethods.PrintError("Audio playback error");
            }
        }
    }
}
