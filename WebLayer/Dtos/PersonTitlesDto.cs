using System.Text.Json.Serialization;

namespace WebLayer.Dtos;

public class PersonTitlesDto
{
    public string? Url { get; set; }
    public string Title { get; set; } = null!;

    public string? Category { get; set; }

    [JsonIgnore] 
    public string Tconst { get; set; } = null!;
}