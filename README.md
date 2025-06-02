# 🌙 DreamSage - Voice-Driven AI Dream Interpretation

**DreamSage** is a C# application that allows users to speak their dreams aloud and receive instant, AI-generated interpretations through both text and speech. It combines Speech-to-Text (STT), AI analysis (using OpenAI or Azure), and Text-to-Speech (TTS) to create a seamless and intelligent dream journaling experience.

---

## 🧠 Features

- 🎙️ **Voice input**: Speak your dream, no typing needed.
- 🧾 **Natural language transcription** using Speech-to-Text.
- 🔍 **Keyword and emotional analysis** from dream content.
- 🤖 **AI-generated dream interpretations** via OpenAI GPT-4.
- 🗣️ **Text-to-Speech response**: The AI reads its interpretation aloud.
- 📚 **Dream log** saved locally in JSON for reflection or trends.

---

## 🏗️ Architecture Overview

```plaintext
Voice Input (STT) → Dream Analyzer → AI Interpretation (OpenAI) → TTS Output
                                               ↓
                                         Dream Log JSON
```

---

## 🚀 Getting Started

### ✅ Prerequisites

- [.NET 6 or later](https://dotnet.microsoft.com/)
- A Windows system (for System.Speech)
- [OpenAI API key](https://platform.openai.com/account/api-keys)

### 🧩 Dependencies

Install the required NuGet packages:

```bash
dotnet add package Newtonsoft.Json
dotnet add package Microsoft.CognitiveServices.Speech # Optional, for Azure STT/TTS
```

System.Speech is part of .NET Framework, no installation required.

---

## 🛠️ Setup & Run

1. **Clone the repository:**

   ```bash
   git clone https://github.com/YOUR_USERNAME/DreamSage.git
   cd DreamSage
   ```

2. **Open in Visual Studio** or run via CLI:

   ```bash
   dotnet run
   ```

3. **Speak your dream** into the microphone when prompted.
4. **Hear the AI interpretation** read back to you.
5. Dreams are automatically saved in `DreamLog.json`.

---

## 🔑 Configuration

In `AiService.cs`, replace:

```csharp
private readonly string apiKey = "YOUR_OPENAI_API_KEY";
```

with your actual OpenAI API key.

---

## 📁 Project Structure

```plaintext
DreamSage/
├── Program.cs               // Entry point
├── UserInterface.cs         // Main control loop
├── VoiceListener.cs         // STT input
├── VoiceResponder.cs        // TTS output
├── DreamAnalyzer.cs         // Keyword extractor
├── InterpretationEngine.cs  // AI interaction
├── AiService.cs             // OpenAI API integration
├── Dream.cs                 // Dream data model
└── DreamLog.json            // Local saved dream history
```

---

## 📦 Future Features

- 🌍 Multilingual support
- 📊 Visual trend analysis of dream themes
- 🔐 Secure, encrypted dream storage
- ☁️ Cloud sync for multiple devices

---

## 🤝 Contributing

Pull requests are welcome! Feel free to fork the repo and propose improvements or new features.

---

## 📝 License

MIT License. See `LICENSE` file for details.

---

## 💬 Credits

Developed by **[Your Name]**  
Powered by OpenAI GPT and .NET Speech Libraries

---

## 🌌 Example Prompt

> "I was flying through a thunderstorm, then I fell into the ocean."

💡 DreamSage might respond with:

> "Flying often symbolizes a desire for freedom or escape. Storms may indicate internal turmoil, while falling can reflect a fear of failure. The ocean represents deep emotions..."