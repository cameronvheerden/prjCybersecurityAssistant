using System.Speech.Synthesis;

namespace prjCybersecurityAssistant
{
    public class CyberSecurity : VoiceAssistant
    {
        // Random instance for generating random responses from the assistant
        private readonly Random _random;

        //Dictionary to hold cyber-related da
        Dictionary<string, string> cyber = new();

        public void mainMenu()
        {
            Speak("Welcome Back to Your Wild Adventure of Exploring the dangers of the Cyber Forest!");
            Console.ReadLine();
        }

        


    }
}
