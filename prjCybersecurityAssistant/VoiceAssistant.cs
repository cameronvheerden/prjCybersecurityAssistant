using System.Media;//(O'Didily, 2022)
using System.Speech.Synthesis;

namespace prjCybersecurityAssistant
{

    // Abstract base class providing voice, sound, and user input features for chatbot assistants.
    // Handles speech synthesis, typing effect, sound playback, and input collection.

    public abstract class VoiceAssistant
    {
        private readonly SpeechSynthesizer _ss;//(Manson, 2014)    

        //Initializes the speech synthesizer and sets the preferred voice if available.
        public VoiceAssistant()
        {
            _ss = new SpeechSynthesizer();//(Manson, 2014)

            try
            {
                _ss.SetOutputToDefaultAudioDevice();//(Manson, 2014)
                _ss.Rate = 1; //(Manson, 2014) Moderate speed

                var preferredVoice = "Microsoft Hazel Desktop";//(Opus), 2013)
                bool voiceFound = false;//(Opus), 2013)

                foreach (var voice in _ss.GetInstalledVoices())//(Opus), 2013)
                {
                    if (voice.Enabled && voice.VoiceInfo.Name.Equals(preferredVoice, StringComparison.OrdinalIgnoreCase))//(Opus), 2013)
                    {
                        _ss.SelectVoice(preferredVoice);//(Opus), 2013)
                        voiceFound = true;//(Opus), 2013)
                        break;
                    }
                }

                if (!voiceFound)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Preferred voice not found. Using default voice.");
                    Console.ResetColor();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error initializing speech: " + e.Message);
                Console.ResetColor();
            }
        }

        // Simulates a typing effect, adds a pause, and then speaks the text out loud.
        //Text to display and speak.
        //Console color for the text.
        //Delay per character in ms.
        //Pause after text in ms before speaking.
        public virtual void Speak(string text, ConsoleColor color = ConsoleColor.DarkMagenta, int typingDelay = 30, int pauseAfter = 300)//(Manson, 2014)
        {
            Console.ForegroundColor = color;

            foreach (char c in text)//(Manson, 2014)
            {
                Console.Write(c);//(Manson, 2014)
                Thread.Sleep(typingDelay);//(Manson, 2014)
            }

            Console.WriteLine();
            Thread.Sleep(pauseAfter);//(Manson, 2014)
            _ss.Speak(text);//(Manson, 2014)
            Console.ResetColor();
        }


        // Prompts the user for input, ensuring a non-empty response.
        //Prompt text for the user.
        //User input in lowercase.
        public static string GetUserInput(string prompt = "You: ", bool allowSkip = false)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(prompt);
                Console.ResetColor();

                string input = Console.ReadLine()?.Trim();

                // If skipping is allowed, return empty input
                if (allowSkip || !string.IsNullOrWhiteSpace(input))
                {
                    return input?.ToLower(); // Return input (or empty) in lowercase
                }

                // If not allowed and input is empty, ask again
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please enter something to continue...");
                Console.ResetColor();
            }
        }


        // Plays a sound file synchronously and adds a short delay after playback.
        //Path to the sound file.
        //True if playback succeeds, false otherwise.
        public bool PlaySound(string filename)//(O'Didily, 2022)
        {
            try
            {
                // Use SoundPlayer to play the specified sound file
                using SoundPlayer player =  new SoundPlayer();//(O'Didily, 2022)
                player.SoundLocation = filename;//(O'Didily, 2022)
                player.PlaySync();//(O'Didily, 2022) Changed to PlaySync for synchronous playback
                Thread.Sleep(1000); // Add a 1 second delay after the sound is played
                return true;
            }
            catch (Exception ex)
            {
                // Handle errors during sound playback
                Speak($"I think I might have forgotten what sound to play; let me get back to you once my memory comes back: {filename}.", ConsoleColor.Red);//(O'Didily, 2022)
                Console.WriteLine($"Error playing sound: {ex.Message}", ConsoleColor.Red);//(O'Didily, 2022)
                return false;
            }
        }
    }
}
