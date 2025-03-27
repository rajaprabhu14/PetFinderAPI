namespace PetFinder.DTO.Pet;

public class PetDetail
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? ContactAddress { get; set; }

    public string? LostCity { get; set; }

    public string? FilePath { get; set; }

    public bool IsFound { get; set; }

    public DateTime MissingDate {  get; set; }
}
