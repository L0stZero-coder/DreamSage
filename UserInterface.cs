using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class UserInterface
{
    private readonly string logFile = "DreamLog.json";
    private readonly List<Dream> dreamLog = new();
    private readonly DreamAnalyzer analyzer = new();
    private readonly InterpretationEngine engine = new();
    private readonly VoiceListener voiceInput = new();
    private readonly VoiceResponder voiceOutput = new();

    public async void Start()
    {
        LoadDreams();

        Console.WriteLine("🎙️ Welcome to DreamSage 🌙");
        Console.WriteLine("Speak your dream aloud and let the AI analyze it.\n");

        while (true)
        {
            Console.Write("Press [Enter] to record your dream or type 'exit': ");
            string command = Console.ReadLine()?.Trim().ToLower();
            if (command == "exit") break;

            string spokenDream = voiceInput.Listen();
            if (string.IsNullOrWhiteSpace(spokenDream))
            {
                Console.WriteLine("⚠️ No voice input detected. Please try again.\n");
                continue;
            }

            var dream = new Dream { Description = spokenDream };

            string keywords = analyzer.ExtractKeywords(spokenDream);
            Console.WriteLine($"🧠 Extracted Keywords: {keywords}\n");

            Console.WriteLine("🔮 Generating interpretation with AI...\n");
            dream.Interpretation = await engine.GenerateInterpretationAsync(spokenDream);

            Console.WriteLine("📘 Interpretation:");
            Console.WriteLine(dream.Interpretation + "\n");

            // Speak interpretation aloud
            voiceOutput.Speak(dream.Interpretation);

            dreamLog.Add(dream);
            SaveDreams();

            Console.WriteLine("✅ Dream saved.\n");
        }

        Console.WriteLine("👋 Exiting DreamSage. Sweet dreams!");
    }

    private void LoadDreams()
    {
        if (File.Exists(logFile))
        {
            try
            {
                var json = File.ReadAllText(logFile);
                var loadedDreams = JsonConvert.DeserializeObject<List<Dream>>(json);
                if (loadedDreams != null)
                    dreamLog.AddRange(loadedDreams);
            }
            catch
            {
                Console.WriteLine("⚠️ Could not load previous dream logs. Starting fresh.");
            }
        }
    }

    private void SaveDreams()
    {
        try
        {
            File.WriteAllText(logFile, JsonConvert.SerializeObject(dreamLog, Formatting.Indented));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Failed to save dream log: {ex.Message}");
        }
    }
}
