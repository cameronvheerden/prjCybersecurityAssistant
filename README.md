# Cybersecurity Awareness Chatbot — Part 2

## Overview

This is Part 2 of the Cybersecurity Awareness Chatbot assignment. In this part, the chatbot is extended to provide dynamic responses, keyword recognition, memory recall, and sentiment detection for a more interactive experience.

---

## Features

- **Keyword Recognition:** Recognises cybersecurity-related keywords (e.g., `phishing`, `password`, `social engineering`) and provides relevant guidance.
- **Random Responses:** Delivers varied responses for certain topics (such as phishing) using random selection from a list or array.
- **Conversation Flow:** Maintains a seamless conversation, handling follow-up questions and keeping context.
- **Memory and Recall:** Remembers user details (like name or favourite cybersecurity topics) for personalisation.
- **Sentiment Detection:** Adjusts responses based on detected user sentiment (e.g., worried, curious, frustrated).
- **Error Handling:** Handles unknown inputs gracefully with a default response.
- **Optimised Code:** Uses collections, delegates, and modular design for code clarity and efficiency.

---

## Installation Instructions

### Using Command Line (cmd, PowerShell, or Bash)

1. **Clone the Repository**

   ```bash
   git clone https://github.com/cameronvheerden/prjCybersecurityAssistant.git
   cd prjCybersecurityAssistant/prjCybersecurityAssistant
   ```
   > _Note: If your solution file is in a different folder, navigate to the folder containing your `.csproj` or `.sln` file._

2. **Restore Dependencies**

   ```bash
   dotnet restore
   ```

3. **Build the Project**

   ```bash
   dotnet build
   ```

4. **Run the Chatbot**

   ```bash
   dotnet run
   ```

### Using Visual Studio (or your preferred C# IDE)

1. Open the solution in Visual Studio.
2. Restore NuGet packages if prompted.
3. Build the project (`Ctrl+Shift+B`).
4. Run the chatbot by pressing `F5` or clicking "Start".

---

## Installation Instructions (Using GitHub Releases)

To install and run the Cybersecurity Awareness Chatbot using the pre-built release files from GitHub:

1. **Go to the Releases Page**
   - On your repository's GitHub page, look for the **"Releases"** section on the right-hand side.
   - Or, click on the **"Releases"** link or tab (usually found near the top or right of your repo page).

2. **Download the Latest Release**
   - Find the latest release (at the top of the list).
   - Under "Assets", download the file that matches your operating system (for example: `.zip` for Windows, `.tar.gz` for Linux/Mac).

3. **Extract the Files**
   - Windows: Right-click the `.zip` file and choose "Extract All..."
   - Mac/Linux: Use Finder or run `tar -xzf <file>.tar.gz` in the terminal.

4. **Run the Application**
   - Open the extracted folder.
   - Double-click the executable file (for example, `CybersecurityChatbot.exe` on Windows).
   - **OR** open a terminal/command prompt in the extracted directory and run the executable (for example: `./CybersecurityChatbot`).

5. **Start Interacting**
   - Follow the prompts in the console to begin chatting with the Cybersecurity Awareness Chatbot!

---

**Note:**  
If you get a warning about running files from the internet, you may need to allow or unblock the executable depending on your operating system.

For advanced users, you can still build from source by following the instructions in the main README.

---

## How to Use

- Start the chatbot and interact via the console.
- Try asking about cybersecurity topics such as:
    - "Tell me about password safety."
    - "Give me a phishing tip."
    - "I'm worried about online scams."
    - "I am interested in privacy."
- The chatbot will recognise keywords, select responses randomly when appropriate, recall your interests, and adjust its tone based on your input.

---

## GitHub Actions Workflow

> **Screenshots**
>
> - Screenshots of my GitHub Actions workflow passing successfully.
> ![image](https://github.com/user-attachments/assets/66bf054e-08d1-46f5-aef4-2c2bfa8015e3)

> ![image](https://github.com/user-attachments/assets/b138f04d-4150-45f6-b315-ac808574b9b9)


---

## Demo Video

> **YouTube Video Link**
>
> - YouTube video that demonstrates the chatbot in action.
>
> [YouTube Link][(PASTE_YOUR_LINK_HERE)](https://youtu.be/2HEV3OUzM2U)

---

## Requirements Addressed

- [x] Keyword recognition for key cybersecurity topics
- [x] Randomised responses for certain queries
- [x] Natural conversation flow and topic continuation
- [x] Memory and recall of user details
- [x] Sentiment detection and empathetic responses
- [x] Graceful error handling and edge case coverage
- [x] Efficient use of collections and delegates; modular, organised code

---

## Notes

- For any issues or questions, please refer to the code comments or raise an issue on this repository.
- This chatbot is designed for educational purposes and can be further expanded in future assignments.

---
# Reference List

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

---
