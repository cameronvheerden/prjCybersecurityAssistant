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

        public CyberSecurity()
        {
            //Set up Sentiment handlers
            sentimentResponses = new Dictionary<string, Action<string>>
            {
                {"worried", worriedResponse},
                {"curious", curiousResponse},
                {"frustrated", frustratedResponse},
                {"overwhelmed", overwhelmedResponse},
                {"skeptical", skepticalResponse}
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

    }
}
