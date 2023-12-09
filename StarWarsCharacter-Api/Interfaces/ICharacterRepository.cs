namespace StarWarsCharacter_Api.Interfaces;

public interface ICharacterRepository {
    Task<List<object>> GetCharacters();
    Task<object> GetCharacter(int id);
}
