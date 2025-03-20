using PetFinder.Repositories;

namespace PetFinder.Services
{
    public class ImageService(IWebHostEnvironment environment) : IImageRepository
    {
        private readonly IWebHostEnvironment _environment = environment;

        public async Task<string> SaveFileAsync(IFormFile? imageFile, string[] allowedFileExtensions)
        {
            ArgumentNullException.ThrowIfNull(imageFile);

            var contentPath = _environment.ContentRootPath;
            var path = Path.Combine(contentPath, "Uploads");

            var ext = Path.GetExtension(imageFile.FileName);
            
            if (!allowedFileExtensions.Contains(ext))
            {
                throw new ArgumentException($"Only {string.Join(",", allowedFileExtensions)} are allowed.");
            }

            // generate a unique filename
            var fileName = $"{ "PF" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Millisecond}{ext}";
            var fileNameWithPath = Path.Combine(path, fileName);
            using var stream = new FileStream(fileNameWithPath, FileMode.Create);
            await imageFile.CopyToAsync(stream);

            return fileName;
        }
    }
}
