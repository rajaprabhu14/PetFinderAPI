using System.ComponentModel.DataAnnotations;

namespace PetFinder.Entities;

public class Pet
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string ContactAddress { get; set; } = string.Empty;

    [Required]
    public string LostCity { get; set;} = string.Empty;

    [Required]
    public string FilePath { get; set; } = string.Empty;

    [Required]
    public bool IsFound { get; set; }

    public int UserId {  get; set; }

    public DateTime MissingDate { get; set; }
}
