using Microsoft.EntityFrameworkCore;
using PetFinder.Data;
using PetFinder.DTO.Pet;
using PetFinder.Entities;
using PetFinder.Repositories;

namespace PetFinder.Services;

public class PetService(PetDbContext petDbContext) : IPetRepository
{
    private readonly PetDbContext _petDbContext = petDbContext;

    public async Task<List<PetDetail>> GetPets()
    {
        var response = await _petDbContext.Pets.Select(pet => new PetDetail
        {
            Id = pet.Id,
            Name = pet.Name,
            ContactAddress = pet.ContactAddress,
            MissingDate = pet.MissingDate,
            LostCity = pet.LostCity,
            IsFound = pet.IsFound,
            FilePath = pet.FilePath,
        }).AsNoTracking().ToListAsync();

        return response;
    }

    public async Task<Guid> AddPet(Pet pet)
    {
        try
        {
            pet.Id = Guid.NewGuid();
            _petDbContext.Pets.Add(pet);
            await _petDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Guid.Empty;
        }

        return pet.Id;
    }

    public async Task<Guid> UpdatePet(Guid id)
    {
        try
        {
            var response = await _petDbContext.Pets.FindAsync(id);

            if (response is not null)
            {
                response.IsFound = true;
                _petDbContext.Pets.Update(response);
                await _petDbContext.SaveChangesAsync();

                return response.Id;
            }
        }

        catch { return Guid.Empty; }

        return id;
    }
}
