public class TitleDto
{
    public string? Url { get; set; } // to obtain the URL in the weblayer.http
    public string Primarytitle { get; set; }
    public string Originaltitle { get; set; }
    public string? Titletype { get; set; }
    public bool Isadult { get; set; }
    public string? Startyear { get; set; }
    public string? Endyear { get; set; }
    public int? Runtimeminutes { get; set; }
}