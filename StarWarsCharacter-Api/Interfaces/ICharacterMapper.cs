using StarWarsCharacter_Api.Models;

namespace StarWarsCharacter_Api.Interfaces;

public interface ICharacterMapper
{
    Task<Character> Map(SwapiPersonDTO characterDTO);
    Task<IList<Character>> MapMulitple(IList<SwapiPersonDTO> characterDTOs);
}
