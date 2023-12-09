using StarWarsCharacter_Api.Models;

namespace StarWarsCharacter_Api.Interfaces;

public interface ICharacterRepository
{
    Task<IList<Character>> GetCharacters();
    Task<Character> GetCharacter(int id);
}
