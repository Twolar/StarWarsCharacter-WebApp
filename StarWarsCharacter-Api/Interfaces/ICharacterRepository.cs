using StarWarsCharacter_Api.Models;

namespace StarWarsCharacter_Api.Interfaces;

public interface ICharacterRepository
{
    Task<IList<Character>> GetCharacters();
    Task<IList<Character>> SearchCharacters(string searchValue);
    Task<Character> GetCharacter(int id);
}
