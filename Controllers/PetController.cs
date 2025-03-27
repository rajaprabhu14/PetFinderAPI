using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetFinder.DTO.Pet;
using PetFinder.Entities;
using PetFinder.Repositories;

namespace PetFinder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController(IPetRepository petRepository) : ControllerBase
{
    private readonly IPetRepository _petRepository = petRepository;

    [HttpGet]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<ActionResult<List<PetDetail>>> GetPets()
    {
        try
        {
            var response = await _petRepository.GetPets();

            return StatusCode(StatusCodes.Status200OK, response);
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // POST: api/PetDetails
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Authorize]
    [ProducesResponseType(200)]
    public async Task<ActionResult<PetDetail>> PostPetDetail([FromBody] Pet pet)
    {
        try
        {
            var createdProduct = await _petRepository.AddPet(pet);

            return StatusCode(StatusCodes.Status201Created, createdProduct);
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/PetDetails
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut]
    [Authorize]
    [ProducesResponseType(200)]
    public async Task<ActionResult<Pet>> UpdatePet([FromBody] Pet pet)
    {
        try
        {
            var response = await _petRepository.UpdatePet(pet.Id);
            return StatusCode(StatusCodes.Status201Created, response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
