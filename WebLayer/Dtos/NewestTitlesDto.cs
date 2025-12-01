namespace WebLayer.Dtos;

public class NewestTitlesDto
{
    public string Tconst { get; set; }
    public string TitleType { get; set; }
    public string PrimaryTitle { get; set; }
    public string OriginalTitle { get; set; }
    public int? StartYear { get; set; }
    public double? AverageRating { get; set; }
    public int? NumVotes { get; set; }
}
