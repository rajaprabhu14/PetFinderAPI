namespace PetFinder.Repositories;

public interface IImageRepository
{
    Task<string> SaveFileAsync(IFormFile? imageFile, string[] allowedFileExtensions);
}
