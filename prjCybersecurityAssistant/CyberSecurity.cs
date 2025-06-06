﻿using System;
using System.Speech.Synthesis;

namespace prjCybersecurityAssistant
{

    // The CyberSecurity class is an interactive chatbot assistant that provides cybersecurity tips, handles user sentiment,
    // and responds to keyword-based queries. Inherits from VoiceAssistant for speech and sound features.

    public class CyberSecurity : VoiceAssistant
    {
        //Memory for user details
        private string userName = "";
        private string favouriteTopic = "";

        // Random instance for generating random responses from the assistant
        private readonly Random _random;// (Plays, 2022)

        //Dictionary to hold sentiment responses
        private Dictionary<string, Action<string>> sentimentResponses;//(Corey, 2023)

        //Dictionary to hold keyword handlers
        private Dictionary<string, Action<string>> keywordHandler;//(Corey, 2023)

        //Collection of keywords and their associated Colours for the chatbots responses
        private Dictionary<string, ConsoleColor> topicColors = new Dictionary<string, ConsoleColor>(StringComparer.OrdinalIgnoreCase)//(Corey, 2023)
        {
            ["phishing"] = ConsoleColor.Yellow,
            ["strong passwords"] = ConsoleColor.Green,
            ["suspicious links"] = ConsoleColor.Magenta,
            ["social engineering"] = ConsoleColor.DarkCyan,
            ["general"] = ConsoleColor.White
        };

        //Generic dictionary to hold keyword responses
        private Dictionary<string, List<string>> topicTips = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)//(Corey, 2023)
        {
            ["phishing"] = new List<string>//(Corey, 2023)
            {
                "Phishing scams are like digital fishing trips — but instead of fish, scammers are after your passwords, bank info, and personal details.",
                "Phishing emails might look official, but they often contain spelling errors, weird links, or suspicious attachments.",
                "Watch out for urgent language like 'Your account will be suspended' or 'Act now!' scammers use fear to pressure you into clicking.",
                "Hover over links before clicking them. If the web address looks odd or doesn’t match the sender, it’s probably a trap.",
                "No legit company will ask for your password or credit card info over email. When in doubt, contact the company directly using a verified method.",
                "Phishing can also happen through texts and social media not just email. If a message feels off, trust your gut and double-check.",
                "If something feels fishy — it probably is. Always pause and verify before clicking or replying."
            },

            ["passwords"] = new List<string>//(Corey, 2023)
            {
                "Think of your password like a toothbrush never share it, change it often, and don’t use your name on it!",
                "Use a mix of letters, numbers, and symbols and skip the obvious stuff like '123456' or 'password'.",
                "The longer your password, the stronger it is. Try using a funny sentence or phrase you’ll remember.",
                "Don’t reuse the same password for multiple sites if one gets hacked, the rest are at risk.",
                "Use a password manager. It remembers the complicated stuff so you don’t have to.",
                "Avoid using birthdays, pet names, or your favorite band hackers can guess these easily with a little digging.",
                "Update your passwords regularly, especially if you’ve heard about a data breach from a site you use."
            },

            ["suspicious links"] = new List<string>//(Corey, 2023)
            {
                "A suspicious link is like a sketchy shortcut in a video game it might take you somewhere dangerous!",
                "Always hover over a link to see where it *really* goes before clicking. If it looks weird, skip it.",
                "Shortened links (like bit.ly) can hide the true destination only click if you trust the source.",
                "If a link promises free money, miracle cures, or secret tips it’s probably bait.",
                "Don't click random links in comment sections, DMs, or unfamiliar emails they're prime spots for scams.",
                "Even if a link looks okay, if you didn’t expect it or the message feels off, double-check with the sender.",
                "Bad links can install malware just from visiting the site be picky about what you open."
            },

            ["social engineering"] = new List<string>//(Corey, 2023)
            {
                "Social engineering is basically hacking the human scammers trick you into handing over info willingly.",
                "If someone asks for your password, even if they sound official, stop right there. Real support never does that.",
                "Scammers often pretend to be your boss, bank, or even a family member. When in doubt, call them directly to confirm.",
                "Don’t overshare online scammers use your public posts to guess passwords or security questions.",
                "Always ask yourself: why does this person need this info? If it doesn’t make sense, don’t give it.",
                "If it feels like someone’s trying too hard to gain your trust online, they might be trying to manipulate you.",
                "Stay alert being friendly is great, but don’t let politeness cost you your personal info."
            },

            ["general"] = new List<string>//(Corey, 2023)
            {
                "The internet is awesome, but it's not a playground with safety mats — always stay a little cautious.",
                "Keep your browser and software updated. It's like putting on armor before going into battle.",
                "Install an ad blocker and antivirus think of them as your digital bodyguards.",
                "When in doubt, Google it! If something sounds suspicious, chances are others have asked about it too.",
                "Use two-factor authentication wherever you can it's like having a lock and a guard dog.",
                "Don’t trust every site with flashy pop-ups or autoplay videos they’re usually hiding something shady.",
                "Just like in real life, if a deal online sounds too good to be true... it is."
            }
        };

