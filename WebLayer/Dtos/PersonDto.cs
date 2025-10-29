using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public class PersonDto
{
    public string? Url { get; set; }
    public string? Primaryname { get; set; }
    public string? Birthyear { get; set; }
    public string? Deathyear { get; set; }

    
    public List<TitleDto> Titles { get; set; } = new();
    
    public List<string> Professions { get; set; } = new();

    public double Rating { get; set; }
    
}