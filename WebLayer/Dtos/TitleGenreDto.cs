namespace WebLayer.Dtos
{
    public class TitleGenreDto
    {
        public string? Url { get; set; }
        public required string Tconst { get; set; }

        public string Title { get; set; } = string.Empty;

        public List<string> Genres { get; set; } = new();
        
       
    }
}