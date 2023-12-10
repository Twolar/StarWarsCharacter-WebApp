using Microsoft.AspNetCore.Mvc;
using StarWarsCharacter_Api.Helpers;
using StarWarsCharacter_Api.Interfaces;

namespace StarWarsCharacter_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CharactersController : ControllerBase
{
    // TODO: Add basic logging?

    private readonly ICharacterRepository _characterRepository;

    public CharactersController(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCharacters()
    {
        try
        {
            var characters = await _characterRepository.GetCharacters();

            return Ok(characters);
        }
        catch (SWCApiException swcae)
        {
            return StatusCode((int)swcae.HttpStatusCode, new
            {
                message = swcae.Message,
            });
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                message = e.Message
            });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCharacter(int id)
    {
        try
        {
            var character = await _characterRepository.GetCharacter(id);

            return Ok(character);
        }
        catch (KeyNotFoundException knfe)
        {
            return NotFound(new
            {
                message = knfe.Message
            });
        }
        catch (SWCApiException swcae)
        {
            return StatusCode((int)swcae.HttpStatusCode, new
            {
                message = swcae.Message,
            });
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                message = e.Message
            });
        }
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Search(CharacterSearchRequestModel model)
    {
        try
        {
            var characters = await _characterRepository.SearchCharacters(model.SearchValue!);

            return Ok(characters);
        }
        catch (SWCApiException swcae)
        {
            return StatusCode((int)swcae.HttpStatusCode, new
            {
                message = swcae.Message,
            });
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                message = e.Message
            });
        }
    }
}