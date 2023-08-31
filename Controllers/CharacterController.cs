using Microsoft.AspNetCore.Mvc;
namespace dotnet_rpg;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;
    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<ServiceResponce<List<GetCharacterDto>>>> Get()
    {
        return Ok(await _characterService.GetAllCharacters());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponce<List<GetCharacterDto>>>> GetSingle(int id)
    {
        return Ok(await _characterService.GetCharacterById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponce<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
    {
        return Ok(await _characterService.AddCharacter(newCharacter));
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponce<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updetedCharacter)
    {
        var responce = await _characterService.UpdateCharacter(updetedCharacter);
        if (responce.Data is null) return NotFound(updetedCharacter);
        return Ok(responce);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponce<List<GetCharacterDto>>>> DeleteCharacter (int id)
    {
        return Ok(await _characterService.DeleteCharacter(id));
    }
}
