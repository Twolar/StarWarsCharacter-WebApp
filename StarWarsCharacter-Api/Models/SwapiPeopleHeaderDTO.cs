namespace StarWarsCharacter_Api.Models;

public class SwapiPeopleHeaderDTO
{
    public int? Count { get; set; }
    public string? Next { get; set; }
    public string? Previous { get; set; }
    public List<SwapiPersonDTO>? Results { get; set; }
}