        // Initializes the CyberSecurity assistant, setting up randomization, sentiment, and keyword handlers.

        public CyberSecurity()
        {
            //Initialze a new Random instance for generating random responses
            _random = new Random();// (Plays, 2022)

            //Set up Sentiment handlers
            sentimentResponses = new Dictionary<string, Action<string>>(StringComparer.OrdinalIgnoreCase)//(Corey, 2023)
            {
                {"worried", worriedResponse},
                {"curious", curiousResponse},
                {"frustrated", frustratedResponse},
                {"overwhelmed", overwhelmedResponse},
                {"skeptical", skepticalResponse}
            };

            //Set up Keyword handlers
            keywordHandler = new Dictionary<string, Action<string>>(StringComparer.OrdinalIgnoreCase)//(Corey, 2023)
            {
                {"phishing", input => RespondWithRandomTip("phishing")},
                {"passwords", input => RespondWithRandomTip("passwords")},
                {"suspicious links", input => RespondWithRandomTip("suspicious links")},
                {"social engineering", input => RespondWithRandomTip("social engineering")},
                {"general", input => RespondWithRandomTip("general")}
            };
        }

        // Main entry point for the assistant. Handles user interaction, topic selection, and main chat loop.

        public void Start()
        {
            PlaySound("startup.wav");//(O'Didily, 2022)
            Console.WriteLine("Press enter to start!");
            Console.ReadLine(); // Wait for user to press enter before starting

            // Initial welcome message with humor
            Speak("Welcome to the CyberSecurity Assistant! I'm your digital bodyguard, bouncer, and comedian rolled into one. Before we get serious, here's a quick round of cybersecurity dad jokes to lighten the mood!", ConsoleColor.Cyan);//(Manson, 2014)
            PlaySound("drumroll.wav");//(O'Didily, 2022)
            dadCyberSecurityJokes();

            // Ask for user's name
            Speak("Before we dive in, what's your name? (Don't worry, I won't put it in a password... or will I? Just kidding!)", ConsoleColor.Cyan);//(Manson, 2014)
            userName = GetUserInput("You: ");
            PlaySound("input.wav");//(O'Didily, 2022)

            // Ask for user's favorite topic
            Speak($"Nice to meet you, {userName}! What's your favourite cybersecurity topic? I'll display the topics I am well aware of.", ConsoleColor.Cyan);//(Manson, 2014)
            Console.WriteLine(@"
        ╔════════════════════════════════════╗
        ║         CYBERSECURITY MENU         ║
        ╠════════════════════════════════════╣
        ║  1. Phishing                       ║
        ║  2. Passwords                      ║
        ║  3. Suspicious Links               ║
        ║  4. Social Engineering             ║
        ║  5. General                        ║
        ║  6. Exit                           ║
        ╚════════════════════════════════════╝
    ");
            favouriteTopic = GetUserInput("You: ");
            PlaySound("input.wav");//(O'Didily, 2022)

            if (topicTips.ContainsKey(favouriteTopic))
            {//(Manson, 2014)
                Speak($"Awesome! I'll remember that your favourite topic is {favouriteTopic}. Expect some special tips later!", ConsoleColor.Green);//(Manson, 2014)
                PlaySound("awesome.wav");//(O'Didily, 2022)

                // Prompt user to ask about a keyword now
                Speak("By the way, you can ask me about any of these keywords: phishing, passwords, suspicious links, social engineering, or general tips.", ConsoleColor.Cyan);//(Manson, 2014)
                Speak("Which keyword would you like to know more about right now? (Or just press enter to skip)", ConsoleColor.Cyan);//(Manson, 2014)
                string keywordInput = GetUserInput("You: ");
                PlaySound("input.wav");//(O'Didily, 2022)

                if (!string.IsNullOrWhiteSpace(keywordInput))//(Corey, 2023
                {
                    foreach (var keyword in keywordHandler.Keys)//(Corey, 2023
                    {
                        if (keywordInput.Contains(keyword, StringComparison.OrdinalIgnoreCase))//(Corey, 2023
                        {
                            Speak($"Great choice! Here's something about {keyword}:", ConsoleColor.Green);//(Manson, 2014)
                            keywordHandler[keyword](keywordInput);//(Corey, 2023
                            PlaySound("keyword.wav");//(O'Didily, 2022)
                            break;
                        }
                    }
                }
                else
                {

                    Speak("Hmm, I don't have tips for that topic yet. Let's stick with general tips for now.", ConsoleColor.Yellow);//(Manson, 2014)
                    RespondWithRandomTip("general");//(Corey, 2023)
                    PlaySound("keyword.wav");//(O'Didily, 2022)
                }
            }

            // Main chat loop
            while (true)
            {
                // Ask for user input and allow them to share concerns or ask questions
                Speak("Ask me anything about cybersecurity, or type 'exit' to leave (I promise not to take it personally!). Tell me if you are worried about anything or have any fears entering the online space.", ConsoleColor.Cyan);//(Manson, 2014)
                Console.WriteLine("Are you worried about anything or have fears such as being 'curious', 'frustrated', 'overwhelmed', 'skeptical'?");
                string input = GetUserInput("You: ");
                PlaySound("input.wav");//(O'Didily, 2022)

                // Exit condition
                if (input.Contains("exit", StringComparison.OrdinalIgnoreCase))//(Corey, 2023)
                {
                    PlaySound("oh no.wav");//(O'Didily, 2022)
                    Speak($"Goodbye {userName}! Remember: If you ever get a suspicious email, just send it to me for a joke. Stay safe and silly!", ConsoleColor.Magenta);//(Manson, 2014)
                    PlaySound("bye bye.wav");//(O'Didily, 2022)
                    Console.ReadLine();
                    break;
                }

                // Handle known sentiments and provide comforting or informative responses
                string sentiment = DetectSentiment(input);//(Corey, 2023)
                if (!string.IsNullOrEmpty(sentiment) && sentimentResponses.ContainsKey(sentiment))//(Corey, 2023)
                {
                    sentimentResponses[sentiment](input);//(Corey, 2023)
                    PlaySound(sentiment + ".wav");//(O'Didily, 2022)
                }

                // Check if the input includes known cybersecurity keywords
                bool foundKeyword = false;
                foreach (var keyword in keywordHandler.Keys)//(Corey, 2023)
                {
                    if (input.Contains(keyword, StringComparison.OrdinalIgnoreCase))//(Corey, 2023)
                    {
                        keywordHandler[keyword](input);//(Corey, 2023)
                        PlaySound("keyword.wav");//(O'Didily, 2022)
                        foundKeyword = true;
                        break;
                    }
                }

                // If no keyword detected, ask the user if they'd like to explore one
                if (!foundKeyword)
                {
                    Speak("Would you like to learn more about a specific keyword? (phishing, passwords, suspicious links, social engineering, general and type tip to hear a fact about your favourite topic). Just type one or press enter to skip.", ConsoleColor.Cyan);//(Manson, 2014)
                    string keywordPrompt = GetUserInput("You: ");
                    PlaySound("input.wav");//(O'Didily, 2022)

                    if (!string.IsNullOrWhiteSpace(keywordPrompt))//(Corey, 2023)
                    {
                        foreach (var keyword in keywordHandler.Keys)//(Corey, 2023)
                        {
                            if (keywordPrompt.Contains(keyword, StringComparison.OrdinalIgnoreCase))//(Corey, 2023)
                            {
                                Speak($"Here's a quick tip about {keyword}:", ConsoleColor.Green);//(Manson, 2014)
                                keywordHandler[keyword](keywordPrompt);//(Corey, 2023)
                                PlaySound("keyword.wav");//(O'Didily, 2022)
                                break;
                            }
                        }
                    }
                }
                // Personalised memory recall
                if (!string.IsNullOrEmpty(favouriteTopic) || input.Contains("tip"))//(Corey, 2023)
                {
                    Speak($"As someone interested in {favouriteTopic}, here's something just for you:", ConsoleColor.Green);//(Manson, 2014)
                    RespondWithRandomTip(favouriteTopic);// (Corey, 2023)
                    PlaySound("keyword.wav");//(O'Didily, 2022)
                    foundKeyword = true;
                }
            }
        }


        // Detects simple sentiment keywords in user input and returns the sentiment type.
        private string DetectSentiment(string input)//(Corey, 2023)
        {
            if (input.Contains("worried") || input.Contains("worry") || input.Contains("anxious"))
                return "worried";

            if (input.Contains("curious") || input.Contains("wonder") || input.Contains("interested"))
                return "curious";

            if (input.Contains("frustrated") || input.Contains("angry") || input.Contains("annoyed"))
                return "frustrated";

            if (input.Contains("overwhelmed") || input.Contains("confused") || input.Contains("lost"))
                return "overwhelmed";

            if (input.Contains("skeptical") || input.Contains("doubt") || input.Contains("don't believe"))
                return "skeptical";

            return null;
        }

        // Responds to "worried" sentiment with a random reassuring message.
        private void worriedResponse(string input)//(Programming, 2019)
        {
            List<string> _sentiment = new List<string>//(Programming, 2019)
            {
              "It's completely understandable to feel worried or anxious browsing the web. Scammers can be very cruel and they exploit innocent vulnerable people but that's why I am here to assist you.",
              "That makes sense the internet can feel like a risky place sometimes. You're not alone in feeling this way, and I can help you spot the red flags.",
              "Worry is totally valid, especially with all the scams going around. Let's take it step by step and go over how you can stay protected.",
              "I get it cybersecurity can seem overwhelming at first. But once you know what to watch out for, it becomes much more manageable.",
              "It's normal to feel a bit anxious about online safety. The good news is that there are practical steps we can take together to minimize those risks.",
              "It’s good that you’re paying attention. Feeling worried shows you’re taking things seriously, and that’s the first step toward staying safe.",
              "You're right to be cautious. Let's talk about some simple habits you can build to feel more confident online."
            };

            // Randomly select a response from the list
            string response = _sentiment[_random.Next(_sentiment.Count)];// (Plays, 2022)
            Speak(response, ConsoleColor.DarkYellow);//(Manson, 2014)
        }

        // Responds to "curious" sentiment with a random informative message.
        private void curiousResponse(string input)//(Programming, 2019)
        {
            List<string> _sentiment = new List<string>//(Programming, 2019)
            {
                "Curiosity is a great starting point. Let me show you how things like phishing and data breaches actually work.",
                "That’s a good question. Learning how the risks work helps you spot and avoid them — let’s dive into it.",
                "I love that you're curious! The more you know, the safer you’ll be. Want to hear about how hackers use fake websites?",
                "Curious minds are the best defenders. Let’s explore how online threats happen and how you can prevent them.",
                "Great question! The web has many layers, and understanding how attacks work gives you the upper hand."
            };

            string response = _sentiment[_random.Next(_sentiment.Count)];// (Plays, 2022)
            Speak(response, ConsoleColor.Blue);//(Manson, 2014)
        }


        // Responds to "frustrated" sentiment with a random empathetic message.
        private void frustratedResponse(string input)//(Programming, 2019)
        {
            List<string> _sentiment = new List<string>//(Programming, 2019)
            {
                "I hear you — it can be incredibly frustrating when things don’t seem to improve. Let’s troubleshoot together.",
                "Spam, scams, pop-ups — I get it. That stuff wears anyone down. But I’ve got a few tricks that might help.",
                "Yeah, that’s annoying. Online issues can really test your patience. Let’s get to the bottom of it.",
                "You're not alone. A lot of people feel that way when dealing with online problems. Let’s fix what we can.",
                "That kind of frustration is totally valid. Let me guide you through some ways to reduce those headaches."
            };

            string response = _sentiment[_random.Next(_sentiment.Count)];// (Plays, 2022)
            Speak(response, ConsoleColor.DarkRed);//(Manson, 2014)
        }


        // Responds to "overwhelmed" sentiment with a random supportive message.

        private void overwhelmedResponse(string input)//(Programming, 2019)
        {
            List<string> _sentiment = new List<string>//(Programming, 2019)
            {
                "There's a lot out there, and it’s easy to feel overloaded. Let’s take it one step at a time.",
                "Totally understandable — cybersecurity can feel like a huge topic. I’ll walk you through the basics.",
                "You’re doing great just by asking questions. No need to know it all at once — we’ll go slowly.",
                "Overwhelmed is a fair feeling. The internet throws a lot at us, but I can help break it down.",
                "Let’s breathe for a second. You’re not expected to master this overnight. Let’s tackle one topic together."
            };

            string response = _sentiment[_random.Next(_sentiment.Count)];// (Plays, 2022)
            Speak(response, ConsoleColor.Cyan);//(Manson, 2014)
        }


        // Responds to "skeptical" sentiment with a random validating message.
        private void skepticalResponse(string input)//(Programming, 2019)
        {
            List<string> _sentiment = new List<string>//(Programming, 2019)
            {
                "Skepticism is healthy. Let’s look at why these tips actually work, not just blindly follow them.",
                "That’s fair — some of it does sound too good to be true. Let me show you some real-world examples.",
                "It’s smart to question things. I’ll explain how small changes can really make a difference.",
                "I get that. Some of these threats don’t seem real until they hit home. Let’s look at some proof points.",
                "No pressure to believe everything right away — I’ll just share the facts, and you decide what makes sense."
            };

            string response = _sentiment[_random.Next(_sentiment.Count)];// (Plays, 2022)
            Speak(response, ConsoleColor.DarkGray);//(Manson, 2014)
        }

        //Tells a set of cybersecurity-themed dad jokes to the user.
        private void dadCyberSecurityJokes()//(Programming, 2019)
        {
            // List of cybersecurity dad jokes
            List<string> dadJokes = new List<string>//(Programming, 2019)//(Programming, 2019)
            {
                "Why did the hacker break up with the internet? There was no connection.",
                "I told my password it was too weak. It cried... and then got hacked.",
                "Why don’t hackers take vacations? Too afraid of leaving their cookies behind.",
                "Why did the computer keep sneezing? It had a bad case of CAPS LOCK!",
                "I asked the antivirus if it was feeling okay. It said, 'I'm just a bit overprotective.'",
                "My router and I had a fight... now we’re not talking. The signal's just not there anymore.",
                "Hackers wear leather jackets because they love brute-forcing their style."
            };

            // Tell 3 random jokes
            for (int i = 0; i < 2; i++)
            {
                string joke = dadJokes[_random.Next(dadJokes.Count)];// (Plays, 2022)
                Speak(joke, ConsoleColor.Green);//(Manson, 2014)
                PlaySound("joke.wav");//(O'Didily, 2022)
                Thread.Sleep(1000); // pause for effect
            }
            PlaySound("BOO.wav");//(O'Didily, 2022)
            Speak("Alright, enough jokes! Let's get serious about cybersecurity. Ready to learn?", ConsoleColor.Cyan);//(Manson, 2014)
        }

        // Provides a random tip for the specified cybersecurity topic, using a color associated with the topic.
        private void RespondWithRandomTip(string topic)//(Monkey, 2020)
        {
            if (topicTips.ContainsKey(topic))//(Corey, 2023)
            {
                var tips = topicTips[topic];//(Monkey, 2020)
                string randomTip = tips[_random.Next(tips.Count)];// (Plays, 2022)

                // Try to get a color for the topic, fallback to Gray if not found
                ConsoleColor color = topicColors.ContainsKey(topic) ? topicColors[topic] : ConsoleColor.Gray;//(Corey, 2023)
                Speak(randomTip, color);//(Manson, 2014)
            }
            else
            {
                Speak("Sorry, I don't have tips on that topic yet.", ConsoleColor.Red);//(Manson, 2014)
            }
        }
    }
}
/*
Reference List
Corey, T., 2023. The Dictionary Data Structure in C# in 10 Minutes or Less. [Online] 
Available at: https://www.youtube.com/watch?v=R94JHIXdTk0&list=TLPQMjUwNTIwMjXgYKPv1HBduQ&index=4
[Accessed 26 May 2025].
Manson, J., 2014. C# Development Tutorial | Speech Synthesis. [Online] 
Available at: https://www.youtube.com/watch?v=gkTiKMSLOHY&list=TLPQMjUwNTIwMjV5DPeJRoATSg&index=5
[Accessed 25 May 2025].
Monkey, C., 2020. What are Delegates? (C# Basics, Lambda, Action, Func). [Online] 
Available at: https://www.youtube.com/watch?v=3ZfwqWl-YI0&list=TLPQMjUwNTIwMjXgYKPv1HBduQ&index=2
[Accessed 26 May 2025].
O'Didily, M., 2022. How to Play Music In C#. [Online] 
Available at: https://youtu.be/uZlz1SSisYY?si=aH0bDU7yFD15kiSU
[Accessed 25 May 2025].
Opus), B. (., 2013. C# Text to Speech using Speech.Synthesis. [Online] 
Available at: https://www.youtube.com/watch?v=4zdmSVgtfkU&list=TLPQMjUwNTIwMjXgYKPv1HBduQ&index=1
[Accessed 26 May 2025].
Plays, K., 2022. C# Tutorial for Beginners #33 - Random. [Online] 
Available at: https://www.youtube.com/watch?v=Ww5897-l_K0
[Accessed 26 May 2025].
Programming, J. T., 2019. C# List Tutorial How to Use Lists. [Online] 
Available at: https://www.youtube.com/watch?v=LJAxwrIw0SA&list=TLPQMjUwNTIwMjXgYKPv1HBduQ&index=16
[Accessed 26 May 2025].
*/
