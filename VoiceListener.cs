using System;
using System.Speech.Recognition;

public class VoiceListener
{
    private string lastResult = string.Empty;

    public string Listen()
    {
        using SpeechRecognitionEngine recognizer = new();
        recognizer.SetInputToDefaultAudioDevice();
        recognizer.LoadGrammar(new DictationGrammar());

        Console.WriteLine("🎙️ Listening... Speak now.");

        var completed = new System.Threading.ManualResetEvent(false);
        recognizer.SpeechRecognized += (s, e) =>
        {
            lastResult = e.Result.Text;
            completed.Set();
        };

        recognizer.RecognizeAsync(RecognizeMode.Single);
        completed.WaitOne();
        recognizer.RecognizeAsyncStop();

        Console.WriteLine($"📥 Transcribed: {lastResult}\n");
        return lastResult;
    }
}
