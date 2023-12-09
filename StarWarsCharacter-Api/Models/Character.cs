namespace StarWarsCharacter_Api.Models;

public class Character
{
    public int? Id { get; set; }
    public string? BirthYear { get; set; }
    public string? EyeColor { get; set; }
    public List<string>? Films { get; set; }
    public string? Gender { get; set; }
    public string? HairColor { get; set; }
    public string? Height { get; set; }
    public string? Homeworld { get; set; }
    public string? Mass { get; set; }
    public string? Name { get; set; }
    public string? SkinColor { get; set; }
    public string? Created { get; set; }
    public string? Edited { get; set; }
    public List<string>? Species { get; set; }
    public List<string>? Starships { get; set; }
    public string? Url { get; set; }
    public List<string>? Vehicles { get; set; }
}