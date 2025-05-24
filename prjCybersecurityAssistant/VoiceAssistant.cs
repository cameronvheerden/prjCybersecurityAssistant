using System.Media;//(George, 2023)
using System.Speech.Synthesis;//(Motta, 2023)

namespace prjCybersecurityAssistant
{
    public class VoiceAssistant
    {
        // Speech synthesizer for text-to-speech functionality
        protected SpeechSynthesizer synthesizer = new SpeechSynthesizer();//(Motta, 2023)

        // Constructor to initialize the speech synthesizer
        public VoiceAssistant()
        {
            try
            {
                // Set the synthesizer output to the default audio device
                synthesizer.SetOutputToDefaultAudioDevice();//(Motta, 2023)
            }
            catch (Exception ex)
            {
                // Handle errors during audio device setup
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Audio device setup failed: " + ex.Message);
                Console.ResetColor();
            }
        }

        // Method to speak text with an optional console color
        public string Speak(string text, ConsoleColor color = ConsoleColor.White)//(Motta, 2023)
        {
            // Set console text color
            Console.ForegroundColor = color;

            // Simulate typing effect by printing characters one by one
            foreach (char c in text)//(Motta, 2023)
            {
                Console.Write(c);//(Motta, 2023)
                Thread.Sleep(20); // Delay for typing effect//(Motta, 2023)
            }

            // Print a new line and reset console color
            Console.WriteLine();
            Console.ResetColor();

            try
            {
                // Use the synthesizer to speak the text asynchronously
                synthesizer.SpeakAsync(text);//(Motta, 2023)
            }
            catch (Exception ex)
            {
                // Handle errors during speech synthesis
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Speech error: " + ex.Message);
                Console.ResetColor();
            }

            return text;
        }

        // Method to get user input and validate it against expected inputs
        public string GetUserInput(string[] expectedInputs)
        {
            string input = string.Empty;

            // Prompt the user for input
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("> ");
            input = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Loop until the input matches one of the expected options
            while (!expectedInputs.Contains(input))
            {
                // Provide feedback for invalid input
                Speak("Oops! Please try again. Make sure your answer matches one of the options.", ConsoleColor.Red);
                Console.Write("> ");
                input = Console.ReadLine()?.ToLower() ?? string.Empty;
            }

            return input;
        }

        // Method to play a sound file
        public bool PlaySound(string filename)
        {
            // Define the base path for sound files
            string basePath = @"C:\Users\vivia\OneDrive\Desktop\vcnmb-prog6221-2025-poe-cameronvanheerden\prjCybersecurityAssistant\prjCybersecurityAssistant\Sounds";//(George, 2023)
            string path = Path.Combine(basePath, filename);//(George, 2023)

            try
            {
                // Use SoundPlayer to play the specified sound file
                using SoundPlayer player = new SoundPlayer(path);//(George, 2023)
                player.Play();//(George, 2023)
                return true;//(George, 2023)
            }
            catch (Exception ex)
            {
                // Handle errors during sound playback
                Speak($"Failed to play {filename}. Error: {ex.Message}", ConsoleColor.Red);//(George, 2023)
                return false;
            }
        }
    }
}
/*
 Reference List
    https://patorjk.com/software/taag/#p=testall&f=Graffiti&t=
    Chand, M., 2023. How to Generate a Random Number and Random String in C#?. [Online] 
   Available at: https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/
   [Accessed 20 April 2025].
   George, A. (. D., 2023. How to: Play a Sound from a Windows Form. [Online] 
   Available at: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-play-a-sound-from-a-windows-form?view=netframeworkdesktop-4.8
   [Accessed 20 April 2025].
   Motta, J., 2023. Using System.Speech with .NET 7. [Online] 
   Available at: https://www.c-sharpcorner.com/article/using-system-speech-with-net-7/#:~:text=In%20this%20article%2C%20I%27ll%20demonstrate%20how%20to%20use,recognition%20and%20text-to-speech%20and%20provides%20a%20unified%20API.
   [Accessed 20 April 2025].
   Troelsen, A. & Japikse, P., 2021. Pro C# 9 with .NET 5: Foundational Principles and Practices in Programming. 10th ed. New York: Apress Berkeley, CA.
*/