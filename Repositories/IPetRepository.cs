using PetFinder.Entities;
using PetFinder.Models.Pet;

namespace PetFinder.Repositories;

public interface IPetRepository
{
    Task<List<PetDetail>> GetAll();

    Task<bool> AddPetDetail(Pet pet);

    Task<bool> UpdatePet(int id);
}
