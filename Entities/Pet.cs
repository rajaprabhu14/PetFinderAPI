using System.ComponentModel.DataAnnotations;

namespace PetFinder.Entities;

public class Pet
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string ContactAddress { get; set; } = string.Empty;

    [Required]
    public string LostCity { get; set;} = string.Empty;

    [Required]
    public string FilePath { get; set; } = string.Empty;

    public bool IsFound { get; set; } = false;

    public DateTime MissingDate { get; set; } = DateTime.Now;
}
