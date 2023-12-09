using StarWarsCharacter_Api.Models;

namespace StarWarsCharacter_Api.Interfaces;

public interface ICharacterMapper
{
    Task<Character> Map(SwapiCharacterDTO characterDTO);
    Task<IList<Character>> MapMulitple(IList<SwapiCharacterDTO> characterDTOs);
}
