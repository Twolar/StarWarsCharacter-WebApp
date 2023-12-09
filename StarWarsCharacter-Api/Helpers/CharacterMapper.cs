using StarWarsCharacter_Api.Interfaces;
using StarWarsCharacter_Api.Models;

namespace StarWarsCharacter_Api.Helpers;

public class CharacterMapper : ICharacterMapper
{
    public Character Map(SwapiPersonDTO characterDTO)
    {
        int newIntId;
        int? id = null;

        // Extract Id from URL string
        if (!string.IsNullOrEmpty(characterDTO.url))
        {
            var tempIdString = characterDTO.url.Replace("https://swapi.dev/api/people/", "");
            tempIdString = tempIdString.Replace("/", "");
            if (int.TryParse(tempIdString, out newIntId))
            {
                id = newIntId;
            }
        }

        return new Character()
        {
            Id = id,
            BirthYear = characterDTO.birth_year,
            EyeColor = characterDTO.eye_color,
            Films = characterDTO.films,
            Gender = characterDTO.gender,
            HairColor = characterDTO.hair_color,
            Height = characterDTO.height,
            Homeworld = characterDTO.homeworld,
            Mass = characterDTO.mass,
            Name = characterDTO.name,
            SkinColor = characterDTO.skin_color,
            Created = characterDTO.created,
            Edited = characterDTO.edited,
            Species = characterDTO.species,
            Starships = characterDTO.starships,
            Url = characterDTO.url,
            Vehicles = characterDTO.vehicles
        };
    }

    public IList<Character> MapMulitple(IList<SwapiPersonDTO> characterDTOs)
    {
        var characters = new List<Character>();

        foreach (SwapiPersonDTO characterDTO in characterDTOs)
        {
            var character = Map(characterDTO);
            characters.Add(character);
        }

        return characters;
    }
}
