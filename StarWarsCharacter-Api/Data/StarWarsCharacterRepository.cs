using System.Text.Json;
using StarWarsCharacter_Api.Helpers;
using StarWarsCharacter_Api.Interfaces;
using StarWarsCharacter_Api.Models;

namespace StarWarsCharacter_Api.Data;

public class StarWarsCharacterRepository : ICharacterRepository
{
    private readonly ILogger<StarWarsCharacterRepository> _logger;
    private readonly ISwapiCharacterMapper _characterMapper;
    private readonly HttpClient _client;
    private const string _baseUrl = "https://swapi.dev/api";
    private JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
    };

    public StarWarsCharacterRepository(ILogger<StarWarsCharacterRepository> logger, ISwapiCharacterMapper characterMapper, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _characterMapper = characterMapper;
        _client = httpClientFactory.CreateClient();
    }

    ~StarWarsCharacterRepository()
    {
        _client.Dispose();
    }

    public async Task<IList<Character>> GetCharacters(string searchExtension = "")
    {
        _logger.LogDebug("StarWarsCharacterRepository::GetCharacters('')");
        try
        {
            var characterDTOs = new List<SwapiPersonDTO>();
            var nextApiPage = $"{_baseUrl}/people{searchExtension}";

            while (!string.IsNullOrEmpty(nextApiPage))
            {
                // TODO: Future - If have time, look at improving the performance of this?
                // -- i.e. Deserializing each character and mapping them is big overhead. Do we need the whole object?
                // -- i.e. Implement your own pagination as an extension of the SWAPI?
                // -- i.e. Some sort of caching?
                // -- i.e. Guess it would depend on further requirements of this application? Who is to be using it and what for etc?
                // -- i.e. Multithreading the paginated api calls based of the character counts in the response?
                // -- Did I miss the brief here, was I supposed to be persisting these to a DB?

                var response = await _client.GetAsync(nextApiPage);
                ExternalApiResponseChecker.CheckResponseStatusCode(response);

                var contentJsonString = await response.Content.ReadAsStringAsync();

                var responseObject = JsonSerializer.Deserialize<SwapiPeopleResponse>(contentJsonString, _jsonSerializerOptions);

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
        catch (Exception e)
        {
            _logger.LogDebug("StarWarsCharacterRepository::GetCharacters('') encountered an exception", e);
            throw;
        }
    }

    public async Task<IList<Character>> GetCharacters()
    {
        _logger.LogDebug("StarWarsCharacterRepository::GetCharacters()");
        return await GetCharacters("");
    }

    public async Task<IList<Character>> SearchCharacters(string searchValue)
    {
        _logger.LogDebug("StarWarsCharacterRepository::SearchCharacters()");
        var searchExtension = $"/?search={searchValue}";
        return await GetCharacters(searchExtension);
    }

    public async Task<Character> GetCharacter(int id)
    {
        _logger.LogDebug("StarWarsCharacterRepository::GetCharacter()");
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
        catch (Exception e)
        {
             _logger.LogDebug("StarWarsCharacterRepository::GetCharacter() encountered an exception", e);
            throw;
        }
    }
}