using Microsoft.AspNetCore.Mvc;
using PetFinder.Models.Image;
using PetFinder.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController(IImageRepository imageRepository) : ControllerBase
    {
        private readonly IImageRepository imageRepository = imageRepository;

        // POST: api/PetDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("uploadImage")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<PetImage>> AddImage(IFormFile formFile)
        {
            try
            {
                if (formFile.Length > 1 * 1024 * 1024)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "File size should not exceed 1 MB");
                }

                string[] allowedFileExtentions = [".jpg", ".jpeg", ".png", ".PNG"];
                string createdImageName = await imageRepository.SaveFileAsync(formFile, allowedFileExtentions);

                var petImage = new PetImage()
                {
                    Id = createdImageName,
                    IsImageUploaded = true,
                };

                return StatusCode(StatusCodes.Status201Created, petImage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
