using System.Text.Json;
using StarWarsCharacter_Api.Interfaces;
using StarWarsCharacter_Api.Models;

namespace StarWarsCharacter_Api.Data;

public class StarWarsCharacterRepository : ICharacterRepository
{
    private readonly ICharacterMapper _characterMapper;
    private readonly HttpClient _client;
    private const string _baseUrl = "https://swapi.dev/api";

    public StarWarsCharacterRepository(ICharacterMapper characterMapper)
    {
        _characterMapper = characterMapper;
        _client = new HttpClient();
    }

    ~StarWarsCharacterRepository()
    {
        _client.Dispose();
    }

    public async Task<IList<Character>> GetCharacters()
    {
        try
        {
            var response = await _client.GetAsync(_baseUrl + "/people");
            response.EnsureSuccessStatusCode();

            var contentJsonString = await response.Content.ReadAsStringAsync();

            // TODO: Need to account for other properties in the response too (i.e. next etc for pagination)
            List<SwapiCharacterDTO> swapiCharacterDTOs = JsonSerializer.Deserialize<List<SwapiCharacterDTO>>(contentJsonString);

            // TODO: Check if DTOS are null

            var characters = await _characterMapper.MapMulitple(swapiCharacterDTOs);
            // TODO: Handle response with:
            // -- Need loop to handle api pagination
            // -- Map data to object list to be returned i.e. create character model?

            return characters;
        }
        catch (Exception e)
        {
            // Log exception
            throw;
        }
    }

    public async Task<Character> GetCharacter(int id)
    {
        try
        {
            var response = await _client.GetAsync(_baseUrl + $"/people/{id}");
            response.EnsureSuccessStatusCode();

            var contentJsonString = await response.Content.ReadAsStringAsync();

            // TODO: Need to account for other properties in the response too (i.e. next etc for pagination)
            List<SwapiCharacterDTO> swapiCharacterDTOs = JsonSerializer.Deserialize<List<SwapiCharacterDTO>>(contentJsonString);

            // TODO: Check if DTOS are null

            var character = await _characterMapper.Map(swapiCharacterDTOs.First());

            return character;
        }
        catch (Exception e)
        {
            // Log exception
            throw;
        }
    }
}
