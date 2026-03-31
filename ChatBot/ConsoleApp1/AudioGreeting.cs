using System;
using System.IO;
using System.Media;

namespace ConsoleApp1
{
    public class AudioGreeting
    {
        public static void PlayGreeting(string filePath = "AudioGreeting.wav")
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using var player = new SoundPlayer(filePath);
                    player.PlaySync();
                }
                else
                {
                    ConsoleUIMethods.PrintError("Greeting file not found");
                }
            }
            catch
            {
                ConsoleUIMethods.PrintError("Audio playback error");
            }
        }
    }
}
