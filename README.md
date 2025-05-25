# Cybersecurity Awareness Chatbot — Part 2

## Overview

This is Part 2 of the Cybersecurity Awareness Chatbot assignment. In this part, the chatbot is extended to provide dynamic responses, keyword recognition, memory recall, and sentiment detection for a more interactive and educational experience. The chatbot now simulates a natural conversation flow and supports cybersecurity awareness through personalised and empathetic interactions.

---

## Features

- **Keyword Recognition:** Recognises cybersecurity-related keywords (e.g., `password`, `scam`, `privacy`) and provides relevant guidance.
- **Random Responses:** Delivers varied responses for certain topics (such as phishing) using random selection from a list or array.
- **Conversation Flow:** Maintains a seamless conversation, handling follow-up questions and keeping context.
- **Memory and Recall:** Remembers user details (like name or favourite cybersecurity topics) for personalisation.
- **Sentiment Detection:** Adjusts responses based on detected user sentiment (e.g., worried, curious, frustrated).
- **Error Handling:** Handles unknown inputs gracefully with a default response.
- **Optimised Code:** Uses collections, delegates, and modular design for code clarity and efficiency.

---

## Installation Instructions

1. **Clone the Repository**
    ```bash
    git clone <YOUR_REPOSITORY_URL>
    cd <YOUR_REPOSITORY_DIRECTORY>
    ```

2. **Open the Project**
    - Open the solution in Visual Studio (or your preferred C# IDE).

3. **Restore Dependencies**
    - If using .NET Core/5+/6+, restore NuGet packages:
      ```bash
      dotnet restore
      ```

4. **Build the Project**
    - In Visual Studio: Press `Ctrl+Shift+B`
    - Or via CLI:
      ```bash
      dotnet build
      ```

5. **Run the Chatbot**
    - In Visual Studio: Press `F5` or click "Start"
    - Or via CLI:
      ```bash
      dotnet run
      ```

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
> - Please include one or more screenshots here showing your GitHub Actions workflow passing successfully.
>
> ![Workflow Success Screenshot 1](UPLOAD_SCREENSHOT_HERE)
> ![Workflow Success Screenshot 2](UPLOAD_ANOTHER_SCREENSHOT_HERE)

---

## Demo Video

> **YouTube Video Link**
>
> - Upload your demo video to YouTube and paste the link below to demonstrate the chatbot in action.
>
> [YouTube Demo Link](PASTE_YOUR_LINK_HERE)

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
