namespace WebLayer.Dtos;

public class EpisodeDto
{
    /*public string? Url {get; set;}
    public string? SeriesName { get; set; }
    public string? Name { get; set; }
    public int? Season { get; set; }
    public int? Episode { get; set; }*/
    
    
    public string? EpisodeUrl {get; set;}
    
    //public string Tconst { get; set; } = null!;

    //public string? Parenttconst { get; set; }
    public string SerieName { get; set; }// added by cesar

    public int? Seasonnumber { get; set; }

    public int? Episodenumber { get; set; }
    
    public string? Genres { get; set; }
    
    public string? SerieUrl { get; set; }
    
    
}