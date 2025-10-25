namespace WebLayer.Dtos
{
    public class TitleGenreDto
    {
        // The title name
        public string TitleName { get; set; } = string.Empty;

        // List of genre names
        public List<string> Genres { get; set; } = new List<string>();
    }
}