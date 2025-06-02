using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class AiService
{
    private readonly string apiKey = "YOUR_OPENAI_API_KEY"; // Replace with your real key
    private readonly HttpClient httpClient = new();

    public AiService()
    {
        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", apiKey);
    }

    public async Task<string> SendPromptAsync(string prompt)
    {
        var data = new
        {
            model = "gpt-4",
            messages = new[] {
                new { role = "system", content = "You are a dream analyst." },
                new { role = "user", content = prompt }
            },
            temperature = 0.7
        };

        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
        var resultJson = await response.Content.ReadAsStringAsync();
        dynamic result = JsonConvert.DeserializeObject(resultJson);
        return result.choices[0].message.content;
    }
}
