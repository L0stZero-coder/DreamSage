using System;
using System.Linq;

public class DreamAnalyzer
{
    public string ExtractKeywords(string text)
    {
        var commonWords = new[] { "the", "and", "but", "was", "were", "a", "in", "of" };
        var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(w => w.Trim().ToLower())
                        .Where(w => !commonWords.Contains(w) && w.Length > 3)
                        .GroupBy(w => w)
                        .OrderByDescending(g => g.Count())
                        .Take(5)
                        .Select(g => g.Key);

        return string.Join(", ", words);
    }
}
