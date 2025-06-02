using System.Threading.Tasks;

public class InterpretationEngine
{
    private readonly AiService ai;

    public InterpretationEngine()
    {
        ai = new AiService();
    }

    public async Task<string> GenerateInterpretationAsync(string dreamText)
    {
        string prompt = $"Interpret this dream text from a psychological and symbolic perspective:\n\"{dreamText}\"";
        return await ai.SendPromptAsync(prompt);
    }
}
