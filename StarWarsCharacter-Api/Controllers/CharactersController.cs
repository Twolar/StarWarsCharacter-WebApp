using Microsoft.AspNetCore.Mvc;
using StarWarsCharacter_Api.Interfaces;

namespace StarWarsCharacter_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CharactersController : ControllerBase
{
    private readonly ICharacterRepository _characterRepository;

    public CharactersController(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCharacters()
    {
        var characters = await _characterRepository.GetCharacters();

        return Ok(characters);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCharacter(int id)
    {
        var character = await _characterRepository.GetCharacter(id);

        return Ok(character);
    }
}