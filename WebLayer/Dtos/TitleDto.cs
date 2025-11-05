using System.Text.Json.Serialization;

namespace WebLayer.Dtos;

public class TitleDto
{
    [JsonIgnore]
    public string Tconst { get; set; }
    public string? Url { get; set; } // to obtain the URL in the weblayer.http
    public string Primarytitle { get; set; }
    public string Originaltitle { get; set; }
    public string? Titletype { get; set; }
    public bool Isadult { get; set; }
    public string? Startyear { get; set; }
    public string? Endyear { get; set; }
    public int? Runtimeminutes { get; set; }

    public List<String>? TitleGenres { get; set; }
    public TitleExtraDto? TitleExtras { get; set; }  // This is the whole TitleExtra object to adapt to TitleDto
    
    public RatingDto? TitleRating { get; set; }  // This is the whole TitleRating object to adapt to TitleDto
}