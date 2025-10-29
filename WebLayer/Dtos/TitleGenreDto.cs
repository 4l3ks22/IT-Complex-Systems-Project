namespace WebLayer.Dtos
{
    public class TitleGenreDto
    {
        public string? Url { get; set; } // to obtain the URL in the weblayer.http
        // The title name
        public string Title { get; set; } = string.Empty;

        // List of genre names
        public List<string> Genres { get; set; } = new List<string>();
    }
}