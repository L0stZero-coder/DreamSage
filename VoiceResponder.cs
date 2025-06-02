using System.Speech.Synthesis;

public class VoiceResponder
{
    private readonly SpeechSynthesizer synthesizer = new();

    public void Speak(string text)
    {
        synthesizer.SelectVoiceByHints(VoiceGender.Female);
        synthesizer.SpeakAsync(text);
    }
}
