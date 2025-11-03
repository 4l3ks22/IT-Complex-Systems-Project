using System;
using System.Collections.Generic;
using WebLayer.Dtos;

namespace EntityFramework.Models;

public class PersonDto
{
    public string? Url { get; set; }
    public string? Primaryname { get; set; }
    public string? Birthyear { get; set; }
    public string? Deathyear { get; set; }

    public List<string> Professions { get; set; } = new();
    
    public double PersonRating { get; set; }
    public List<TitleDto> Titles { get; set; } = new();
    public List<KnownForTitleDto> KnownForTitles { get; set; } = new();
    
}