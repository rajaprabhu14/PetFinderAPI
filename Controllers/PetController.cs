using Azure;
using Microsoft.AspNetCore.Mvc;
using PetFinder.Entities;
using PetFinder.Models.Pet;
using PetFinder.Repositories;

namespace PetFinder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController(IPetRepository petRepository, IImageRepository fileService) : ControllerBase
{
    private readonly IPetRepository _petRepository = petRepository;

    [HttpGet]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<ActionResult<List<PetDetail>>> GetAll()
    {
        try
        {
            var response = await _petRepository.GetAll();

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
    [ProducesResponseType(200)]
    public async Task<ActionResult<PetDetail>> PostPetDetail([FromBody] Pet pet)
    {
        try
        {
            var createdProduct = await _petRepository.AddPetDetail(pet);

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
    [ProducesResponseType(200)]
    public async Task<ActionResult<Pet>> UpdatePet([FromBody] int id)
    {
        try
        {
            var response = await _petRepository.UpdatePet(id);
            //if(response)
            //{
            //    var details = await _petRepository.GetAll();
            //return StatusCode(StatusCodes.Status201Created, details);
            //}
            return StatusCode(StatusCodes.Status201Created, response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
