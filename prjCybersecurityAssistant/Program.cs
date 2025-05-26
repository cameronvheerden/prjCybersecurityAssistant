using System;

    namespace prjCybersecurityAssistant
{
    //Entry point for the Cybersecurity Assistant application.
    // Instantiates the CyberSecurity chatbot and starts the interactive session.
    internal class Program
    {
        /// Main method: creates and runs the CyberSecurity assistant.
        static void Main(string[] args)
        {
            CyberSecurity assistant = new CyberSecurity();
            assistant.Start();
        }
    }
}
