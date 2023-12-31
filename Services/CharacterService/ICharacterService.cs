using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponce<List<GetCharacterDto>>> GetAllCharacters();

        Task<ServiceResponce<GetCharacterDto>> GetCharacterById(int id);

        Task<ServiceResponce<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);

        Task<ServiceResponce<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);

        Task<ServiceResponce<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}