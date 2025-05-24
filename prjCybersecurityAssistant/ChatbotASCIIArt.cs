namespace prjCybersecurityAssistant
{
    public class ChatbotASCIIArt
    {
        // Displays the main header with the chatbot's title and tagline
        public void ShowHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
               ██████╗██╗   ██╗██████╗ ███████╗██████╗ ███████╗███████╗ ██████╗
              ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔════╝██╔════╝██╔════╝
              ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝███████╗█████╗  ██║     
              ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗╚════██║██╔══╝  ██║     
              ╚██████╗   ██║   ██████╔╝███████╗██║  ██║███████║███████╗╚██████╗
               ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝╚══════╝ ╚═════╝
                =========== Your Digital Security Companion ===========
        ");
            Console.ResetColor();
        }

        // Displays ASCII art and a warning message for phishing alerts
        public void ShowPhishingArt()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
                 ><(((º>  PHISHING ALERT!  <º)))><
                
                     |\\___/|    /\___/\
                     )     (     )    ~( .            
                    =\     /=   =\~    /=
                      )===(       )===(
                     /     \     /     \
                     |     |     |     |
                    /       \   /       \
                    \       /   \       /
              _/\_/\_/\__  _/_/\_/\_/\_/\_/\_/\_/\_
              |  WARNING: Don't Take the Bait!    |
              \_/\_/\_/\_/\_/\_/\_/\_/\_/\_/\_/\_/
        ");
            Console.ResetColor();
        }

        // Displays a header for the phishing section
        public void PhishingHeader()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
        ========================================================================================
                                        Phishing Scams
        ========================================================================================
        ");
            Console.ResetColor();
        }

        // Displays ASCII art for password security
        public void ShowPasswordArt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
                ╔══════════════════╗
                ║ ▌│█║▌║▌║║▌║▌║█│▌ ║
                ║  PASSWORD VAULT  ║
                ╠══════════════════╣
                ║     SECURE       ║
                ║     STRONG       ║
                ║     UNIQUE       ║
                ╚══════════════════╝
        ");
            Console.ResetColor();
        }

        // Displays a header for the password security section
        public void PasswordHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
        ========================================================================================
                                        Password Security
        ========================================================================================
        ");
            Console.ResetColor();
        }

        // Displays ASCII art and a warning message for social engineering
        public void ShowSocialEngineeringArt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
                   ,_____,    SOCIAL
                  /       \   ENGINEERING
                 /  ^   ^  \  ALERT!
                /  (o) (o)  \
               /     ||      \
              /      u        \
             /________________\
                BE AWARE OF
              HUMAN MANIPULATION!
        ");
            Console.ResetColor();
        }

        // Displays a header for the social engineering section
        public void SocialEngineeringHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
        ========================================================================================
                                    Social Engineering
        ========================================================================================
        ");
            Console.ResetColor();
        }

        // Displays a header for the suspicious links section
        public void SuspiciousLinksHeader()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"
        ========================================================================================
                                        Suspicious Links
        ========================================================================================
        ");
            Console.ResetColor();
        }

        // Displays a header for the main menu
        public void MainMenuHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
        ========================================================================================
                                            Main Menu
        ========================================================================================
        ");
            Console.ResetColor();
        }

        // Displays ASCII art for suspicious link detection
        public void ShowSuspiciousLinksArt()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"
                  SUSPICIOUS LINK DETECTOR 
                ┌─────────────────────────┐
                │http://totally-safe.scam │
                │  DANGER DETECTED!       │
                └─────────────────────────┘
                │  Unusual Domain         │
                │  Mismatched SSL         │
                │  Suspicious TLD         │
                └─────────────────────────┘
        ");
            Console.ResetColor();
        }

        // Displays a header for user interaction prompts
        public void InteractionHeader()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
        ========================================================================================
                        What would you like to know?
        ========================================================================================
        ");
            Console.ResetColor();
        }

        // Displays ASCII art for the exit process
        public void ShowExitArt()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
                ╔═══════════════════════╗
                ║ SYSTEM SHUTDOWN       ║
                ║ ■■■■■■■■■■■■░░░ 89%   ║
                ║                       ║
                ║ Saving Security Log   ║
                ║ Clearing Cache...     ║
                ╚═══════════════════════╝
                Stay Safe & Secure! 👋
        ");
            Console.ResetColor();
        }

        // Displays a header for the exit process
        public void ExitHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
        ========================================================================================
                                        Exiting Program
        ========================================================================================
        ");
            Console.ResetColor();
        }

        // Displays ASCII art for the main menu
        public void ShowMainMenuArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
                ╔═══════════════════════╗
                ║    SECURITY MENU      ║
                ╠═══════════════════════╣
                ║    1. Phishing        ║
                ║    2. Passwords       ║
                ║    3. Links           ║
                ║    4. Social Eng.     ║
                ║    5. Exit            ║
                ╚═══════════════════════╝
        ");
            Console.ResetColor();
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