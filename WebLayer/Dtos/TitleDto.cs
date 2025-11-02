using System.Text.Json.Serialization;
using WebLayer.Dtos;

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
    //public List<string> genres { get; set; } // to show genres in titles intead of null
    public string? Genres { get; set; } // to show genres in titles intead of null
    
    public TitleExtraDto? TitleExtras { get; set; }  // This is the whole TitleExtra object to adapt to TitleDto
    
    public RatingDto? TitleRating { get; set; }  // This is the whole TitleRating object to adapt to TitleDto
    //public VersionDto? Versions { get; set; }  // This is the whole TitleRating object to adapt to TitleDto
    
    public List<VersionDto>? Versions { get; set; } // This is the whole Version object to adapt to TitleDto

}