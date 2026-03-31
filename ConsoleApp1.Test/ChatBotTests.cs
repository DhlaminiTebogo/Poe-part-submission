using System;
using Xunit;
using ConsoleApp1;

namespace ConsoleApp1.Tests
{
    public class BotResponsesTests
    {
        private readonly BotResponses _bot = new BotResponses();

        [Fact]
        public void GetResponse_EmptyInput_ReturnsEmpty()
        {
            Assert.Equal("", _bot.GetResponse(""));
            Assert.Equal("", _bot.GetResponse("   "));
        }

        [Fact]
        public void GetResponse_HowAreYou_ReturnsOperationalMessage()
        {
            string response = _bot.GetResponse("how are you");
            Assert.Contains("operational", response, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void GetResponse_Purpose_ReturnsPurposeMessage()
        {
            string response = _bot.GetResponse("what do you do");
            Assert.Contains("Cybersecurity", response, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void GetResponse_Help_ReturnsMenu()
        {
            string response = _bot.GetResponse("help");
            Assert.Contains("1)", response);
            Assert.Contains("2)", response);
            Assert.Contains("3)", response);
        }

        [Fact]
        public void GetResponse_Option1_ReturnsPasswordInfoAndMenu()
        {
            string response = _bot.GetResponse("1");
            Assert.Contains("12 characters", response, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("1)", response);
        }

        [Fact]
        public void GetResponse_Option2_ReturnsPhishingInfoAndMenu()
        {
            string response = _bot.GetResponse("2");
            Assert.Contains("email", response, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("1)", response);
        }

        [Fact]
        public void GetResponse_Option3_ReturnsBrowsingInfoAndMenu()
        {
            string response = _bot.GetResponse("3");
            Assert.Contains("HTTPS", response, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("1)", response);
        }

        [Fact]
        public void GetResponse_Password_ReturnsAdviceAndMenu()
        {
            string response = _bot.GetResponse("password");
            Assert.Contains("12 characters", response, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("1)", response);
        }

        [Fact]
        public void GetResponse_Phishing_ReturnsAdviceAndMenu()
        {
            string response = _bot.GetResponse("phishing");
            Assert.Contains("email", response, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("1)", response);
        }

        [Fact]
        public void GetResponse_Browsing_ReturnsAdviceAndMenu()
        {
            string response = _bot.GetResponse("browsing");
            Assert.Contains("HTTPS", response, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("1)", response);
        }

        [Fact]
        public void GetResponse_Bye_ReturnsQuit()
        {
            Assert.Equal("QUIT", _bot.GetResponse("bye"));
            Assert.Equal("QUIT", _bot.GetResponse("exit"));
            Assert.Equal("QUIT", _bot.GetResponse("quit"));
        }

        [Fact]
        public void GetResponse_Unknown_ReturnsEmpty()
        {
            string response = _bot.GetResponse("xyzabc123");
            Assert.Equal("", response);
        }
    }

    public class AudioGreetingTests
    {
        [Fact]
        public void PlayGreeting_FileNotFound_DoesNotThrow()
        {
            // AudioGreeting handles missing files gracefully via try/catch
            var exception = Record.Exception(() =>
                AudioGreeting.PlayGreeting("nonexistent.wav"));
            Assert.Null(exception);
        }

        [Fact]
        public void PlayGreeting_NoArgument_DoesNotThrow()
        {
            // Uses default parameter "AudioGreeting.wav"
            var exception = Record.Exception(() =>
                AudioGreeting.PlayGreeting());
            Assert.Null(exception);
        }
    }

    public class ConsoleUIMethodsTests
    {
        [Fact]
        public void PrintBanner_DoesNotThrow()
        {
            var exception = Record.Exception(() =>
                ConsoleUIMethods.PrintBanner());
            Assert.Null(exception);
        }

        [Fact]
        public void PrintDivider_DoesNotThrow()
        {
            var exception = Record.Exception(() =>
                ConsoleUIMethods.PrintDivider());
            Assert.Null(exception);
        }

        [Fact]
        public void PrintBot_DoesNotThrow()
        {
            var exception = Record.Exception(() =>
                ConsoleUIMethods.PrintBot("Test message"));
            Assert.Null(exception);
        }

        [Fact]
        public void PrintUser_DoesNotThrow()
        {
            var exception = Record.Exception(() =>
                ConsoleUIMethods.PrintUser());
            Assert.Null(exception);
        }

        [Fact]
        public void PrintError_DoesNotThrow()
        {
            var exception = Record.Exception(() =>
                ConsoleUIMethods.PrintError("Test error"));
            Assert.Null(exception);
        }
    }
}