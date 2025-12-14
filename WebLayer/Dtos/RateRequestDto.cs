namespace WebLayer.Dtos;

public class RateRequestDto
{
    public int UserId { get; set; }
    public string Tconst { get; set; } = null!;
    public int Rating { get; set; }
}