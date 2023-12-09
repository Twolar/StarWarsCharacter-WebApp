using Microsoft.AspNetCore.Mvc;

namespace StarWarsCharacter_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CharactersController : ControllerBase
{
    public CharactersController() { }

    [HttpGet]
    public async Task<IActionResult> GetCharacters()
    {
        var characters = new List<object> {
            new {
                Name = "TestName1",
                Type = "Jedi",
                LightSaberColor = "Blue"
            },
            new {
                Name = "TestName2",
                Type = "Sith",
                LightSaberColor = "Red"
            },
            new {
                Name = "TestName3",
                Type = "Jedi",
                LightSaberColor = "Green"
            },
        };

        return Ok(characters);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCharacter(int id)
    {
        var character = new
        {
            Name = "TestName2",
            Type = "Sith",
            LightSaberColor = "Red"
        };

        return Ok(character);
    }
}