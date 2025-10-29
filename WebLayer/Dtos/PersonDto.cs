using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public class PersonDto
{
    public string? PrimaryName { get; set; }
    public string? BirthYear { get; set; }
    public string? DeathYear { get; set; }

    
    public List<TitleDto> Titles { get; set; } = new();
    
    public List<string> Professions { get; set; } = new();

    public double Rating { get; set; }
}