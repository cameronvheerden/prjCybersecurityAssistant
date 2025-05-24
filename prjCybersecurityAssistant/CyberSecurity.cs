namespace prjCybersecurityAssistant
{
    public class CyberSecurity : VoiceAssistant//(Troelsen & Japikse, 2021)
    {
        // Stores the username of the user interacting with the chatbot
        private string username = string.Empty; // Initialize to avoid nullability issues

        // Random number generator for selecting random jokes or responses
        private readonly Random random = new Random();//(Chand, 2023)

        // Instance of ChatbotASCIIArt for displaying ASCII art in the console
        private readonly ChatbotASCIIArt art = new ChatbotASCIIArt();

        // Array of jokes the chatbot can tell
        private readonly string[] chatbotJokes =
        {
                "Why did the computer go to therapy? Because it had too many insecure connections.",
                "What’s a hacker’s favorite type of exercise? Phishing!",
                "I asked my password to tell me a joke… It said, You wouldn’t get it—it’s too complex.",
                "Why did the cybersecurity expert break up with the internet? Too many red flags and pop-ups.",
                "How do you comfort a victim of a data breach? You tell them, It's not your fault… it’s a targeted attack.",
                "Why did the hacker get kicked off the farm? He kept rooting around in the system.",
                "Why was the cybersecurity student always calm? Because they had strong firewalls and even stronger passwords.",
                "What do you call a virus in Cape Town? A Cape-worm!",
                "Knock knock. Who’s there? A phishing email. A phishing email who? Urgently click this link or lose access to your account!",
                "How many hackers does it take to change a light bulb? None. They just change the logs to make it look like they did."
            };

        // Array of responses for when the user asks how the chatbot is doing
        private readonly string[] howAreYouResponses =
        {
                "I'm just a bunch of code, but thanks for asking! I'm feeling as good as a perfectly secure firewall.",
                "I'm functioning at optimal efficiency, thank you!",
                "I'm doing great! Just keeping the cyber world safe, one byte at a time.",
                "I'm feeling encrypted and secure! Thanks for asking.",
                "I'm as happy as a server with zero downtime. How can I assist you today?"
            };

        // Entry point for starting the chatbot
        public void StartChatbot()
        {
            // Set the console background color to black and clear the console screen
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            // Display the chatbot's header art
            art.ShowHeader();

            // Play the startup sound
            PlaySound("Startup Jingle.wav");//(George, 2023)

            // Greet the user with an introductory message
            Speak("Welcome to the Cybersecurity Awareness Assistant — your digital bodyguard in the wild world of the internet!", ConsoleColor.Cyan);//(Motta, 2023)

            // Play a sound to indicate success or excitement
            PlaySound("Winning.wav");//(George, 2023)

            // Ask the user for their name or nickname
            Speak("Before we kick off this cyber-adventure, I need to know — what do your friends (and your Wi-Fi) call you?", ConsoleColor.Cyan);//(Motta, 2023)

            // Read the user's input and assign it to the username variable, defaulting to "User" if input is null
            username = Console.ReadLine() ?? "User";

            // Acknowledge the user's input and prepare them for the chatbot experience
            Speak($"Lekker, {username}! Buckle up — we’re about to dive into the world of firewalls, phishing scams, and password ninjas.", ConsoleColor.Cyan);//(Motta, 2023)

            // Start the initial interaction phase of the chatbot
            InitialInteraction();

            // Transition to the main menu of the chatbot
            MainMenu();
        }

        // Handles the initial interaction phase of the chatbot
        private void InitialInteraction()
        {
            // Display the interaction header art
            art.InteractionHeader();

            while (true)//(Troelsen & Japikse, 2021)
            {
                // Present the user with options for the initial interaction
                Speak("Before we begin, would you like to:", ConsoleColor.Cyan);//(Motta, 2023)
                Speak("1. Hear a joke - Use 'joke'", ConsoleColor.Cyan);//(Motta, 2023)
                Speak("2. Learn about my purpose - Use 'purpose'", ConsoleColor.Cyan);//(Motta, 2023)
                Speak("3. Ask how I'm doing - Use 'how are you'", ConsoleColor.Cyan);//(Motta, 2023)
                Speak("4. Skip to the main menu - Use 'skip'", ConsoleColor.Cyan);//(Motta, 2023)

                // Get the user's choice and validate it against the expected inputs
                string choice = GetUserInput(new[] { "joke", "purpose", "how are you", "skip" });

                // Handle the user's choice
                switch (choice)//(Troelsen & Japikse, 2021)
                {
                    case "joke":
                        // Select a random joke and display it
                        string joke = chatbotJokes[random.Next(chatbotJokes.Length)];//(Chand, 2023)
                        Speak(joke, ConsoleColor.Green);//(Motta, 2023)
                        PlaySound("Ba Dum Tss.wav");//(George, 2023)
                        break;

                    case "purpose":
                        // Explain the chatbot's purpose
                        PlaySound("Confirmation Tone.wav");//(George, 2023)
                        Speak("I am your Cybersecurity Awareness Assistant. My purpose is to help you stay safe online by teaching you about phishing scams, strong passwords, suspicious links, and social engineering tactics.", ConsoleColor.Cyan);//(Motta, 2023)
                        break;

                    case "how are you":
                        // Respond to the user's inquiry about the chatbot's status
                        PlaySound("Winning.wav");//(George, 2023)
                        string response = howAreYouResponses[random.Next(howAreYouResponses.Length)];//(Chand, 2023)
                        Speak(response, ConsoleColor.Magenta);//(Motta, 2023)
                        break;

                    case "skip":
                        // Skip to the main menu
                        Speak("Alright, let's get started!", ConsoleColor.Cyan);//(Motta, 2023)
                        MainMenu();
                        return;

                    default:
                        // Handle invalid input
                        Speak($"Oops! I didn’t catch that, {username}. Please try and speak more clearly—I’m only a robot, not a mind reader.", ConsoleColor.Red);//(Motta, 2023)
                        Speak("Let's rewind and try that again.", ConsoleColor.Red);//(Motta, 2023)
                        break;
                }
            }
        }

        // Displays the main menu and handles user choices
        private void MainMenu()
        {
            // Display the main menu header and art
            art.MainMenuHeader();
            Speak("Ready to level up your cyber skills, defender of the digital realm? Choose your next move:", ConsoleColor.Cyan);//(Motta, 2023)
            art.ShowMainMenuArt();
            PlaySound("Stealthy Whoosh.wav");//(George, 2023)

            while (true)
            {
                // Display the main menu options
                art.MainMenuHeader();
                Speak("1. Learn how to spot a phishing scam - Use 'phishing'", ConsoleColor.Cyan);//(Motta, 2023)
                Speak("2. Master strong password practices - Use 'password'", ConsoleColor.Cyan);//(Motta, 2023)
                Speak("3. Recognize suspicious links and websites - Use 'links'", ConsoleColor.Cyan);//(Motta, 2023)
                Speak("4. Understand social engineering tactics - Use 'social engineering'", ConsoleColor.Cyan);//(Motta, 2023)
                Speak("5. Exit the Cyber Assistant - Use 'exit'", ConsoleColor.Cyan);//(Motta, 2023)

                // Get the user's choice and validate it against the expected inputs
                string choice = GetUserInput(new[] { "phishing", "password", "links", "social engineering", "exit" });

                // Handle the user's choice
                switch (choice)
                {
                    case "phishing":
                        // Navigate to the phishing scams section
                        PhishingScams();
                        break;

                    case "password":
                        // Navigate to the strong passwords section
                        StrongPasswords();
                        break;

                    case "links":
                        // Navigate to the suspicious links section
                        SuspiciousLinks();
                        break;

                    case "social engineering":
                        // Navigate to the social engineering section
                        SocialEngineering();
                        break;

                    case "exit":
                        // Exit the chatbot
                        EndChatbot();
                        return;

                    default:
                        // Handle invalid input
                        Speak($"Oops! I didn’t catch that, {username}. Please try and speak more clearly—I’m only a robot, not a mind reader.", ConsoleColor.Red);//(Motta, 2023)
                        Speak("Let's rewind and try that again.", ConsoleColor.Red);//(Motta, 2023)
                        break;
                }
            }
        }

        // Handles the phishing scams section
        private void PhishingScams()
        {
            // Play a sound and display the phishing header art
            PlaySound("Success Chime.wav");//(George, 2023)
            art.PhishingHeader();
            Speak("Phishing scams are like digital fishing trips, but instead of catching fish, they try to catch your personal information!", ConsoleColor.Red);//(Motta, 2023)
            art.ShowPhishingArt();

            while (true)
            {
                // Display phishing scams options
                art.PhishingHeader();
                Speak("1. Learn about the different types of Phishing Scams - Use 'scams'", ConsoleColor.Red);//(Motta, 2023)
                Speak("2. Signs to look out for when dealing with Phishing Scams - Use 'signs'", ConsoleColor.Red);//(Motta, 2023)
                Speak("3. Learn how to avoid Phishing Scams  - Use 'avoid'", ConsoleColor.Red);//(Motta, 2023)
                Speak("4. Exit from learning about Phishing Scams - Use 'exit'", ConsoleColor.Red);//(Motta, 2023)

                // Get the user's choice and validate it against the expected inputs
                string choice = GetUserInput(new[] { "scams", "signs", "avoid", "exit" });

                // Handle the user's choice
                switch (choice)
                {
                    case "scams":
                        // Explain the types of phishing scams
                        PlaySound("Mysterious Ping.wav");//(George, 2023)
                        Speak("Here are some common types of phishing scams:", ConsoleColor.Red);//(Motta, 2023)
                        Speak("1. Email Phishing: Fake emails that look real.", ConsoleColor.Red);//(Motta, 2023)
                        Speak("2. Spear Phishing: Targeted attacks on specific individuals.", ConsoleColor.Red);//(Motta, 2023)
                        Speak("3. Whaling: Attacks on high-profile targets like CEOs.", ConsoleColor.Red);//(Motta, 2023)
                        Speak("4. Vishing: Voice phishing over the phone.", ConsoleColor.Red);//(Motta, 2023)
                        Speak("5. Smishing: Phishing via SMS or text messages.", ConsoleColor.Red);//(Motta, 2023)
                        break;

                    case "signs":
                        // Explain the signs of phishing scams
                        PlaySound("Glass Crack.wav");//(George, 2023)
                        Speak("Here are some signs to look out for:", ConsoleColor.Red);//(Motta, 2023)
                        Speak("1. Suspicious sender email addresses", ConsoleColor.Red);//(Motta, 2023)
                        Speak("2. Generic greetings like 'Dear User'", ConsoleColor.Red);//(Motta, 2023)
                        Speak("3. Urgent requests for personal information", ConsoleColor.Red);//(Motta, 2023)
                        Speak("4. Links that don’t match the sender’s website", ConsoleColor.Red);//(Motta, 2023)
                        Speak("5. Poor grammar and spelling mistakes", ConsoleColor.Red);//(Motta, 2023)
                        break;

                    case "avoid":
                        // Provide tips to avoid phishing scams
                        PlaySound("Victory.wav");//(George, 2023)
                        Speak("Here are some tips to avoid phishing scams:", ConsoleColor.Red);//(Motta, 2023)
                        Speak("1. Verify the sender’s email address.", ConsoleColor.Red);//(Motta, 2023)
                        Speak("2. Avoid clicking on links in unsolicited emails.", ConsoleColor.Red);//(Motta, 2023)
                        Speak("3. Use multi-factor authentication (MFA).", ConsoleColor.Red);//(Motta, 2023)
                        Speak("4. Keep your software updated.", ConsoleColor.Red);//(Motta, 2023)
                        Speak("5. Be cautious of urgent or threatening language.", ConsoleColor.Red);//(Motta, 2023)
                        break;

                    case "exit":
                        // Exit the phishing scams section
                        PlaySound("Suspicious Glitch Sound.wav");//(George, 2023)
                        Speak("If you want to learn more about Phishing Scams, just ask!", ConsoleColor.Red);//(Motta, 2023)
                        return;

                    default:
                        // Handle invalid input
                        Speak($"Oops! I didn’t catch that, {username}. Please try and speak more clearly—I’m only a robot, not a mind reader.", ConsoleColor.Red);//(Motta, 2023)
                        Speak("Let's rewind and try that again.", ConsoleColor.Red);//(Motta, 2023)
                        break;
                }
            }
        }

        // Handles the strong passwords section
        private void StrongPasswords()
        {
            // Play a sound and display the password header art
            PlaySound("Lock Click Sound.wav");//(George, 2023)
            art.PasswordHeader();
            Speak("Strong passwords are like the locks on your digital doors. They keep the bad guys out!", ConsoleColor.Green);//(Motta, 2023)
            art.ShowPasswordArt();

            while (true)
            {
                // Display strong passwords options
                art.PasswordHeader();
                Speak("1. Tips for creating strong passwords  - Use 'tips'", ConsoleColor.Green);//(Motta, 2023)
                Speak("2. Examples of weak passwords to avoid - Use 'weak'", ConsoleColor.Green);//(Motta, 2023)
                Speak("3. Exit to main menu - Use 'exit'", ConsoleColor.Green);//(Motta, 2023)

                // Get the user's choice and validate it against the expected inputs
                string choice = GetUserInput(new[] { "tips", "weak", "exit" });

                // Handle the user's choice
                switch (choice)
                {
                    case "tips":
                        // Provide tips for creating strong passwords
                        PlaySound("Victory.wav");//(George, 2023)
                        Speak("Here are some tips for creating strong passwords:", ConsoleColor.Green);//(Motta, 2023)
                        Speak("1. Use at least 12 characters.", ConsoleColor.Green);//(Motta, 2023)
                        Speak("2. Include a mix of uppercase and lowercase letters, numbers, and symbols.", ConsoleColor.Green);//(Motta, 2023)
                        Speak("3. Avoid using easily guessable information like birthdays or names.", ConsoleColor.Green);//(Motta, 2023)
                        break;

                    case "weak":
                        // Provide examples of weak passwords to avoid
                        PlaySound("Error.wav");//(George, 2023)
                        Speak("Here are some examples of weak passwords to avoid:", ConsoleColor.Green);//(Motta, 2023)
                        Speak("1. 123456", ConsoleColor.Green);//(Motta, 2023)
                        Speak("2. password", ConsoleColor.Green);//(Motta, 2023)
                        Speak("3. qwerty", ConsoleColor.Green);//(Motta, 2023)
                        Speak("4. letmein", ConsoleColor.Green);//(Motta, 2023)
                        Speak("5. yourname123", ConsoleColor.Green);//(Motta, 2023)
                        break;

                    case "exit":
                        // Exit the strong passwords section
                        PlaySound("Suspicious Glitch Sound.wav");//(George, 2023)
                        Speak("If you want to learn more about Strong Passwords, just say the word!", ConsoleColor.Green);//(Motta, 2023)
                        return;

                    default:
                        // Handle invalid input
                        Speak(
                            $"Oops! I didn’t catch that, {username}. Please try and speak more clearly—I’m only a robot, not a mind reader.",
                            ConsoleColor.Red);//(Motta, 2023)
                        Speak("Let's rewind and try that again.", ConsoleColor.Red);//(Motta, 2023)
                        break;
                }
            }
        }

        // Handles the suspicious links section
        private void SuspiciousLinks()
        {
            // Play a sound and display the suspicious links header art
            PlaySound("Mysterious Ping.wav");//(George, 2023)
            art.SuspiciousLinksHeader();
            Speak("Suspicious links can lead to phishing sites or malware downloads. Here’s how to spot them:", ConsoleColor.Magenta);//(Motta, 2023)
            Speak("1. Hover over links to see the actual URL before clicking.", ConsoleColor.Magenta);//(Motta, 2023)
            Speak("2. Look for misspelled domain names or unusual characters.", ConsoleColor.Magenta);//(Motta, 2023)
            Speak("3. Be cautious of shortened URLs that hide the destination.", ConsoleColor.Magenta);//(Motta, 2023)
            Speak("4. Avoid clicking on links in unsolicited emails or messages.", ConsoleColor.Magenta);//(Motta, 2023)
            art.ShowSuspiciousLinksArt();
        }

        // Handles the social engineering section
        private void SocialEngineering()
        {
            // Play a sound and display the social engineering header art
            PlaySound("Magic.wav");//(George, 2023)
            art.SocialEngineeringHeader();
            Speak("Social engineering is like a magician’s trick—but instead of pulling a rabbit out of a hat, they pull your personal info out of *you*!", ConsoleColor.Yellow);//(Motta, 2023)
            art.ShowSocialEngineeringArt();

            while (true)
            {
                // Display social engineering options
                art.SocialEngineeringHeader();
                Speak("1. Learn the types of social engineering attacks - Use 'types'", ConsoleColor.Yellow);//(Motta, 2023)
                Speak("2. Spot the signs of manipulation - Use 'signs'", ConsoleColor.Yellow);//(Motta, 2023)
                Speak("3. Tips to avoid being tricked - Use 'avoid'", ConsoleColor.Yellow);//(Motta, 2023)
                Speak("4. Exit to main menu - Use 'exit'", ConsoleColor.Yellow);//(Motta, 2023)

                // Get the user's choice and validate it against the expected inputs
                string choice = GetUserInput(new[] { "types", "signs", "avoid", "exit" });

                // Handle the user's choice
                switch (choice)
                {
                    case "types":
                        // Explain the types of social engineering attacks
                        PlaySound("Success Chime.wav");
                        Speak("Here are some common types of social engineering attacks:", ConsoleColor.Yellow);//(Motta, 2023)
                        Speak("1. Pretexting: Creating a false scenario to steal information.", ConsoleColor.Yellow);//(Motta, 2023)
                        Speak("2. Baiting: Offering something enticing to lure victims.", ConsoleColor.Yellow);//(Motta, 2023)
                        Speak("3. Tailgating: Gaining unauthorized access by following someone.", ConsoleColor.Yellow);//(Motta, 2023)
                        break;

                    case "signs":
                        // Explain the signs of social engineering attacks
                        PlaySound("Glass Crack.wav");
                        Speak("Here are some signs of social engineering attacks:", ConsoleColor.Yellow);//(Motta, 2023)
                        Speak("1. Unsolicited requests for personal information.", ConsoleColor.Yellow);//(Motta, 2023)
                        Speak("2. Urgent or threatening language in messages.", ConsoleColor.Yellow);//(Motta, 2023)
                        Speak("3. Offers that seem too good to be true.", ConsoleColor.Yellow);//(Motta, 2023)
                        break;

                    case "avoid":
                        // Provide tips to avoid social engineering attacks
                        PlaySound("Victory.wav");
                        Speak("Here are some tips to avoid social engineering attacks:", ConsoleColor.Yellow);//(Motta, 2023)
                        Speak("1. Verify the identity of the person requesting information.", ConsoleColor.Yellow);//(Motta, 2023)
                        Speak("2. Be cautious of unsolicited messages or phone calls.", ConsoleColor.Yellow);//(Motta, 2023)
                        Speak("3. Avoid sharing personal information on social media.", ConsoleColor.Yellow);//(Motta, 2023)
                        break;

                    case "exit":
                        // Exit the social engineering section
                        PlaySound("Suspicious Glitch Sound.wav");
                        Speak("If you want to learn more about Social Engineering, I'm always here!", ConsoleColor.Yellow);//(Motta, 2023)
                        return;

                    default:
                        // Handle invalid input
                        Speak($"Oops! I didn’t catch that, {username}. Please try and speak more clearly—I’m only a robot, not a mind reader.", ConsoleColor.Red);//(Motta, 2023)
                        Speak("Let's rewind and try that again.", ConsoleColor.Red);//(Motta, 2023)
                        break;
                }
            }
        }

        // Ends the chatbot session
        private void EndChatbot()
        {
            // Display the exit header art and play the shutdown sound
            art.ExitHeader();
            art.ShowExitArt();
            PlaySound("Shutdown Sound.wav");//(George, 2023)

            // Say goodbye to the user and exit the application
            Speak($"Alright, {username}, it’s time for me to log off and defrag my circuits. Stay sharp and secure!", ConsoleColor.DarkCyan);//(Motta, 2023)
            Environment.Exit(0);
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