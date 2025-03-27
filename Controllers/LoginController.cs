using Microsoft.AspNetCore.Mvc;
using PetFinder.DTO.login;
using PetFinder.Entities;
using PetFinder.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetFinder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController(ILoginRepository loginRepository) : ControllerBase
{
    private readonly ILoginRepository _loginRepository = loginRepository;

    // POST api/<LoginController>
    [HttpPost]
    [ProducesResponseType(200)]
    public async Task<ActionResult<LoginResponse>> Post([FromBody] Login login)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(login);

            bool loginCredentialsValid = login.Password == "admin";

            if(loginCredentialsValid)
            {
                var response = await _loginRepository.GenerateJwtToken(login.Username);
                return StatusCode(StatusCodes.Status201Created, response);
            }

            return BadRequest(StatusCodes.Status500InternalServerError);
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
