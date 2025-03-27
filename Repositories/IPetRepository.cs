using PetFinder.DTO.Pet;
using PetFinder.Entities;

namespace PetFinder.Repositories;

public interface IPetRepository
{
    Task<List<PetDetail>> GetPets();

    Task<Guid> AddPet(Pet pet);

    Task<Guid> UpdatePet(Guid id);
}
