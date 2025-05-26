using System.Media;
using System.Speech.Synthesis;

namespace prjCybersecurityAssistant
{
    public class VoiceAssistant
    {
        private readonly SpeechSynthesizer _ss;    

        public VoiceAssistant()
        {
            _ss = new SpeechSynthesizer();

            try
            {
                _ss.SetOutputToDefaultAudioDevice();
                _ss.Rate = 1; // Moderate speed

                var preferredVoice = "Microsoft Hazel Desktop";
                bool voiceFound = false;

                foreach (var voice in _ss.GetInstalledVoices())
                {
                    if (voice.Enabled && voice.VoiceInfo.Name.Equals(preferredVoice, StringComparison.OrdinalIgnoreCase))
                    {
                        _ss.SelectVoice(preferredVoice);
                        voiceFound = true;
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

        // Simulates a typing effect and adds conversational pauses before speaking
        public void Speak(string text, ConsoleColor color = ConsoleColor.White, int typingDelay = 30, int pauseAfter = 300)
        {
            Console.ForegroundColor = color;

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(typingDelay);
            }

            Console.WriteLine();
            Thread.Sleep(pauseAfter);
            _ss.SpeakAsync(text);
            Console.ResetColor();
        }

        public static string GetUserInput(string prompt = "You: ")
        {
            string input;

            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(prompt);
                Console.ResetColor();

                input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please enter something to continue...");
                    Console.ResetColor();
                }

            } while (string.IsNullOrWhiteSpace(input));

            return input.ToLower(); // Optional: return lowercase for keyword matching
        }



        // Method to play a sound file
        public bool PlaySound(string filename)//(O'Didily, 2022)
        {
            try
            {
                // Use SoundPlayer to play the specified sound file
                using SoundPlayer player = new SoundPlayer();//(O'Didily, 2022)
                player.SoundLocation = filename;//(O'Didily, 2022)
                player.PlaySync();//(O'Didily, 2022) Changed to PlaySync for synchronous playback
                return true;//
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
