using System.Text.Json;
using StarWarsCharacter_Api.Helpers;
using StarWarsCharacter_Api.Interfaces;
using StarWarsCharacter_Api.Models;

namespace StarWarsCharacter_Api.Data;

public class StarWarsCharacterRepository : ICharacterRepository
{
    // TODO: Add basic logging?
    
    private readonly ICharacterMapper _characterMapper;
    private readonly HttpClient _client;
    private const string _baseUrl = "https://swapi.dev/api";
    private JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
    };

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
            var characterDTOs = new List<SwapiPersonDTO>();
            var nextApiPage = _baseUrl + "/people";

            while (!string.IsNullOrEmpty(nextApiPage))
            {
                // TODO: Future - If have time, look at improving the performance of this, as we do not need all of the character details here?
                // -- i.e. deserializing each character and mapping them is big overhead.

                var response = await _client.GetAsync(nextApiPage);
                ExternalApiResponseChecker.CheckResponseStatusCode(response);

                var contentJsonString = await response.Content.ReadAsStringAsync();

                var responseObject = JsonSerializer.Deserialize<SwapiPeopleHeaderDTO>(contentJsonString, _jsonSerializerOptions);

                if (responseObject == null)
                {
                    throw new InvalidOperationException($"{nameof(responseObject)} was null.");
                }

                if (responseObject.Results != null)
                {
                    characterDTOs.AddRange(responseObject.Results);
                }

                nextApiPage = responseObject.Next;
            }

            var mappedCharacters = _characterMapper.MapMulitple(characterDTOs);

            return mappedCharacters;
        }
        catch (Exception)
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
            ExternalApiResponseChecker.CheckResponseStatusCode(response);

            var contentJsonString = await response.Content.ReadAsStringAsync();

            var characterDTO = JsonSerializer.Deserialize<SwapiPersonDTO>(contentJsonString, _jsonSerializerOptions);

            if (characterDTO == null)
            {
                throw new InvalidOperationException($"{nameof(characterDTO)} was null.");
            }

            var character = _characterMapper.Map(characterDTO);

            return character;
        }
        catch (Exception)
        {
            // Log exception
            throw;
        }
    }
}