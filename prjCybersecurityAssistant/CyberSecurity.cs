using System;
using System.Speech.Synthesis;

namespace prjCybersecurityAssistant
{
    public class CyberSecurity : VoiceAssistant
    {
        //Memory for user details
        private string userName = "";
        private string favouriteTopic = "";

        // Random instance for generating random responses from the assistant
        private readonly Random _random;

        //Dictionary to hold sentiment responses
        private Dictionary<string, Action<string>> sentimentResponses;

        //Dictionary to hold keyword handlers
        private Dictionary<string, Action<string>> keywordHandler;


        //Collection of keywords and their associated Colours for the chatbots responses
        private Dictionary<string, ConsoleColor> topicColors = new Dictionary<string, ConsoleColor>(StringComparer.OrdinalIgnoreCase)
        {
            ["phishing"] = ConsoleColor.Yellow,
            ["strong passwords"] = ConsoleColor.Green,
            ["suspicious links"] = ConsoleColor.Magenta,
            ["social engineering"] = ConsoleColor.DarkCyan,
            ["general"] = ConsoleColor.White
        };


        //Generic dictionary to hold keyword responses
        private Dictionary<string, List<string>> topicTips = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {
            ["phishing"] = new List<string>
            {
                "Phishing scams are like digital fishing trips — but instead of fish, scammers are after your passwords, bank info, and personal details.",
                "Phishing emails might look official, but they often contain spelling errors, weird links, or suspicious attachments.",
                "Watch out for urgent language like 'Your account will be suspended' or 'Act now!' scammers use fear to pressure you into clicking.",
                "Hover over links before clicking them. If the web address looks odd or doesn’t match the sender, it’s probably a trap.",
                "No legit company will ask for your password or credit card info over email. When in doubt, contact the company directly using a verified method.",
                "Phishing can also happen through texts and social media not just email. If a message feels off, trust your gut and double-check.",
                "If something feels fishy — it probably is. Always pause and verify before clicking or replying."
            },

            ["passwords"] = new List<string>
            {
                "Think of your password like a toothbrush never share it, change it often, and don’t use your name on it!",
                "Use a mix of letters, numbers, and symbols and skip the obvious stuff like '123456' or 'password'.",
                "The longer your password, the stronger it is. Try using a funny sentence or phrase you’ll remember.",
                "Don’t reuse the same password for multiple sites if one gets hacked, the rest are at risk.",
                "Use a password manager. It remembers the complicated stuff so you don’t have to.",
                "Avoid using birthdays, pet names, or your favorite band hackers can guess these easily with a little digging.",
                "Update your passwords regularly, especially if you’ve heard about a data breach from a site you use."
            },

            ["suspicious links"] = new List<string>
            {
                "A suspicious link is like a sketchy shortcut in a video game it might take you somewhere dangerous!",
                "Always hover over a link to see where it *really* goes before clicking. If it looks weird, skip it.",
                "Shortened links (like bit.ly) can hide the true destination only click if you trust the source.",
                "If a link promises free money, miracle cures, or secret tips it’s probably bait.",
                "Don't click random links in comment sections, DMs, or unfamiliar emails they're prime spots for scams.",
                "Even if a link looks okay, if you didn’t expect it or the message feels off, double-check with the sender.",
                "Bad links can install malware just from visiting the site be picky about what you open."
            },

            ["social engineering"] = new List<string>
            {
                "Social engineering is basically hacking the human scammers trick you into handing over info willingly.",
                "If someone asks for your password, even if they sound official, stop right there. Real support never does that.",
                "Scammers often pretend to be your boss, bank, or even a family member. When in doubt, call them directly to confirm.",
                "Don’t overshare online scammers use your public posts to guess passwords or security questions.",
                "Always ask yourself: why does this person need this info? If it doesn’t make sense, don’t give it.",
                "If it feels like someone’s trying too hard to gain your trust online, they might be trying to manipulate you.",
                "Stay alert being friendly is great, but don’t let politeness cost you your personal info."
            },

            ["general"] = new List<string>
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


        public CyberSecurity()
        {
            //Initialze a new Random instance for generating random responses
            _random = new Random();

            //Set up Sentiment handlers
            sentimentResponses = new Dictionary<string, Action<string>>(StringComparer.OrdinalIgnoreCase)
            {
                {"worried", worriedResponse},
                {"curious", curiousResponse},
                {"frustrated", frustratedResponse},
                {"overwhelmed", overwhelmedResponse},
                {"skeptical", skepticalResponse}
            };

            //Set up Keyword handlers
            keywordHandler = new Dictionary<string, Action<string>>(StringComparer.OrdinalIgnoreCase)
            {
                {"phishing", input => RespondWithRandomTip("phishing")},
                {"passwords", input => RespondWithRandomTip("passwords")},
                {"suspicious links", input => RespondWithRandomTip("suspicious links")},
                {"social engineering", input => RespondWithRandomTip("social engineering")},
                {"general", input => RespondWithRandomTip("general")}
            };
        }

        public void Start()
        {

        }

        private void worriedResponse(string input)
        {
            List<string> _sentiment = new List<string>
            {
              "It's completely understandable to feel worried or anxious browsing the web." +
              "Scammers can be very cruel and they exploit innocent vunerable people but thats why I am here to assist you",
              "That makes sense the internet can feel like a risky place sometimes. You're not alone in feeling this way, and I can help you spot the red flags",
              "Worry is totally valid, especially with all the scams going around. Let's take it step by step and go over how you can stay protected.",
              "I get it cybersecurity can seem overwhelming at first. But once you know what to watch out for, it becomes much more manageable.",
              "It's normal to feel a bit anxious about online safety. The good news is that there are practical steps we can take together to minimize those risks.",
              "It’s good that you’re paying attention. Feeling worried shows you’re taking things seriously, and that’s the first step toward staying safe.",
              "You're right to be cautious. Let's talk about some simple habits you can build to feel more confident online."
            };

            // Randomly select a response from the list
            string response = _sentiment[_random.Next(_sentiment.Count)];
            Speak(response, ConsoleColor.DarkYellow);
        }


        private void curiousResponse(string input)
        {
            List<string> _sentiment = new List<string>
            {
                "Curiosity is a great starting point. Let me show you how things like phishing and data breaches actually work.",
                "That’s a good question. Learning how the risks work helps you spot and avoid them — let’s dive into it.",
                "I love that you're curious! The more you know, the safer you’ll be. Want to hear about how hackers use fake websites?",
                "Curious minds are the best defenders. Let’s explore how online threats happen and how you can prevent them.",
                "Great question! The web has many layers, and understanding how attacks work gives you the upper hand."
            };

            string response = _sentiment[_random.Next(_sentiment.Count)];
            Speak(response, ConsoleColor.Blue);
        }

        private void frustratedResponse(string input)
        {
            List<string> _sentiment = new List<string>
            {
                "I hear you — it can be incredibly frustrating when things don’t seem to improve. Let’s troubleshoot together.",
                "Spam, scams, pop-ups — I get it. That stuff wears anyone down. But I’ve got a few tricks that might help.",
                "Yeah, that’s annoying. Online issues can really test your patience. Let’s get to the bottom of it.",
                "You're not alone. A lot of people feel that way when dealing with online problems. Let’s fix what we can.",
                "That kind of frustration is totally valid. Let me guide you through some ways to reduce those headaches."
            };

            string response = _sentiment[_random.Next(_sentiment.Count)];
            Speak(response, ConsoleColor.DarkRed);
        }
        private void overwhelmedResponse(string input)
        {
            List<string> _sentiment = new List<string>
            {
                "There's a lot out there, and it’s easy to feel overloaded. Let’s take it one step at a time.",
                "Totally understandable — cybersecurity can feel like a huge topic. I’ll walk you through the basics.",
                "You’re doing great just by asking questions. No need to know it all at once — we’ll go slowly.",
                "Overwhelmed is a fair feeling. The internet throws a lot at us, but I can help break it down.",
                "Let’s breathe for a second. You’re not expected to master this overnight. Let’s tackle one topic together."
            };

            string response = _sentiment[_random.Next(_sentiment.Count)];
            Speak(response, ConsoleColor.Cyan);
        }

        private void skepticalResponse(string input)
        {
            List<string> _sentiment = new List<string>
            {
                "Skepticism is healthy. Let’s look at why these tips actually work, not just blindly follow them.",
                "That’s fair — some of it does sound too good to be true. Let me show you some real-world examples.",
                "It’s smart to question things. I’ll explain how small changes can really make a difference.",
                "I get that. Some of these threats don’t seem real until they hit home. Let’s look at some proof points.",
                "No pressure to believe everything right away — I’ll just share the facts, and you decide what makes sense."
            };

            string response = _sentiment[_random.Next(_sentiment.Count)];
            Speak(response, ConsoleColor.DarkGray);
        }

        // Generic delegate method for topic tips with random Colours for each topic
        private void RespondWithRandomTip(string topic)
        {
            if (topicTips.ContainsKey(topic))
            {
                var tips = topicTips[topic];
                string randomTip = tips[_random.Next(tips.Count)];

                // Try to get a color for the topic, fallback to Gray if not found
                ConsoleColor color = topicColors.ContainsKey(topic) ? topicColors[topic] : ConsoleColor.Gray;
                Speak(randomTip, color);
            }
            else
            {
                Speak("Sorry, I don't have tips on that topic yet.", ConsoleColor.Red);
            }
        }

    }
}
