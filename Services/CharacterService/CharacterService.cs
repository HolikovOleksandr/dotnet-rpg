using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{Id= 1, Name = "Sam"}
        };

        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponce<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponce = new ServiceResponce<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            serviceResponce.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponce = new ServiceResponce<List<GetCharacterDto>>();

            try
            {
                var character = characters.First(c => c.Id == id);
                if (character is null) throw new Exception("Character not found");

                characters.Remove(character);

                serviceResponce.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(character)).ToList();
            }
            catch (Exception e)
            {
                serviceResponce.Success = false;
                serviceResponce.Message = e.Message;
            }

            return serviceResponce;

        }

        public async Task<ServiceResponce<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponce = new ServiceResponce<List<GetCharacterDto>>();
            serviceResponce.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponce = new ServiceResponce<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id)!;
            serviceResponce.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponce;
        }

        public async Task<ServiceResponce<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponce = new ServiceResponce<GetCharacterDto>();

            try
            {
                var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

                if (character is null) throw new Exception("Character not found");

                _mapper.Map(updatedCharacter, character);

                character.Name = updatedCharacter.Name;
                character.HitPoint = updatedCharacter.HitPoint;
                character.Strength = updatedCharacter.Strength;
                character.Defence = updatedCharacter.Defence;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;

                serviceResponce.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception e)
            {
                serviceResponce.Success = false;
                serviceResponce.Message = e.Message;
            }

            return serviceResponce;
        }
    }
}