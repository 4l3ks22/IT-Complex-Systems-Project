namespace WebLayer.Dtos
{
    public class TitleGenreDto
    {
        /*public string? Url { get; set; } // to obtain the URL in the weblayer.http
        // The title name

        public required string Tconst { get; set; }
        public required int GenreId { get; set; }*/ // We don’t need GenreId anymore because each title can have multiple genres.
        
        
        public string? Url { get; set; }
        public required string Tconst { get; set; }

        public string Title { get; set; } = string.Empty;

        public List<string> Genres { get; set; } = new();
        
       
    }
}