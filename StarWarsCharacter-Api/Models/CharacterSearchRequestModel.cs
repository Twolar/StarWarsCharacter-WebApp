using System.ComponentModel.DataAnnotations;

namespace StarWarsCharacter_Api;

public class CharacterSearchRequestModel
{
    [Required]
    public string? SearchValue { get; set; }
}
