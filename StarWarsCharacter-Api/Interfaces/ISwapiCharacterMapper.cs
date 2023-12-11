using StarWarsCharacter_Api.Models;

namespace StarWarsCharacter_Api.Interfaces;

public interface ISwapiCharacterMapper
{
    Character Map(SwapiPersonDTO characterDTO);
    IList<Character> MapMulitple(IList<SwapiPersonDTO> characterDTOs);
}
