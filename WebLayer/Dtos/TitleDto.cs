namespace WebLayer.Dtos;

public class TitleDto
{
    public string PrimaryName { get; set; } 
    public string OriginalName { get; set; }
    public string? Type { get; set;}
    public bool IsAdult {get; set;}
    public string? StartYear { get; set;}
    public string? EndYear { get; set;}
    public int? RuntimeMinutes { get; set; }

}

