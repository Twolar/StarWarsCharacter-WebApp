using StarWarsCharacter_Api.Interfaces;

namespace StarWarsCharacter_Api.Data;

public class StarWarsCharacterRepository : ICharacterRepository
{
    private readonly HttpClient _client;
    private const string _baseUrl = "https://swapi.dev/api";

    public StarWarsCharacterRepository()
    {
        _client = new HttpClient();
    }

    ~StarWarsCharacterRepository()
    {
        _client.Dispose();
    }

    public async Task<List<object>> GetCharacters()
    {
        try
        {
            // TODO: Remove hardset
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

            var response = await _client.GetAsync(_baseUrl + "/people");
            response.EnsureSuccessStatusCode();

            // TODO: Handle response with:
            // -- Need loop to handle api pagination
            // -- Map data to object list to be returned i.e. create character model?

            // TODO: Create model of characters to map to? So we are not using an 'anon' object.

            return characters;
        }
        catch (Exception e)
        {
            // Log exception
            throw;
        }
    }

    public async Task<object> GetCharacter(int id)
    {
        try
        {
            var character = new
            {
                Name = "GetCharacterById",
                Type = "Sith",
                LightSaberColor = "Red"
            };

            var response = await _client.GetAsync(_baseUrl + $"/people/{id}");
            response.EnsureSuccessStatusCode();

            // TODO: Handle response and create model of character to map to?

            return character;
        }
        catch (Exception e)
        {
            // Log exception
            throw;
        }
    }
}
