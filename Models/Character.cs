using System.Text.Json.Serialization;

internal class Character
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("culture")]
    public string Culture { get; set; }

    [JsonPropertyName("born")]
    public string Born { get; set; }

    [JsonPropertyName("died")]
    public string Died { get; set; }

    [JsonPropertyName("titles")]
    public List<string> Titles { get; set; }

    [JsonPropertyName("aliases")]
    public List<string> Aliases { get; set; }

    [JsonPropertyName("father")]
    public string Father { get; set; }

    [JsonPropertyName("mother")]
    public string Mother { get; set; }

    [JsonPropertyName("spouse")]
    public string Spouse { get; set; }

    [JsonPropertyName("allegiances")]
    public List<string> Allegiances { get; set; }

    [JsonPropertyName("books")]
    public List<string> Books { get; set; }

    [JsonPropertyName("povBooks")]
    public List<string> PovBooks { get; set; }

    [JsonPropertyName("tvSeries")]
    public List<string> TvSeries { get; set; }

    [JsonPropertyName("playedBy")]
    public List<string> PlayedBy { get; set; }


    public void ShowDetails()
    {
        Console.WriteLine($"Details\nName: {Name}");
        Console.WriteLine($"Gender: {Gender}");
        Console.WriteLine($"Culture: {Culture}");
        Console.WriteLine($"Born: {Born}");
        Console.WriteLine($"Died: {(string.IsNullOrEmpty(Died) ? "Still alive (in data)" : Died)}");

        if (Titles != null && Titles.Count > 0)
            Console.WriteLine($"Titles: {string.Join(", ", Titles)}");

        if (Aliases != null && Aliases.Count > 0)
            Console.WriteLine($"Aliases: {string.Join(", ", Aliases)}");

        if (PlayedBy != null && PlayedBy.Count > 0)
            Console.WriteLine($"Played by: {string.Join(", ", PlayedBy)}");
    }

}